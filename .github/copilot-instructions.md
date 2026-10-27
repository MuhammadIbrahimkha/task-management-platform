# GitHub Copilot Instructions

## 1. Project Context

This repository contains a full-stack Task Management Platform being built as an independent portfolio project.

Before substantial implementation work, read these documents:

- `project.md` — product vision, scope, requirements, and acceptance criteria.
- `architecture.md` — architecture boundaries and technical decisions.
- `implementation_plan.md` — milestones and implementation sequence.
- `definition_of_done.md` — quality and completion requirements.

Follow these documents. If they conflict or a requirement is ambiguous, identify the conflict and ask for clarification before making consequential changes.

## 2. Technology Stack

### Backend
- .NET 10 LTS
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- xUnit
- ASP.NET Core integration testing

### Frontend
- React
- TypeScript with strict mode
- Vite
- ESLint
- Vitest
- React Testing Library
- Playwright for end-to-end tests

### Development Environment
- Visual Studio Code
- VS Code integrated terminal
- Git and GitHub
- GitHub Copilot

Do not assume that Visual Studio IDE is installed or being used. Provide commands and workflows that work in VS Code's integrated terminal.

## 3. Scope and Milestones

- Implement only the milestone or task explicitly requested.
- Inspect the repository before editing files.
- Prefer small, coherent, reviewable changes.
- Do not generate the entire application in one response or operation.
- Do not skip foundational work to implement features prematurely.
- Do not introduce Docker, CI/CD, Azure deployment, SonarQube, Kubernetes, microservices, or message brokers during the initial application-building phase.
- Do not add dependencies unless they solve a clear requirement.
- Do not silently change the agreed technology stack or product scope.

If the requested task depends on missing foundational work, explain the dependency and propose the smallest appropriate next step.

## 4. Architecture Rules

Follow `architecture.md` and maintain Clean Architecture principles within a modular monolith.

### Domain
- Contains business entities, value objects, domain rules, and invariants.
- Must not depend on ASP.NET Core, EF Core, the database provider, or frontend technologies.
- Must remain focused on business behavior.

### Application
- Contains use cases, application services, contracts, and abstractions.
- Depends on Domain.
- Must not depend directly on Infrastructure implementations.
- Must not contain HTTP-specific behavior.

### Infrastructure
- Implements persistence and other external technology integrations.
- Contains EF Core configuration, database access, migrations, and repository implementations where appropriate.
- Implements abstractions defined by the appropriate inner layer.

### API
- Handles HTTP concerns, dependency injection composition, authentication configuration, authorization policies, middleware, and endpoint definitions.
- Delegates application behavior to the appropriate application use cases.
- Must not become the home of domain business logic.

### Frontend
- Organize code by feature and responsibility.
- Keep API communication, UI components, and business-oriented frontend behavior appropriately separated.
- Prefer typed contracts and reusable components where they provide real value.

Do not introduce microservices or unnecessary abstraction layers.

## 5. C# and .NET Practices

- Enable nullable reference types and use them deliberately.
- Use asynchronous APIs for I/O operations where appropriate.
- Propagate cancellation tokens through relevant asynchronous operations.
- Use dependency injection consistently.
- Keep methods focused and avoid unnecessary complexity.
- Use explicit DTOs for API requests and responses.
- Never expose EF Core entities directly as API contracts.
- Validate incoming data on the server.
- Keep error handling consistent with the established API error format.
- Use structured logging.
- Avoid logging passwords, access tokens, secrets, or other sensitive data.
- Use configuration for environment-specific settings.
- Avoid swallowing exceptions or returning success responses after failures.
- Do not add abstractions solely for hypothetical future requirements.

## 6. Entity Framework Core and SQL Server

- Use EF Core through the established Infrastructure layer.
- Keep database configuration and provider-specific behavior out of Domain.
- Use explicit entity configuration where appropriate.
- Define relationships, constraints, indexes, and delete behavior intentionally.
- Add migrations for schema changes.
- Do not edit generated migration files casually.
- Avoid unnecessary database queries and N+1 query patterns.
- Use pagination for potentially large result sets.
- Keep database credentials out of source control.
- Test relational behavior against an appropriate relational database when necessary.
- Do not rely exclusively on EF Core InMemory tests for relational constraints or SQL-specific behavior.

## 7. Security Rules

- Enforce authorization on the server for every protected operation.
- Verify resource ownership and permissions on reads, updates, deletes, and relationship changes.
- Never trust a user ID supplied by the client to establish ownership.
- Derive the authenticated user's identity from the validated authentication context.
- Never store passwords in plaintext.
- Use established framework authentication and password-hashing facilities.
- Do not store bearer tokens in browser `localStorage` by default.
- Follow the authentication approach documented in the architecture decisions.
- For cookie authentication, address CSRF protection and cookie security settings.
- Validate related resource ownership to prevent insecure direct object reference vulnerabilities.
- Do not commit secrets, production credentials, or real tokens.
- Never disable security checks simply to make a test pass.
- Add tests for denied access as well as successful access.

## 8. API Design

- Use consistent endpoint naming and HTTP semantics.
- Return appropriate status codes.
- Use consistent validation and error responses.
- Follow the established Problem Details approach where applicable.
- Implement pagination, filtering, sorting, and search consistently.
- Do not expose internal exception details to clients.
- Avoid breaking existing API contracts without a documented reason.
- Ensure API responses contain only information the requesting user is authorized to access.

## 9. React and TypeScript Practices

- Use functional React components and hooks.
- Prefer explicit TypeScript types for API contracts and important state.
- Avoid `any` unless there is a justified, documented reason.
- Do not suppress type errors simply to make the build pass.
- Keep components focused and manageable.
- Extract reusable UI components when appropriate.
- Keep API calls out of presentation components when a dedicated API layer is established.
- Handle loading, error, empty, and success states.
- Avoid unnecessary effects and duplicated state.
- Keep forms accessible and provide useful validation feedback.
- Use semantic HTML and keyboard-accessible interactions.
- Include visible focus states and responsive layouts.
- Never put secrets or privileged authorization decisions in frontend code.
- Treat frontend route protection as a usability feature, not a replacement for backend authorization.

## 10. Testing Requirements

Follow `definition_of_done.md`.

### Backend
- Use xUnit for unit tests.
- Test domain rules and application behavior.
- Use integration tests for important API, authentication, authorization, and persistence flows.
- Include negative cases and boundary conditions.
- Keep tests deterministic and independent.
- Do not change or delete a test just to hide a genuine defect.

### Frontend
- Use Vitest and React Testing Library for component and interaction tests.
- Test observable user behavior rather than internal implementation details where practical.
- Use Playwright for critical end-to-end journeys when the relevant application functionality exists.

### Verification
- Run relevant build, lint, type-check, and test commands after changes.
- Fix regressions introduced by the implementation.
- Clearly report checks that could not run.
- Never claim a command passed unless it was actually executed successfully.

## 11. Dependencies and Configuration

- Prefer established, maintained libraries.
- Check existing dependencies before introducing new ones.
- Explain the purpose of significant new dependencies.
- Keep configuration environment-specific.
- Provide placeholder values in example configuration files.
- Never place actual secrets in `.env.example`, committed settings files, or documentation.
- Update setup instructions when dependencies or configuration requirements change.

## 12. Working Procedure

For each requested task:

1. Inspect the existing implementation and relevant instructions.
2. Identify the milestone, acceptance criteria, and affected layers.
3. Explain the proposed approach briefly before a substantial change.
4. Implement the smallest complete solution.
5. Add or update tests.
6. Run the relevant verification commands.
7. Review the changes for security, architecture, and scope.
8. Update documentation if needed.
9. Summarize the implementation, changed files, test results, and known limitations.

Do not overwrite files without inspecting them first. Preserve unrelated user changes.

If the repository is not in the expected state, report what is missing instead of inventing files, test results, or implementation details.

## 13. Final Response Format

After completing an implementation task, provide:

- **Summary:** What was implemented.
- **Files changed:** Key files created or modified.
- **Verification:** Actual commands executed and their results.
- **Security and architecture:** Relevant decisions or concerns.
- **Remaining work:** Known issues, skipped checks, or dependencies.
- **Next step:** The smallest logical follow-up.

Be precise, transparent, and practical. The objective is a professional, maintainable application—not simply code that appears complete.
