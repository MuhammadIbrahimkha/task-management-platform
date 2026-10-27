---
applyTo: "**/*Tests/**/*.cs,**/*.Tests/**/*.cs,**/*.test.{ts,tsx},**/*.spec.{ts,tsx},**/playwright/**/*.ts"
---

# Testing Instructions

## General
- Follow `definition_of_done.md`.
- Test observable behavior and meaningful requirements.
- Include success cases, failure cases, boundary conditions, and authorization failures where relevant.
- Keep tests deterministic and independent.
- Do not change or delete tests merely to conceal a defect.
- Avoid asserting implementation details when a behavioral assertion is sufficient.
- Use descriptive test names that explain the scenario and expected outcome.

## Backend tests
- Use xUnit for .NET unit tests.
- Unit-test domain invariants and application behavior.
- Use ASP.NET Core integration testing for important HTTP and authentication workflows.
- Verify resource ownership and access restrictions.
- Use an appropriate relational database for tests involving relational constraints or SQL Server-specific behavior.
- Do not depend exclusively on EF Core InMemory for persistence correctness.

## Frontend tests
- Use Vitest and React Testing Library.
- Test user interactions, validation, accessible behavior, and visible outcomes.
- Cover loading, empty, success, and failure states when applicable.
- Avoid unnecessary mocking that makes tests meaningless.

## End-to-end tests
- Use Playwright for critical end-to-end user journeys when those workflows are implemented.
- Prioritize registration or login, task creation and editing, task completion, filtering, and logout.
- Avoid brittle selectors and unnecessary timing assumptions.

## Reporting
- Run relevant tests after changes.
- Report actual test commands and results.
- Clearly identify tests that were skipped or blocked by missing dependencies or environment configuration.
- Never claim tests passed without executing them.
