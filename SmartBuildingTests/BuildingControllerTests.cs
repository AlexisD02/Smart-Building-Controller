using NUnit.Framework;
using SmartBuilding;

namespace SmartBuildingTests
{
    [TestFixture]
    public class BuildingControllerTests
    {
        // Naming convention for test methods: MethodBeingTested_TestScenario_ExpectedOutput
        // Example: SetCurrentState_InvalidState_ReturnsFalse

        // Test for GetBuildingID method
        [Test]
        public void GetBuildingID_ValidID_ReturnsCorrectID()
        {
            // Arrange: Setting up the test with a known ID and initializing the controller
            string expectedID = "building123";
            BuildingController controller = new BuildingController(expectedID);

            // Act: Getting the ID from the controller
            string result = controller.GetBuildingID();

            // Assert: Verifying that the returned ID matches the expected ID (converted to lowercase)
            Assert.AreEqual(expectedID.ToLower(), result);
        }   

        // Test for SetBuildingID method with different test cases
        [TestCase("BUILDING123")]
        [TestCase("buildingABC")]
        public void SetBuildingID_ValidID_SetsIDCorrectly(string newID)
        {
            // Arrange: Initializing the controller with an initial ID
            BuildingController controller = new BuildingController("initialID");

            // Act: Setting a new ID and retrieving it
            controller.SetBuildingID(newID);
            string result = controller.GetBuildingID();

            // Assert: Checking if the new ID is set correctly and converted to lowercase
            Assert.AreEqual(newID.ToLower(), result);
        }

        // Test for GetCurrentState method to verify the initial state
        [Test]
        public void GetCurrentState_InitialState_ReturnsOutOfHours()
        {
            // Arrange: Initializing the controller with a test ID
            string expectedID = "building123";
            BuildingController controller = new BuildingController(expectedID);

            // Act: Getting the current state of the controller
            string result = controller.GetCurrentState();

            // Assert: Verifying that the initial state is "out of hours"
            Assert.AreEqual("out of hours", result);
        }

        // Test for SetCurrentState method with different states
        [TestCase("closed")]
        [TestCase("out of hours")]
        [TestCase("open")]
        [TestCase("fire drill")]
        [TestCase("fire alarm")]
        public void SetCurrentState_ValidState_ReturnsTrueAndSetsState(string newState)
        {
            // Arrange
            BuildingController controller = new BuildingController("building123");

            // Act
            bool result = controller.SetCurrentState(newState);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(newState, controller.GetCurrentState());
        }

        [TestCase("invalidState")]
        [TestCase("systemDelete")]
        [TestCase("")]
        public void SetCurrentState_InvalidState_ReturnsFalse(string newState)
        {
            // Arrange
            BuildingController controller = new BuildingController("building123");

            // Act
            bool result = controller.SetCurrentState(newState);

            // Assert
            Assert.IsFalse(result);
            Assert.AreNotEqual(newState, controller.GetCurrentState()); // State remains unchanged
        }
    }
}
