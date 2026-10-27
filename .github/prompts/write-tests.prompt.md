---
name: Write Tests
description: Add meaningful unit, integration, component, or end-to-end tests for the requested behavior.
agent: agent
---

Add or improve automated tests for the behavior requested by the user.

Before writing tests:
1. Read `definition_of_done.md` and relevant project instructions.
2. Inspect the implementation and existing test conventions.
3. Identify the expected behavior and important failure cases.
4. Choose the appropriate test level.

Testing guidance:

Backend:
- Use xUnit for domain and application unit tests.
- Use ASP.NET Core integration tests for important API behavior.
- Cover validation, authorization, ownership, and boundary conditions where relevant.
- Use a relational database for behavior that depends on relational constraints or SQL Server-specific semantics.

Frontend:
- Use Vitest and React Testing Library.
- Test observable behavior and user interactions.
- Cover validation, loading, empty, success, and failure states where relevant.

End-to-end:
- Use Playwright for critical user journeys when the relevant application flows exist.
- Prefer stable selectors and deterministic setup.

Rules:
- Follow existing conventions unless there is a concrete reason to improve them.
- Avoid tests that merely repeat implementation details.
- Do not weaken or delete valid tests to obtain a passing result.
- Do not add unnecessary test dependencies.
- Keep tests independent and deterministic.

After writing tests:
1. Run the relevant test commands.
2. Fix failures caused by the test or implementation changes.
3. Report what each group of tests covers.
4. State actual results and any tests that could not run.

Do not claim coverage is comprehensive without evidence.
