# Task Management Platform — Architecture

## 1. Architectural Style

The application will use a modular monolith with Clean Architecture principles.

The initial system will consist of one backend API, one frontend application, and a relational database. Business modules will have clear responsibilities and boundaries.

Microservices will not be introduced without a demonstrated need.

## 2. Technology Stack

- Backend: ASP.NET Core Web API on .NET 10 LTS.
- Frontend: React, TypeScript, and Vite.
- Persistence: Entity Framework Core and SQL Server.
- API documentation: OpenAPI.
- Backend testing: xUnit and ASP.NET Core integration testing.
- Frontend testing: Vitest and React Testing Library.
- End-to-end testing: Playwright.

## 3. Backend Projects

### TaskManagement.Domain
Contains core business entities, value objects where justified, enums, and domain invariants.

Rules:
- Must not depend on ASP.NET Core, EF Core, or Infrastructure.
- Must not contain HTTP-specific behavior.

### TaskManagement.Application
Contains use cases, application services, contracts, and abstractions required by business workflows.

Rules:
- Depends on Domain.
- Must not depend on Infrastructure.
- Coordinates business operations and application-level validation.

### TaskManagement.Infrastructure
Contains EF Core persistence, database configuration, migrations, and implementations of application-defined persistence abstractions.

Rules:
- Implements interfaces required by Application.
- Database-specific behavior stays in this layer.

### TaskManagement.Api
Contains HTTP endpoints, authentication configuration, authorization policies, dependency injection composition, middleware, and API contracts.

Rules:
- Must not contain complex business logic.
- Must not expose EF Core entities directly as public API response models.
- Must use the Application layer for business operations.

## 4. Dependency Direction

The intended dependency direction is:

- Domain has no project dependencies.
- Application depends on Domain.
- Infrastructure depends on Application and Domain.
- Api depends on Application and Infrastructure for application composition.

Business logic must not depend on infrastructure implementation details.

## 5. Frontend Architecture

Organize the React application by feature.

Initial feature areas:
- Authentication
- Dashboard
- Tasks
- Projects
- Categories
- User profile

Shared UI components belong in a shared components directory. API communication, configuration, and reusable utilities belong in dedicated modules.

Use TypeScript strict mode. Keep components focused and avoid unnecessary global state.

## 6. Authentication and Authorization

The application must authenticate users and enforce authorization on the server.

Requirements:
- Passwords must be securely hashed.
- Authentication credentials must not be stored in source code.
- Users must not access another user's private tasks by manipulating identifiers.
- Authorization must be checked for every protected resource operation.
- Authentication failures and authorization failures must return appropriate HTTP responses.
- Security-sensitive operations must be covered by tests.

The authentication mechanism will be selected and documented before implementation, considering the browser-based frontend and intended deployment architecture.

## 7. API Conventions

- Use REST-style resource endpoints.
- Use DTOs for API requests and responses.
- Validate input at the API boundary and enforce business invariants in the appropriate application or domain layer.
- Use consistent error responses based on Problem Details where appropriate.
- Support pagination, filtering, and sorting for collection endpoints.
- Use appropriate HTTP status codes.
- Keep API documentation accurate.

## 8. Database and Persistence

- Use EF Core with SQL Server.
- Store schema changes as version-controlled migrations.
- Apply migrations through an explicit, documented process.
- Use database constraints and indexes where appropriate.
- Use asynchronous database operations.
- Avoid loading unbounded collections.
- Use transactions where a business operation requires atomicity.
- Do not use the EF Core InMemory provider as the sole verification of relational database behavior.

## 9. Configuration and Secrets

- Use environment-specific configuration.
- Validate required configuration during startup.
- Never commit credentials, signing keys, or production connection strings.
- Keep development defaults separate from production configuration.
- Do not log secrets or sensitive authentication data.

## 10. Observability and Reliability

- Use structured application logging.
- Return consistent errors without exposing internal implementation details.
- Add health checks when their requirements are defined.
- Ensure critical operations fail predictably and are testable.
- Avoid logging sensitive personal information.

## 11. Testing Boundaries

- Domain and application unit tests verify business behavior.
- API integration tests verify HTTP behavior, authentication, authorization, and application wiring.
- Relational database tests verify persistence behavior.
- Frontend component tests verify user interactions and UI states.
- End-to-end tests verify critical user journeys.

Tests must be deterministic, maintainable, and meaningful.

## 12. Deferred DevOps Work

Docker, Docker Compose, GitHub Actions CI/CD, container registry publishing, Azure deployment, and production monitoring will be implemented after the application and its automated tests are working reliably.

The application must remain compatible with a future containerized deployment, but DevOps infrastructure is not part of the initial implementation milestone.

## 13. Architecture Change Policy

Significant architectural changes must:
1. Explain the problem being solved.
2. Describe alternatives and trade-offs.
3. Update this document when the design changes.
4. Add an Architecture Decision Record when the decision has lasting impact.
5. Include tests when behavior or boundaries change.