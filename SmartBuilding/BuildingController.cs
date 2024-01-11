namespace SmartBuilding
{
    public class BuildingController
    {
        private string buildingID;
        private string currentState;

        // Constructor
        public BuildingController(string buildingID)
        {
            SetBuildingID(buildingID);
            currentState = "out of hours"; // Initial state
        }

        // Method to get the Building ID
        public string GetBuildingID()
        {
            return buildingID;
        }

        // Method to set the Building ID
        public void SetBuildingID(string newID)
        {
            // Ensure that the building ID is converted to lowercase
            buildingID = newID.ToLower();
        }

        // Method to get the current state
        public string GetCurrentState()
        {
            return currentState;
        }

        // Method to set the current state
        public void SetCurrentState(string newState)
        {
            // Add any necessary validation for the new state
            currentState = newState;
        }
    }
}