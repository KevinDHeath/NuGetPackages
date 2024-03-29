# Testing
Automated tests are a great way to ensure that the application code does what its authors intend.

## Unit tests
A [unit test](Unit/README.md) is a test that exercises individual software components or methods, also known as a "unit of work." Unit tests should only test code within the developer's control. They do not test infrastructure concerns such as interacting with databases, file systems, and network resources.
- [Unit testing best practices](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)

## Integration tests
An [integration test](Integration/README.md) differs from a unit test in that it exercises two or more software components' ability to function together, also known as their "integration." These tests operate on a broader spectrum of the system under test, whereas unit tests focus on individual components. Often, integration tests do include infrastructure concerns.

## System Testing
System testing is types of testing where tester evaluates the whole system against the specified requirements.
### End-to-end testing
_End-to-end testing_ (also known as E2E testing) is a technique that verifies the functionality and performance of an entire software application from start to finish by simulating real-world user scenarios and replicating live data. Its objective is to identify bugs that arise when all components are integrated, ensuring that the application delivers the expected output as a unified entity. 
- [E2E Testing](https://microsoft.github.io/code-with-engineering-playbook/automated-testing/e2e-testing/)

### Performance testing
_Performance tests_ evaluate how a system performs under a particular workload. These tests help to measure the reliability, speed, scalability, and responsiveness of an application. For instance, a performance test can observe response times when executing a high number of requests, or determine how a system behaves with a significant amount of data. It can determine if an application meets performance requirements, locate bottlenecks, measure stability during peak traffic, and more.