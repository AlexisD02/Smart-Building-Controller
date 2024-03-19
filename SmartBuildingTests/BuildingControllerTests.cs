using NUnit.Framework;
using NSubstitute;
using SmartBuilding;
using NUnit.Framework.Legacy;
using NSubstitute.Exceptions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;


namespace SmartBuildingTests
{
    [TestFixture]
    public class BuildingControllerTests
    {

        //This is a test to check if the project template is correctly configured on your machine
        //you should uncomment the test method below and check that the test appears in the text explorer. (Test -> Test Explorer)
        //When you run the unit test it should pass with the message "Example Test Passed"
        //If the test is not visible or the unit test does not run or pass: Ask a tutor for help
        //When you have confirmed that the template can run unit tests, you can delete the teet. (and this comment)
        /*
        [Test]
        public void TemplateTest(){
            Assert.Pass("Example Test Passed!");
        }
        */

        //use the following naming convention for your test method names MethodBeingTested_TestScenario_ExpectedOutput
        //E.g. SetCurrentState_InvalidState_ReturnsFalse

        //Write Test Code Here...

        // L1R1
        [Test]
        public void L1R1_ConstructorMethod_InitializedWithID_ShouldNotBeNull()
        {
            // Arrange: Declare a variable for expected ID and BuildingController.
            string expectedID;
            BuildingController bc;

            // Act: Instantiate BuildingController with the expected ID.
            expectedID = "id123";
            bc = new BuildingController(expectedID);

            // Assert: Verify that the BuildingController instance is not null.
            ClassicAssert.IsNotNull(bc);
        }

        // L1R1 // L1R2
        [Test]
        public void L1R1_ConstructorMethod_GetBuildingID_ReturnsCorrectID()
        {
            // Arrange: Declare a variable for expected ID and BuildingController.
            string expectedID;
            BuildingController bc;

            // Act: Instantiate BuildingController with expectedID and retrieve the ID.
            expectedID = "id123";
            bc = new BuildingController(expectedID);
            string result = bc.GetBuildingID();

            // Assert: Compare the retrieved ID with the expected ID.
            ClassicAssert.AreEqual(expectedID, result);
        }

        // L1R3
        [TestCase("UPPERCASE")]
        [TestCase("NEWID001")]
        [TestCase("OLDID002")]
        public void L1R3_ConstructorMethod_SetUppercaseID_ReturnsLowercaseID(string expectedID)
        {
            // Arrange: Declare a variable for BuildingController.
            BuildingController bc;

            // Act: Instantiate BuildingController with expectedID and retrieve the ID.
            bc = new BuildingController(expectedID);
            string result = bc.GetBuildingID();

            // Assert: Compare the retrieved ID (expected to be lowercase) with the expected ID,
            // also converted to lowercase.
            ClassicAssert.AreEqual(expectedID.ToLower(), result);
        }

        // L1R4
        [TestCase("CandT002")]
        [TestCase("NewID001")]
        [TestCase("NewID222")]
        public void L1R4_ConstructorMethod_SetValidID_SetCorrectID(string newID)
        {
            // Arrange: Declare a variable for BuildingController.
            BuildingController bc;
            string result;

            // Act: Set a new ID for the BuildingController and retrieve it.
            bc = new BuildingController(newID);
            bc.SetBuildingID(newID);
            result = bc.GetBuildingID();

            // Assert: Verify that the set ID matches the expected new ID,
            // considering case conversion.
            ClassicAssert.AreEqual(newID.ToLower(), result);
        }

        // L1R5 // L1R6
        [Test]
        public void L1R6_ConstructorMethod_InitializeAndGetCurrentState_ReturnsCurrentState()
        {
            // Arrange: Declare a variable for BuildingController.
            string id;
            BuildingController bc;
            string result;

            // Act: Create BuildingController instance and retrieve its current state.
            id = "CandT001";
            bc = new BuildingController(id);
            result = bc.GetCurrentState();

            // Assert: Verify the initial state is correctly set to "out of hours".
            ClassicAssert.AreEqual("out of hours", result);
        }

        // L1R7
        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("fire drill")]
        [TestCase("fire alarm")]
        public void L1R7_ConstructorMethod_SetValidCurrentState_ChangesCurrentState(string providedState)
        {
            // Arrange: Declare a variable for BuildingController.
            string id;
            BuildingController bc;
            string result;

            // Act: Set the current state to a valid provided state and retrieve it.
            id = "CandT001";
            bc = new BuildingController(id);
            bc.SetCurrentState(providedState);
            result = bc.GetCurrentState();

            // Assert: Verify the current state is updated to the provided valid state.
            ClassicAssert.AreEqual(providedState, result);
        }

        // L1R7
        [TestCase("invalidState")]
        [TestCase("systemDelete")]
        [TestCase("hackSystem32")]
        [TestCase("")]
        public void L1R7_ConstructorMethod_SetInvalidCurrentState_DoesNotChangesCurrentState(string providedState)
        {
            // Arrange: Declare a variable for BuildingController.
            string id;
            BuildingController bc;
            string result;

            // Act: Attempt to set the current state to an invalid provided state and retrieve it.
            id = "CandT001";
            bc = new BuildingController(id);
            bc.SetCurrentState(providedState);
            result = bc.GetCurrentState();

            // Assert: Verify the current state remains unchanged from the
            // default "out of hours" after an invalid attempt.
            ClassicAssert.AreEqual("out of hours", result);
        }

        // L1R7
        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("fire drill")]
        [TestCase("fire alarm")]
        public void L1R7_ConstructorMethod_SetValidCurrentState_ReturnsTrue(string providedState)
        {
            // Arrange: Declare a variable for BuildingController.
            string id;
            BuildingController bc;
            bool isValid;

            // Act: Test setting a valid state and capture the result.
            id = "CandT005";
            bc = new BuildingController(id);
            isValid = bc.SetCurrentState(providedState);

            // Assert: Verify setting a valid state returns true.
            ClassicAssert.AreEqual(isValid, true);
        }

        // L1R7
        [TestCase("invalidState")]
        [TestCase("systemDelete")]
        [TestCase("hackSystem32")]
        [TestCase("")]
        public void L1R7_ConstructorMethod_SetInvalidCurrentState_ReturnsFalse(string providedState)
        {
            // Arrange: Declare a variable for BuildingController.
            string id;
            BuildingController bc;
            bool isValid;

            // Act: Test setting an invalid state and capture the result.
            id = "CandT005";
            bc = new BuildingController(id);
            isValid = bc.SetCurrentState(providedState);

            // Assert: Verify setting an invalid state returns false.
            ClassicAssert.AreEqual(isValid, false);
        }

        // L2R1
        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("fire drill")]
        [TestCase("fire alarm")]
        public void L2R1_SecondConstructorMethod_SetNewValidState_ReturnsTrue(string providedState)
        {
            // Arrange: Declare a variable for BuildingController.
            string id, state;
            BuildingController bc;
            bool isValid;

            // Act: Test setting an valid state and capture the result.
            id = "CandT006";
            state = "out of hours";
            bc = new BuildingController(id, state);
            isValid = bc.SetCurrentState(providedState);

            // Assert: The method returns true for valid states
            ClassicAssert.AreEqual(isValid, true);
        }

        // L2R1
        [TestCase("closed")]
        public void L2R1_SecondConstructorMethod_SetNewInvalidState_ReturnsFalse(string providedState)
        {
            // Arrange: Declare a variable for BuildingController.
            string id, state;
            BuildingController bc;
            bool isValid;

            // Act: Test setting an invalid state and capture the result.
            id = "CandT006";
            state = "open";
            bc = new BuildingController(id, state);
            isValid = bc.SetCurrentState(providedState);

            // Assert: The method returns false for invalid states
            ClassicAssert.AreEqual(isValid, false);
        }

        // L2R2
        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("out of hours")]
        public void L2R2_SecondConstructorMethod_SetSameState_ReturnsTrue(string providedState)
        {
            // Arrange: Declare a variable for BuildingController.
            string id;
            BuildingController bc;
            bool result;

            // Act: Test setting an valid state and capture the result.
            id = "id123";
            bc = new BuildingController(id, providedState);
            result = bc.SetCurrentState(providedState);

            // Assert: The method returns true for valid states
            ClassicAssert.AreEqual(result, true);
        }

        // L2R2
        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("out of hours")]
        public void L2R2_SecondConstructorMethod_SetSameState_StateUnchanged(string providedState)
        {
            // Arrange: Declare a variable for BuildingController.
            string id, sameState, result;
            BuildingController bc;

            // Act: Test setting an valid state and capture the result.
            id = "id123";
            bc = new BuildingController(id, providedState);
            sameState = providedState;
            bc.SetCurrentState(sameState);
            result = bc.GetCurrentState();

            // Assert: The method returns the valid changed state
            ClassicAssert.AreEqual(providedState.ToLower(), result);
        }

        // L2R3
        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("out of hours")]
        public void L2R3_SecondConstructorMethod_InitializedWithIDAndCurrentState_ShouldNotBeNull(string providedState)
        {
            // Arrange: Declare a variable for expected ID and BuildingController.
            string id;
            BuildingController bc;

            // Act: Instantiate BuildingController with the expected ID.
            id = "id123";
            bc = new BuildingController(id, providedState);

            // Assert: Verify that the BuildingController instance is not null.
            ClassicAssert.IsNotNull(bc);
        }

        // L2R3
        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("out of hours")]
        public void L2R3_SecondConstructorMethod_SetValidStartState_SetsDefaultValues(string providedState)
        {
            // Arrange: Initializing BuildingController with a test ID and a state from the test case.
            BuildingController bc;
            string result;

            // Act: Creating a BuildingController instance with a predefined state and retrieving its current state.
            bc = new BuildingController("CandT007", providedState);
            result = bc.GetCurrentState();

            // Assert: Verifying that the current state matches the provided state, ensuring it's correctly set and case-normalized.
            ClassicAssert.AreEqual(providedState.ToLower(), result);
        }


        [TestCase("")]
        [TestCase("file alarm")]
        [TestCase("file drill")]
        [TestCase("invalidState")]
        public void L2R3_SecondConstructor_WithInvalidState_ThrowsArgumentExceptionWithDetailedMessage(string providedState)
        {
            // Arrange: Providing a context for the test case with a meaningful ID and invalid state
            string id;
            BuildingController bc;

            // Act & Assert: Expecting an ArgumentException when initializing with an invalid state
            id = "CandT008";
            var exception = Assert.Throws<ArgumentException>(() => bc = new BuildingController(id, providedState));

            // Detailed assertion: Check if the exception message contains the expected detail
            StringAssert.Contains("BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'", exception.Message);
        }

        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("out of hours")]
        public void L2R3_SecondConstructor_ValidState_DoesNotThrowsArgumentException(string providedState)
        {
            // Arrange: Providing a context for the test case with a meaningful ID and valid state
            string id;
            BuildingController bc;

            // Act & Assert: Verifying that no ArgumentException is thrown when initializing with a valid state
            id = "CandT008";
            ClassicAssert.DoesNotThrow(() => bc = new BuildingController(id, providedState));
        }

        [Test]
        public void L3R1_ThirdConstructorMethod_InitializeWithDependencies_ShouldNotBeNull()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Initializing BuildingController with dependencies.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);

            // Assert: Verifying that the BuildingController instance is not null.
            ClassicAssert.IsNotNull(bc);
        }

        [Test]
        public void L3R1_ThirdConstructorMethod_InitializeWithDependencies_Injected()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id, result;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Initializing BuildingController with dependencies and getting ID.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            result = bc.GetBuildingID();

            // Assert: Verifying the building ID matches expected value.
            ClassicAssert.AreEqual(id.ToLower(), result);
        }

        [TestCase("Lights,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,", "Doors,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,", "FireAlarm,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,",
            "Lights,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,Doors,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,FireAlarm,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,")]
        [TestCase("Lights,OK,OK,FAULT,OK,OK,FAULT,OK,FAULT,OK,OK,", "Doors,FAULT,OK,OK,OK,OK,OK,FAULT,OK,OK,OK,", "FireAlarm,OK,OK,FAULT,OK,OK,FAULT,OK,FAULT,OK,OK,",
            "Lights,OK,OK,FAULT,OK,OK,FAULT,OK,FAULT,OK,OK,Doors,FAULT,OK,OK,OK,OK,OK,FAULT,OK,OK,OK,FireAlarm,OK,OK,FAULT,OK,OK,FAULT,OK,FAULT,OK,OK,")]
        public void L3R3_ConstructorMethod_GetStatusReport_ReturnsConcatenatedStatusOfAllManagers(string lightStatus, string doorStatus, string fireAlarmStatus, string expectedReportStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;
            string statusReport;

            // Act: Set up the expected return values for each manager's GetStatus() method
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController("CandT008", lightManager, fireAlarmManager, doorManager, webService, emailService);
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(fireAlarmStatus);
            statusReport = bc.GetStatusReport();

            // Assert: Verify the concatenated status matches expected
            ClassicAssert.AreEqual(expectedReportStatus, statusReport);
        }

        [Test]
        public void L3R4_ConstructorMethod_UnlockAllDoorsAndSetCurrentState_ReturnsFalse()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;
            bool result;

            // Act: Simulate failure in opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(false);
            result = bc.SetCurrentState("open");

            // Assert: The method returns false
            ClassicAssert.AreEqual(result, false);
        }

        [Test]
        public void L3R4_ConstructorMethod_UnlockAllDoorsAndSetCurrentState_DoesNotChangesCurrentState()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id, result;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Simulate failure in opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(false);
            bc.SetCurrentState("open");
            result = bc.GetCurrentState();

            // Assert: The method returns the default unchanged state
            ClassicAssert.AreEqual("out of hours", result);
        }

        [Test]
        public void L3R4_ConstructorMethod_UnlockAllDoorsAndSetCurrentState_VerifyCallOpenAllDoors()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id, result;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Simulate failure in opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(false);
            bc.SetCurrentState("open");
            result = bc.GetCurrentState();

            // Assert: Verify that OpenAllDoors() was called exactly once
            doorManager.Received(1).OpenAllDoors();
        }

        [Test]
        public void L3R5_ConstructorMethod_UnlockAllDoorsAndSetCurrentState_ReturnsTrue()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;
            bool result;

            // Act: Simulate the transition to "open" by opening doors.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            result = bc.SetCurrentState("open");

            // Assert: The method returns true for simulating opening of all doors
            ClassicAssert.AreEqual(result, true);
        }

        [Test]
        public void L3R5_ConstructorMethod_UnlockAllDoorsAndSetCurrentState_ChangesCurrentState()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id, result;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Simulate opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            bc.SetCurrentState("open");
            result = bc.GetCurrentState();

            // Assert: The method returns the state "open" for simulating opening of all doors
            ClassicAssert.AreEqual("open", result);
        }

        [Test]
        public void L4R1_ThirdConstructorMethod_LockAllDoorsAndSetCurrentState_ReturnsFalse()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;
            bool result;

            // Act: Simulate failure in locking of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.LockAllDoors().Returns(false);
            result = bc.SetCurrentState("closed");

            // Assert: The method returns false for simulating locking of all doors
            ClassicAssert.AreEqual(result, false);
        }

        [Test]
        public void L4R1_ThirdConstructorMethod_LockAllDoorsAndSetCurrentState_DoesNotChangesCurrentState()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id, result;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Simulate failure in locking of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.LockAllDoors().Returns(false);
            bc.SetCurrentState("closed");
            result = bc.GetCurrentState();

            // Assert: The method returns the default state for simulating locking of all doors
            ClassicAssert.AreEqual("out of hours", result);
        }

        [Test]
        public void L4R1_ThirdConstructorMethod_LockAllDoorsAndSetCurrentState_ReturnsTrue()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;
            bool result;

            // Act: Change the state to "closed" and check door locking.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.LockAllDoors().Returns(true);
            result = bc.SetCurrentState("closed");

            // Assert: The method returns true for simulating locking of all doors
            ClassicAssert.AreEqual(result, true);
        }

        [Test]
        public void L4R1_ThirdConstructorMethod_LockAllDoorsAndSetCurrentState_ChangesCurrentState()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id, result;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Change the state to "closed" and check door locking.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.LockAllDoors().Returns(true);
            bc.SetCurrentState("closed");
            result = bc.GetCurrentState();

            // Assert: The method returns the "closed" state for simulating locking of all doors
            ClassicAssert.AreEqual("closed", result);
        }

        [Test]
        public void L4R1_ThirdConstructorMethod_SetCurrentState_VerifyCallSetAllLightsFalse()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Change the state to "closed" and check door locking.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.LockAllDoors().Returns(true);
            bc.SetCurrentState("closed");

            // Assert: Verify that SetAllLights(false) was called exactly once
            lightManager.Received(1).SetAllLights(false);
        }

        [Test]
        public void L4R1_ThirdConstructorMethod_SetCurrentState_VerifyCallLockAllDoors()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Change the state to "closed" and check door locking.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.LockAllDoors().Returns(true);
            bc.SetCurrentState("closed");

            // Assert: Verify that LockAllDoors() was called exactly once
            doorManager.Received(1).LockAllDoors();
        }

        [Test]
        public void L4R2_ThirdConstructorMethod_OpenAllDoorsAndSetCurrentState_ReturnsFalse()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;
            bool result;

            // Act: Simulate failure in opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(false);
            result = bc.SetCurrentState("fire alarm");

            // Assert: The method returns false for simulating opening of all doors
            ClassicAssert.AreEqual(result, false);
        }

        [Test]
        public void L4R2_ThirdConstructorMethod_OpenAllDoorsAndSetCurrentState_DoesNotChangesCurrentState()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id, result;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Simulate failure in opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.LockAllDoors().Returns(false);
            bc.SetCurrentState("fire alarm");
            result = bc.GetCurrentState();

            // Assert: The method returns the default state for simulating opening of all doors
            ClassicAssert.AreEqual("out of hours", result);
        }

        [Test]
        public void L4R2_ThirdConstructorMethod_OpenAllDoorsAndSetCurrentState_ReturnsTrue()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;
            bool result;

            // Act: Simulate failure in opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            result = bc.SetCurrentState("fire alarm");

            // Assert: The method returns true for simulating opening of all doors
            ClassicAssert.AreEqual(result, true);
        }

        [Test]
        public void L4R2_ThirdConstructorMethod_OpenAllDoorsAndSetCurrentState_ChangesCurrentState()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id, result;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Simulate opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            bc.SetCurrentState("fire alarm");
            result = bc.GetCurrentState();

            // Assert: The method returns the state for simulating opening of all doors
            ClassicAssert.AreEqual("fire alarm", result);
        }

        [Test]
        public void L4R2_ThirdConstructorMethod_SetCurrentState_VerifyCallSetAllLightsFalse()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Simulate opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            bc.SetCurrentState("fire alarm");

            // Assert: Verify that SetAllLights(true) was called exactly once
            lightManager.Received(1).SetAllLights(true);
        }

        [Test]
        public void L4R2_ThirdConstructorMethod_SetCurrentState_VerifyCallOpenAllDoors()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Simulate opening of all doors
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            bc.SetCurrentState("fire alarm");

            // Assert: Verify that doors are opened
            doorManager.Received(1).OpenAllDoors();
        }

        [Test]
        public void L4R2_ThirdConstructorMethod_SetCurrentState_VerifyCallFireAlarmEvent()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Change the state to "fire alarm" and check actions.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            bc.SetCurrentState("fire alarm");

            // Assert: Confirm that a fire alarm event is logged.
            webService.Received(1).LogFireAlarm("fire alarm"); 
        }

        [TestCase("Lights,FAULT,","Doors,OK,","FireAlarm,OK,")]
        [TestCase("Lights,OK,FAULT,OK,OK,", "Doors,OK,OK,", "FireAlarm,OK,OK,OK,")]
        public void L4R3_GetStatusReport_WithSingleLoghtFault_LogsCorrectDeviceType(string lightStatus, string doorStatus, string alarmStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Invoke GetStatusReport to evaluate fault reporting for lights.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(alarmStatus);
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            bc.GetStatusReport();

            // Assert: Check that the engineer requirement log correctly reflects a fault in lights.
            webService.Received(1).LogEngineerRequired("Lights,");
        }

        [TestCase("Lights,OK,", "Doors,FAULT,", "FireAlarm,OK,")]
        [TestCase("Lights,OK,OK,OK,OK,", "Doors,FAULT,OK,", "FireAlarm,OK,OK,OK,")]
        public void L4R3_GetStatusReport_WithSingleDoorFault_LogsCorrectDeviceType(string lightStatus, string doorStatus, string alarmStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Invoke GetStatusReport to evaluate fault reporting for doors.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(alarmStatus);
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            bc.GetStatusReport();

            // Assert: Check that the engineer requirement log correctly reflects a fault in doors.
            webService.Received(1).LogEngineerRequired("Doors,");
        }

        [TestCase("Lights,OK,", "Doors,OK,", "FireAlarm,FAULT,")]
        [TestCase("Lights,OK,OK,OK,OK,", "Doors,OK,OK,", "FireAlarm,OK,FAULT,OK,")]
        public void L4R3_GetStatusReport_WithSingleFireAlarmFault_LogsCorrectDeviceType(string lightStatus, string doorStatus, string alarmStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Invoke GetStatusReport to evaluate fault reporting for the fire alarm.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(alarmStatus);
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            bc.GetStatusReport();

            // Assert: Check that the engineer requirement log correctly reflects a fault in the fire alarm.
            webService.Received(1).LogEngineerRequired("FireAlarm,");
        }

        [TestCase("Lights,FAULT,", "Doors,FAULT,", "FireAlarm,OK,")]
        [TestCase("Lights,OK,OK,FAULT,OK,", "Doors,OK,FAULT,", "FireAlarm,OK,OK,OK,")]
        public void L4R3_GetStatusReport_WithLightAndDoorFault_LogsCorrectDeviceType(string lightStatus, string doorStatus, string alarmStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Invoke GetStatusReport to evaluate fault reporting for lights and doors.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(alarmStatus);
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            bc.GetStatusReport();

            // Assert: Check that the engineer requirement log correctly reflects faults in lights and doors.
            webService.Received(1).LogEngineerRequired("Lights,Doors,");
        }

        [TestCase("Lights,FAULT,", "Doors,OK,", "FireAlarm,FAULT,")]
        [TestCase("Lights,OK,OK,FAULT,OK,", "Doors,OK,OK,", "FireAlarm,OK,FAULT,OK,")]
        public void L4R3_GetStatusReport_WithLightAndFireAlarmFault_LogsCorrectDeviceType(string lightStatus, string doorStatus, string alarmStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Generate a status report that potentially includes faults in lights and the fire alarm.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(alarmStatus);
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            bc.GetStatusReport();

            // Assert: Confirm the correct logging of faults, specifically for lights and fire alarms.
            webService.Received(1).LogEngineerRequired("Lights,FireAlarm,");
        }

        [TestCase("Lights,OK,", "Doors,FAULT,", "FireAlarm,FAULT,")]
        [TestCase("Lights,OK,OK,OK,OK,", "Doors,FAULT,OK,", "FireAlarm,OK,FAULT,OK,")]
        public void L4R3_GetStatusReport_WithDoorsAndFireAlarmFault_LogsCorrectDeviceType(string lightStatus, string doorStatus, string alarmStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Generate a status report that potentially includes faults in doors and the fire alarm.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(alarmStatus);
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            bc.GetStatusReport();

            // Assert: Confirm the correct logging of faults, specifically for doors and fire alarms.
            webService.Received(1).LogEngineerRequired("Doors,FireAlarm,");
        }

        [TestCase("Lights,FAULT,", "Doors,FAULT,", "FireAlarm,FAULT,")]
        [TestCase("Lights,OK,FAULT,OK,OK,", "Doors,OK,FAULT,", "FireAlarm,FAULT,OK,OK,")]
        public void L4R3_GetStatusReport_WithAllFaults_LogsCorrectDeviceType(string lightStatus, string doorStatus, string alarmStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Retrieve a status report to identify faults from each system component.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(alarmStatus);
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            bc.GetStatusReport();

            // Assert: Verify an engineer log request is made, indicating faults across all systems.
            webService.Received(1).LogEngineerRequired("Lights,Doors,FireAlarm,");
        }

        [TestCase("Lights,OK,", "Doors,OK,", "FireAlarm,OK,")]
        [TestCase("Lights,OK,OK,OK,OK,", "Doors,OK,OK,", "FireAlarm,OK,OK,OK,")]
        public void L4R3_GetStatusReport_WithNoFaults_LogsCorrectDeviceType(string lightStatus, string doorStatus, string alarmStatus)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Call GetStatusReport to compile statuses from mocked dependencies.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            lightManager.GetStatus().Returns(lightStatus);
            doorManager.GetStatus().Returns(doorStatus);
            fireAlarmManager.GetStatus().Returns(alarmStatus);
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            bc.GetStatusReport();

            // Assert: Confirm no engineer log request is made, indicating no faults detected.
            webService.DidNotReceive().LogEngineerRequired(Arg.Any<string>());
        }

        [TestCase("Logging failed | server error")]
        [TestCase("Logging failed | run out of time")]
        public void L4R4_SetFireAlarmState_WhenLogFireAlarmFails_SendsEmailNotification(string exMessage)
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Trigger "fire alarm" state, causing LogFireAlarm to throw a predefined exception.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            // Set up LogFireAlarm to throw an exception
            webService.When(x => x.LogFireAlarm(Arg.Any<string>())).Do(x => throw new Exception(exMessage));
            bc.SetCurrentState("fire alarm");

            // Assert: Verify an email is sent with the specific exception message, indicating correct error handling.
            emailService.Received(1).SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", Arg.Is<string>(s => s.Contains(exMessage)));
        }

        [Test]
        public void L4R4_SetFireAlarmState_WhenLogFireAlarmSucceed_DoesNotSendsEmailNotification()
        {
            // Arrange: Creating mocks for all dependencies and an identifier.
            string id;
            ILightManager lightManager;
            IFireAlarmManager fireAlarmManager;
            IDoorManager doorManager;
            IWebService webService;
            IEmailService emailService;
            BuildingController bc;

            // Act: Transition to "fire alarm" state without triggering LogFireAlarm exception.
            id = "CandT008";
            lightManager = Substitute.For<ILightManager>();
            fireAlarmManager = Substitute.For<IFireAlarmManager>();
            doorManager = Substitute.For<IDoorManager>();
            webService = Substitute.For<IWebService>();
            emailService = Substitute.For<IEmailService>();
            bc = new BuildingController(id, lightManager, fireAlarmManager, doorManager, webService, emailService);
            doorManager.OpenAllDoors().Returns(true);
            // Set up LogFireAlarm to throw an exception
            bc.SetCurrentState("fire alarm");

            // Assert: Confirm no email notification is sent, indicating LogFireAlarm succeeded.
            emailService.DidNotReceive().SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }
    }
}