# Definition of Done

## 1. General Requirements

A task or feature is complete only when all applicable requirements below are satisfied.

- [ ] The implementation meets the documented requirements and acceptance criteria.
- [ ] The change is focused and does not introduce unrelated refactoring.
- [ ] Existing behavior is preserved unless a change is intentional and documented.
- [ ] Code is readable, maintainable, and consistent with existing conventions.
- [ ] No unnecessary abstractions, duplicated logic, or speculative features are introduced.
- [ ] Relevant documentation is updated.
- [ ] Known limitations and follow-up work are recorded.

## 2. Architecture

- [ ] Dependencies respect `ARCHITECTURE.md`.
- [ ] Domain logic does not depend on infrastructure, databases, HTTP, or UI frameworks.
- [ ] Application use cases do not depend directly on ASP.NET Core or EF Core implementations.
- [ ] Infrastructure contains persistence and external technology implementations.
- [ ] API endpoints handle HTTP concerns and delegate application behavior appropriately.
- [ ] Frontend features follow the established React and TypeScript structure.
- [ ] No new architectural pattern or dependency is introduced without a clear reason.

## 3. Backend Quality

- [ ] Input is validated on the server.
- [ ] Request and response DTOs are used instead of exposing EF Core entities.
- [ ] Business invariants are enforced in the appropriate layer.
- [ ] Errors are handled consistently using the established API error format.
- [ ] Asynchronous database and I/O operations use async APIs where appropriate.
- [ ] Cancellation tokens are propagated through relevant asynchronous operations.
- [ ] Database access avoids unnecessary queries and accidental N+1 behavior.
- [ ] Collections that may grow are paginated where appropriate.
- [ ] Logging is structured and does not expose sensitive information.
- [ ] Nullable reference types and compiler warnings are handled deliberately.

## 4. Security and Authorization

- [ ] Every protected endpoint requires the appropriate authentication.
- [ ] Authorization is enforced on the server, not only in the frontend.
- [ ] Users cannot read, update, or delete resources they do not own or have permission to access.
- [ ] Related entities are checked for valid ownership and access.
- [ ] Passwords are handled only through established secure password-hashing facilities.
- [ ] Secrets, passwords, tokens, and sensitive personal data are not written to logs.
- [ ] No credentials or production secrets are committed.
- [ ] Error messages do not disclose sensitive implementation details.
- [ ] Authentication and cookie/token behavior follows the documented security design.
- [ ] Relevant negative authorization tests are included.

## 5. Database and Persistence

- [ ] Database schema changes are represented by appropriate EF Core migrations.
- [ ] Entity relationships and delete behavior are intentional.
- [ ] Constraints and indexes are added where justified.
- [ ] Database configuration is externalized appropriately.
- [ ] Existing data is not unintentionally lost or corrupted.
- [ ] Persistence changes are tested against a relational database when database behavior matters.
- [ ] No production database is modified without explicit authorization.

## 6. Backend Testing

- [ ] Unit tests cover relevant domain rules and application behavior.
- [ ] Integration tests cover important API and persistence behavior.
- [ ] Success cases and important failure cases are tested.
- [ ] Validation and authorization boundaries are tested.
- [ ] Tests are deterministic and do not depend on execution order.
- [ ] Tests do not rely exclusively on EF Core's InMemory provider to validate relational database behavior.
- [ ] Existing relevant tests continue to pass.

## 7. Frontend Quality

- [ ] TypeScript types are meaningful and avoid unnecessary `any`.
- [ ] UI components have clear responsibilities.
- [ ] Forms handle validation and submission states.
- [ ] Loading, empty, error, and success states are provided where relevant.
- [ ] API errors are presented clearly without exposing sensitive details.
- [ ] UI state stays consistent with server-confirmed results.
- [ ] Reusable components are introduced when they provide genuine value.
- [ ] No secrets or privileged authorization logic are embedded in the frontend.

## 8. Accessibility and Responsive Design

- [ ] Interactive elements are keyboard accessible.
- [ ] Focus indicators are visible.
- [ ] Forms have appropriate labels and accessible error feedback.
- [ ] Semantic HTML is used appropriately.
- [ ] Color is not the sole means of communicating important information.
- [ ] Layouts work at relevant mobile and desktop viewport sizes.
- [ ] Dialogs, menus, and other interactive components follow appropriate accessibility behavior.

## 9. Frontend Testing

- [ ] Relevant component and interaction tests are added or updated.
- [ ] Important loading, error, and validation states are tested.
- [ ] Critical user workflows are covered by end-to-end tests when applicable.
- [ ] Tests verify observable behavior rather than implementation details wherever practical.

## 10. Build and Verification

Before marking a task complete, run the relevant checks available for the changed code.

### Backend
- [ ] `dotnet build`
- [ ] Relevant unit tests.
- [ ] Relevant integration tests.

### Frontend
- [ ] Dependency installation is reproducible.
- [ ] ESLint passes.
- [ ] TypeScript type checking passes.
- [ ] Vitest tests pass.
- [ ] Production build succeeds.

### End-to-End
- [ ] Relevant Playwright tests pass when applicable.

Do not claim a check passed unless it was actually executed and passed. If a check cannot run because a dependency, database, or environment is unavailable, state that clearly.

## 11. Documentation

- [ ] Setup instructions reflect the actual implementation.
- [ ] Configuration variables are documented without real secret values.
- [ ] API behavior and important architectural decisions are documented where necessary.
- [ ] Database migration instructions are accurate.
- [ ] New dependencies have a clear purpose.
- [ ] Commands are verified before being described as working.

## 12. Scope Control

The following remain deferred until the core application is stable and tested:

- Docker and Docker Compose
- CI/CD
- Azure deployment
- SonarQube
- Microservices
- Kubernetes
- Message brokers and distributed processing

Do not add deferred technologies without an explicit scope change.

## 13. Final Completion Report

When completing a task, report:

1. **Implemented:** What changed and why.
2. **Files changed:** The key files created, updated, or removed.
3. **Tests and checks:** Commands executed and their actual results.
4. **Security and architecture:** Relevant considerations and decisions.
5. **Limitations:** Any incomplete checks, known issues, or remaining work.
6. **Next step:** The smallest logical follow-up task.

A task must not be described as fully complete if essential acceptance criteria remain unmet.
