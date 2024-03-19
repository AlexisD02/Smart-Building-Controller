namespace SmartBuilding
{
    public class BuildingController
    {
        //BuildingController code
        private string buildingID = string.Empty; // Initializes buildingID with an empty string
        private string currentState = string.Empty; // Initializes currentState with an empty string
        private ILightManager? lightManager; // Nullable ILightManager variable
        private IFireAlarmManager? fireAlarmManager; // Nullable IFireAlarmManager variable
        private IDoorManager? doorManager; // Nullable IDoorManager variable
        private IWebService? webService; // Nullable IWebService variable
        private IEmailService? emailService; // Nullable IEmailService variable

        // L1R1: Constructor with a string parameter for buildingID
        public BuildingController(string id)
        {
            buildingID = id.ToLower();
            currentState = "out of hours"; // L1R5: Constructor sets the initial value of currentState to “out of hours”
        }

        // L2R3: Constructor to set default values for buildingID and currentState
        public BuildingController(string id, string startState)
        {
            buildingID = id.ToLower(); // Convert to lowercase
            switch (startState.ToLower()) { // Convert to lowercase for case-insensitive comparison
                case "closed":
                case "out of hours":
                case "open":
                    currentState = startState.ToLower(); // Store the lowercase state
                    break;
                default:
                    throw new ArgumentException("Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'");
            }
        }

        // L3R1: Constructor with dependency injection
        public BuildingController(string id, ILightManager iLightManager, IFireAlarmManager iFireAlarmManager,
            IDoorManager iDoorManager, IWebService iWebService, IEmailService iEmailService)
        {
            buildingID = id.ToLower();
            currentState = "out of hours";
            lightManager = iLightManager;
            fireAlarmManager = iFireAlarmManager;
            doorManager = iDoorManager;
            webService = iWebService;
            emailService = iEmailService;
        }

        // L1R2: GetBuildingID returns the value of the buildingID variable
        public string GetBuildingID()
        {
            return buildingID;
        }

        // L1R4: SetBuildingID sets the value of buildingID, converting uppercase letters to lowercase
        public void SetBuildingID(string id)
        {
            buildingID = id.ToLower(); // Convert uppercase to lowercase
        }

        // L1R6: GetCurrentState returns the value of the currentState object variable
        public string GetCurrentState()
        {
            return currentState;
        }

        // L1R7: Validates state change requests against predefined valid states
        public bool SetCurrentState(string providedState)
        {
            // Normalize states to lowercase for consistent comparison
            currentState = currentState.ToLower();
            providedState = providedState.ToLower();

            // Define a list of valid states
            var validStates = new List<string> { "closed", "out of hours", "open", "fire drill", "fire alarm" };

            if (!validStates.Contains(providedState)) { // Early return if providedState is not valid
                return false;
            }

            // Logic to prevent unnecessary state changes
            if (currentState == providedState) { // If current and provided states are the same, no change is needed
                return true;
            }

            // Determine if the state transition is allowed based on current rules
            bool isTransitionAllowed = providedState switch {
                "open" => currentState != "closed",
                "closed" => currentState != "open",
                "fire alarm" => currentState != "fire drill",
                "fire drill" => currentState != "fire alarm",
                _ => true, // Default case allows transition for unspecified valid states
            };

            // Execute actions based on the allowed transition
            if (isTransitionAllowed) {
                if (providedState == "open" && !(doorManager?.OpenAllDoors() ?? true)) {
                    // If there was a failure to open all the doors (meaning OpenAllDoors returned false),
                    // return false without changing the state
                    return false;
                }
                else if (providedState == "closed") {
                    if (!(doorManager?.LockAllDoors() ?? true)) {
                        // If there was a failure to lock all the doors (meaning LockAllDoors returned false),
                        // return false without changing the state
                        return false;
                    }
                    lightManager?.SetAllLights(false);
                }
                else if (providedState == "fire alarm") {
                    fireAlarmManager?.SetAlarm(true);
                    if (!(doorManager?.OpenAllDoors() ?? true)) {
                        // If there was a failure to open all the doors (meaning OpenAllDoors returned false),
                        // return false without changing the state
                        return false;
                    }
                    lightManager?.SetAllLights(true);
                    // Attempt to log the fire alarm event
                    try {
                        webService?.LogFireAlarm("fire alarm");
                    }
                    catch (Exception ex) { // Sends an email notification if logging fails
                        emailService?.SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", ex.Message);
                    }
                }
                currentState = providedState; // Update state if all conditions are met
                return true;
            }
            return false; // Return false if transition is not allowed
        }

        // L3R3: GetStatusReport() method implementation
        public string GetStatusReport()
        {
            // Initialize status strings for each manager as empty
            string lightStatus = string.Empty;
            string doorStatus = string.Empty;
            string fireAlarmStatus = string.Empty;

            var faultDevices = new List<string>(); // List to track which devices have faults

            // Check each manager for null before calling GetStatus
            if (lightManager != null) lightStatus = lightManager.GetStatus(); // Retrieve status from light manager if it's available
            if (doorManager != null) doorStatus = doorManager.GetStatus(); // Retrieve status from door manager if it's available
            if (fireAlarmManager != null) fireAlarmStatus = fireAlarmManager.GetStatus(); // Retrieve status from fire alarm manager if it's available

            if (lightStatus.Contains("FAULT")) faultDevices.Add("Lights"); // Add "Lights" to faultDevices list if any light faults were found
            if (doorStatus.Contains("FAULT")) faultDevices.Add("Doors"); // Add "Doors" to faultDevices list if any door faults were found
            if (fireAlarmStatus.Contains("FAULT")) faultDevices.Add("FireAlarm"); // Add "FireAlarm" to faultDevices list if any fire alarm faults were found

            // Log a message if any faults were detected, specifying which devices need an engineer
            if (faultDevices.Any()) webService?.LogEngineerRequired(string.Join(",", faultDevices) + ",");

            // Concatenates the individual status strings from lightManager, doorManager, 
            // and fireAlarmManager into a single comprehensive status report.
            return lightStatus + doorStatus + fireAlarmStatus;
        }
    }
}