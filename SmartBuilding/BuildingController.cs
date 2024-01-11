namespace SmartBuilding
{
    public class BuildingController
    {
        private string buildingID;
        private string currentState;

        // L1R1: Constructor with a string parameter for buildingID
        public BuildingController(string id)
        {
            // Initialize buildingID with a default non null value
            buildingID = string.Empty;

            SetBuildingID(id); // This will then set the correct buildingID
            currentState = "out of hours"; // Set initial currentState
        }

        // L1R2: GetBuildingID method
        public string GetBuildingID()
        {
            return buildingID;
        }

        // L1R4: SetBuildingID method
        public void SetBuildingID(string id)
        {
            buildingID = id.ToLower(); // Convert uppercase to lowercase
        }

        // L1R6: GetCurrentState method
        public string GetCurrentState()
        {
            return currentState;
        }

        // L1R7: SetCurrentState method
        public bool SetCurrentState(string newState)
        {
            if (IsValidState(newState)) {
                currentState = newState;
                return true;
            }
            return false;
        }

        // Helper method to check for valid states
        private bool IsValidState(string state)
        {
            var validStates = new List<string> { "closed", "out of hours", "open", "fire drill", "fire alarm" };
            return validStates.Contains(state.ToLower());
        }
    }

}