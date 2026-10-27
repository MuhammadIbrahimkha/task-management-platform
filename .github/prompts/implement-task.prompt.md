---
name: Implement Task
description: Implement one well-defined feature or task following the project architecture and quality standards.
agent: agent
---

Implement the task described by the user.

Before making changes:
1. Read `PROJECT.md`, `ARCHITECTURE.md`, `IMPLEMENTATION_PLAN.md`, and `DEFINITION_OF_DONE.md`.
2. Read `.github/copilot-instructions.md` and any applicable scoped instructions.
3. Inspect the existing code and identify the current milestone.
4. Identify acceptance criteria, dependencies, and affected layers.
5. If a consequential requirement is ambiguous, ask for clarification before proceeding.

Implementation rules:
- Implement only the requested task.
- Follow the existing architecture and technology stack.
- Prefer a small, complete, maintainable change over a large speculative implementation.
- Add or update relevant automated tests.
- Enforce server-side validation and authorization where applicable.
- Never expose persistence entities as API contracts.
- Do not introduce unrelated refactoring or unnecessary dependencies.
- Do not implement deferred DevOps work.
- Do not overwrite unrelated user changes.

After implementation:
1. Run relevant build, lint, type-check, and test commands that are available.
2. Fix regressions introduced by the changes.
3. Review the diff for security, maintainability, and scope.
4. Update relevant documentation.

Report:
- What was implemented.
- Files changed.
- Commands executed and actual results.
- Security and architecture considerations.
- Incomplete checks, limitations, and the next logical step.

Never claim a test or command passed unless it was actually executed successfully.
