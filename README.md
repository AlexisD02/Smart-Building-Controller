# SmartBuildingController
C# Smart Building Controller using Test-Driven Development (TDD) for efficient management of building systems.

# Smart Building Controller Algorithm

## Algorithm Description

The Smart Building Controller algorithm initiates by normalizing the input state to lowercase. This ensures consistent comparison across different inputs. The algorithm proceeds as follows:

1. **Validation of the Provided State**: Checks if the provided state is among the valid states predefined in the system. If not, it returns `false`, indicating an invalid transition attempt.
2. **Check for No Transition Needed**: Determines if the new state is the same as the current state. If they match, it returns `true`, signaling that no transition is necessary.
3. **State Transition Diagram (STD) Compliance**: Evaluates if the transition to the provided state is allowed by the Building Controller's STD. It involves checking specific conditions for each state (e.g., unlocking all doors when transitioning to "open") and executing the corresponding actions if those conditions are met.
4. **Invalid Transitions**: If a transition is not allowed or conditions are not met, it returns `false`, indicating the transition cannot happen.

## Translating STD into Tests

Unit tests in `BuildingControllerTests.cs` are designed to:

- Validate each valid state transition according to the STD.
- Block and report attempts to use invalid states as the current state.
- Verify the correct response to state transitions, such as ensuring doors are opened when transitioning to the "open" state.

## Translating STD into Code

The `SetCurrentState` function embodies the STD's logic for the BuildingController. Key implementation details include:

- A **switch expression** handles transitions based on current and provided states, adhering to the STD's rules. For example, it prohibits a direct transition from "open" to "closed" without passing through "out of hours" state.
- **Dependency Injection** in the constructor facilitates the integration of various subsystems (e.g., `ILightManager`, `IFireAlarmManager`, `IDoorManager`). These subsystems are crucial for performing state-dependent actions, such as managing lights and door locks.

This approach ensures a robust and testable design for managing smart building states effectively.

# Reflections on Testing with NUnit, NSubstitute, and TDD

## Learning Outcomes

Completing this assignment has been a profound learning journey into the intricacies of unit testing and the Test-Driven Development (TDD) approach. Key insights gained include:

### Testing Tools: NUnit & NSubstitute

- **NUnit**: Gained hands-on experience with NUnit, a widely-used unit-testing framework for .NET. It provided a robust environment for defining and running tests, ensuring that each unit of the code performs as expected.
- **NSubstitute**: Learned how to use NSubstitute for creating mock objects in tests. This tool proved invaluable for simulating complex dependencies, allowing for focused tests on the system under test without worrying about external dependencies.

### TDD Cycle: Red, Green, Refactor

- **Writing Tests First**: This approach necessitated a deep understanding of the requirements before writing a single line of code. It reinforced the importance of clarity in requirements, leading to more focused and relevant solutions.
- **Cycle Benefits**: Following the Red (write a failing test), Green (make the test pass), and Refactor (clean up the code while keeping tests passing) cycle led to cleaner, more maintainable code. It emphasized the value of continuous improvement in the codebase.

## Project Insights

- **Clarifying Requirements**: The project highlighted the critical role of clear requirements in successful software development. It served as a reminder that understanding what needs to be built is the first step towards building it right.
- **Code Modularity and Simplicity**: Writing tests for the `BuildingController` exposed opportunities to enhance modularity and simplify the code. This insight drove better design decisions, leading to a more robust and maintainable system.

## Future Directions

With the foundation laid by this project, future endeavors in testing will focus on:

- **Comprehensive Test Coverage**: Planning to devise better test cases that ensure comprehensive coverage from the outset. This proactive approach aims to minimize bugs and issues in the system or application.
- **Continuous Learning and Refinement**: Committing to refine and improve the code beyond its initial implementation. This includes dedicating time to learn more about various testing tools and frameworks, thereby enhancing the quality and reliability of future projects.

The journey through NUnit, NSubstitute, and the TDD cycle has been enlightening, laying a strong foundation for future projects and continuous improvement in testing practices.

