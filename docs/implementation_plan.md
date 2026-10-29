# Implementation Plan

## 1. Purpose and Delivery Order

Build the Task Management Platform incrementally as a secure, maintainable, tested full-stack application suitable for a professional portfolio.

Work proceeds in three sequential phases:

1. Complete and verify the backend.
2. Complete and verify the frontend against its agreed API contracts.
3. Integrate the frontend and backend, then verify end-to-end user journeys.

The existing frontend shell is scaffolding only. Do not add frontend features or connect it to the API while the backend phase is active.

## 2. Technology Stack

### Backend
- .NET 10 LTS and ASP.NET Core Controllers
- C#
- Entity Framework Core and SQL Server, with Azure SQL as a future deployment target
- Clean Architecture principles in a modular monolith
- xUnit and ASP.NET Core integration testing

### Frontend
- React, TypeScript with strict type checking, and Vite
- An accessible component and styling system
- Vitest, React Testing Library, and Playwright

### Development Environment
- Visual Studio Code, Git, GitHub, and GitHub Copilot
- All editor and terminal instructions must work in VS Code; do not assume Visual Studio IDE.

## 3. Milestone Rules

1. Read the relevant requirements, architecture, status, and scoped instructions.
2. Inspect existing files and Git changes before editing.
3. State the intended change and important design decisions before substantial work.
4. Implement only the current phase and milestone.
5. Add or update meaningful automated tests.
6. Run relevant builds and tests; report the commands and actual outcomes.
7. Update `docs/project_status.md` after each completed implementation step with verified progress, results, unresolved issues, and the next action.
8. Do not claim a check passed unless it was run successfully.
9. Preserve existing behavior and unrelated work.
10. Do not apply a database migration without explicit approval from the project owner. Generating a migration file does not authorize applying it to any database.

## 4. Phase One — Backend Completion

The backend phase is the only active implementation phase until its milestones and backend verification are complete. Keep Domain independent from ASP.NET Core, EF Core, SQL Server, and Infrastructure. Application depends on Domain, Infrastructure implements application abstractions, and the API composes the layers and handles HTTP concerns.

### Backend Milestone 0 — Repository and Solution Foundation

Establish the repository documentation and the backend projects:

- `TaskManagement.Domain`
- `TaskManagement.Application`
- `TaskManagement.Infrastructure`
- `TaskManagement.Api`
- `TaskManagement.UnitTests`
- `TaskManagement.IntegrationTests`

Acceptance criteria:
- Architecture and scope are documented.
- Project references follow `architecture.md`.
- The backend solution builds and initial tests pass.
- The API health endpoint works.

### Backend Milestone 1 — Persistence and Database Foundations

Tasks:
- Configure EF Core with SQL Server in Infrastructure.
- Define `ApplicationDbContext` and explicit entity mappings.
- Externalize connection settings; keep credentials out of source control.
- Add the initial EF migration and document database setup and migration commands.
- Add meaningful persistence verification, using a relational database when relational behavior is under test.
- Keep EF Core out of Domain and Application.

Acceptance criteria:
- The API can use a configured SQL Server connection.
- Migration generation and database setup are documented.
- Persistence configuration and mappings are covered by tests.
- No migration is applied without explicit project-owner approval.

### Backend Milestone 2 — Authentication and Authorization

Tasks:
- Select and document a browser-appropriate authentication strategy before implementation.
- Implement registration, login, and logout, using established secure password hashing.
- Configure authentication and authorization in the API.
- Protect private operations and enforce ownership server-side.
- Return safe validation, authentication, and authorization errors.
- Test successful and denied access, including cross-user access attempts.

Security requirements:
- Do not store bearer tokens in browser `localStorage` by default.
- For cookie authentication, address CSRF protection and secure cookie settings.
- Never trust client-supplied user IDs to establish ownership.
- Never log passwords, tokens, or secrets.

Acceptance criteria:
- Authentication succeeds and fails safely.
- Protected operations reject unauthenticated users.
- Users cannot read or modify another user's private resources.
- Security boundaries are covered by automated tests.

### Backend Milestone 3 — Core Task Management API

The TaskItem entity, status and priority enums, and domain invariants have already been implemented; do not recreate them.

Tasks:
- Implement Application use cases and persistence abstractions for task workflows.
- Implement task create, read, update, and delete operations.
- Expose controller endpoints with explicit request/response DTOs.
- Support status, priority, description, and due date.
- Validate inputs, enforce task ownership, and use consistent Problem Details errors.
- Add pagination, filtering, sorting, and search for task collections.
- Add unit and API integration tests for success, validation, and authorization cases.

Acceptance criteria:
- Authenticated users can manage only their own tasks.
- Invalid input is rejected consistently.
- Collection queries are bounded and behave predictably.
- API contracts do not expose EF Core entities.

### Backend Milestone 4 — Projects and Categories

Tasks:
- Implement project and category domain/application/persistence/API behavior.
- Associate tasks with valid projects and categories.
- Define delete behavior for related tasks.
- Enforce ownership and access rules for every relationship.
- Test valid and invalid relationships, deletion behavior, and unauthorized access.

Acceptance criteria:
- Tasks can be organized into projects and categories.
- Invalid or unauthorized relationships are rejected.
- Data integrity and delete behavior are tested.

### Backend Milestone 5 — Dashboard and Reporting API

Tasks:
- Return task counts by status and priority.
- Provide upcoming and overdue task summaries.
- Scope every result to the authenticated user and authorized projects.
- Avoid unnecessary queries and cover date boundaries and user isolation with tests.

Acceptance criteria:
- Dashboard results agree with underlying task data.
- Date calculations are consistent.
- Unauthorized data is never included.

### Backend Milestone 6 — Backend Verification and Contract Readiness

Tasks:
- Run backend unit, integration, and relational persistence tests.
- Review validation, authorization, error handling, logging, and secret management.
- Review pagination and query behavior.
- Verify API documentation and setup instructions.
- Resolve backend defects before beginning frontend feature work.

Acceptance criteria:
- Backend builds and relevant automated tests pass.
- Critical API and persistence workflows are covered.
- API contracts are stable and documented for frontend implementation.
- Known limitations are recorded honestly.

## 5. Phase Two — Frontend Completion

Begin only after Phase One is complete. The current React/TypeScript/Vite scaffold and welcome screen do not count as completed product features. Do not connect frontend API calls until Phase Three.

### Frontend Milestone 1 — Authentication UX

- Organize frontend code by feature and responsibility.
- Implement registration, login, logout, and accessible form feedback based on the backend authentication contract.
- Handle loading, success, and safe error states.
- Test observable behavior and validation.

### Frontend Milestone 2 — Task Management UX

- Implement task list, details, create, and edit workflows.
- Add status, priority, due date, project/category selection, search, filters, sorting, and pagination.
- Provide loading, empty, error, and success states.
- Support keyboard navigation and responsive layouts.
- Add component and interaction tests.

### Frontend Milestone 3 — Dashboard and UX Quality

- Implement dashboard summaries against the documented backend contract.
- Improve navigation and consistent visual presentation.
- Review accessibility and responsive behavior.
- Add tests for critical frontend interactions.

Acceptance criteria for Phase Two:
- Frontend feature behavior and states are tested with Vitest and React Testing Library.
- Strict TypeScript, lint, formatting, and production build checks pass.
- UI is accessible and usable at mobile and desktop sizes.

## 6. Phase Three — Frontend/Backend Integration

Begin only after the backend and frontend phases are complete.

Tasks:
- Connect the frontend API layer to the documented backend API.
- Configure origins and credentials safely for the selected authentication approach.
- Verify registration/login, task CRUD, filtering, dashboard, and logout across both applications.
- Add Playwright end-to-end tests for critical user journeys.
- Verify denied access and user isolation through the integrated application.
- Confirm setup instructions work from a clean development environment.

Acceptance criteria:
- The backend and frontend run together with live API data.
- Critical end-to-end journeys pass.
- Authentication, authorization, error behavior, and user isolation work across the integration.
- No mock data substitutes for implemented backend workflows.

## 7. Deferred Work

Do not introduce these until the core application is stable and tested:

- Docker and Docker Compose
- CI/CD pipelines
- Azure deployment
- SonarQube
- Microservices
- Kubernetes
- Message brokers or distributed processing
- Complex enterprise workflow features

## 8. Working Strategy

Work in small, reviewable steps. Complete one milestone before moving to the next unless a documented dependency requires otherwise. Prefer clear API contracts and tested boundaries over premature end-to-end wiring. If a requirement is ambiguous or a significant architecture decision is needed, document the options and ask before proceeding.
