# Implementation Plan

## 1. Purpose

Build the Task Management Platform incrementally as a secure, maintainable, tested full-stack application suitable for a professional portfolio.

Every milestone must leave the repository in a coherent state. Do not implement the entire application in one large change.

## 2. Technology Stack

### Backend
- .NET 10 LTS
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server, with Azure SQL as a future deployment target
- Clean Architecture principles using a modular monolith
- xUnit for automated tests
- ASP.NET Core integration testing with `Microsoft.AspNetCore.Mvc.Testing`

### Frontend
- React
- TypeScript with strict type checking
- Vite
- A consistent, accessible component and styling system
- Vitest
- React Testing Library
- Playwright for end-to-end tests

### Development Environment
- Visual Studio Code
- Git and GitHub
- GitHub Copilot for implementation assistance

Do not assume Visual Studio IDE is being used. All editor instructions must be suitable for VS Code and its integrated terminal.

## 3. Milestone Rules

For every milestone:

1. Read `project.md`, `architecture.md`, and the relevant repository instructions.
2. Inspect existing files before changing them.
3. State the intended changes and important design decisions.
4. Implement only the current milestone.
5. Add or update automated tests.
6. Run the relevant build, lint, type-check, and test commands.
7. Fix failures introduced by the changes.
8. Update documentation when behavior or setup changes.
9. Summarize files changed, commands executed, results, and remaining issues.
10. Do not claim a command or test passed unless it was actually run and passed.

Do not overwrite working code or introduce unrelated refactoring without a clear reason.

## 4. Milestone 0 — Repository Foundation

### Goals
Establish project conventions and repository documentation before feature development.

### Tasks
- Create and maintain `project.md`.
- Create and maintain `architecture.md`.
- Create and maintain this `implementation_plan.md`.
- Create `definition_of_done.md`.
- Create `.github/copilot-instructions.md`.
- Add an appropriate `.gitignore`.
- Add a clear root `README.md`.
- Establish the intended folder and project structure.
- Record important architectural decisions in `docs/decisions/`.

### Acceptance Criteria
- The repository purpose and scope are documented.
- Architecture boundaries are documented.
- The implementation sequence is clear.
- Instructions for Copilot are available.
- No application features are implemented prematurely.

## 5. Milestone 1 — Solution and Application Scaffolding

### Backend
Create the following projects:

- `TaskManagement.Domain`
- `TaskManagement.Application`
- `TaskManagement.Infrastructure`
- `TaskManagement.Api`
- `TaskManagement.UnitTests`
- `TaskManagement.IntegrationTests`

Use a solution named `TaskManagement.sln`.

### Frontend
Create the React + TypeScript + Vite application in a clearly named frontend directory, such as `frontend/`.

Configure:
- TypeScript strict mode
- ESLint
- Consistent formatting
- Vitest
- React Testing Library

### Tasks
- Establish project references according to `architecture.md`.
- Configure dependency injection.
- Add a basic API health endpoint.
- Add a basic frontend application shell.
- Add environment-variable examples without real secrets.
- Document local setup commands.

### Acceptance Criteria
- The backend builds successfully.
- The frontend installs and builds successfully.
- The API health endpoint responds successfully.
- The frontend renders without runtime errors.
- Initial automated tests pass.
- A new developer can follow the setup documentation.

## 6. Milestone 2 — Persistence and Database Foundations

### Tasks
- Configure EF Core with SQL Server.
- Define the initial `ApplicationDbContext`.
- Configure entity mappings explicitly where appropriate.
- Establish database configuration using environment variables or development user secrets.
- Add the initial database migration.
- Document how to create and update the local database.
- Establish a consistent persistence approach.

### Acceptance Criteria
- The API can connect to a configured SQL Server instance.
- Database migrations can be created and applied.
- Database credentials are not committed.
- Persistence-related tests cover meaningful behavior.
- Domain and Application layers do not depend on EF Core.

## 7. Milestone 3 — Authentication and Authorization

### Tasks
- Implement registration, login, and logout.
- Select and document a browser-appropriate authentication strategy before implementation.
- Use secure password hashing through established framework facilities.
- Implement authentication and authorization policies.
- Protect authenticated endpoints.
- Ensure users cannot access another user's private resources.
- Add validation and safe authentication error responses.
- Test authentication success, failure, and authorization boundaries.

### Important Security Requirement
Do not automatically store bearer tokens in browser `localStorage`. Evaluate a secure HTTP-only cookie approach or another appropriate design, considering CSRF protection, deployment topology, and API access patterns. Record the decision before implementation.

### Acceptance Criteria
- Users can register and authenticate.
- Invalid credentials are rejected safely.
- Protected endpoints reject unauthenticated requests.
- Authorization is enforced on the server.
- Cross-user resource access is prevented and tested.
- Secrets and passwords are never logged.

## 8. Milestone 4 — Core Domain and Task Management

### Tasks
- Implement the Task domain model and its invariants.
- Support task creation, reading, updating, and deletion.
- Support statuses: To Do, In Progress, Completed.
- Support priorities: Low, Medium, High.
- Support descriptions and due dates.
- Add server-side validation.
- Implement application use cases and persistence.
- Expose appropriately secured API endpoints.
- Use request and response DTOs rather than exposing persistence entities.
- Add pagination, filtering, sorting, and search.
- Add unit and integration tests.

### Acceptance Criteria
- Authenticated users can manage their own tasks.
- Invalid task data is rejected consistently.
- Task ownership is enforced on every relevant operation.
- Filtering, sorting, pagination, and search behave predictably.
- API errors follow a consistent format.
- Automated tests cover success paths and important failure cases.

## 9. Milestone 5 — Projects and Categories

### Tasks
- Implement projects and task categories.
- Associate tasks with the appropriate project and category.
- Validate relationships on the server.
- Enforce ownership and access rules.
- Support creating, editing, listing, and deleting projects and categories where appropriate.
- Define what happens to related tasks when a project or category is removed.
- Add automated tests for relationship and authorization rules.

### Acceptance Criteria
- Tasks can be organized using projects and categories.
- Invalid or unauthorized relationships are rejected.
- Data integrity is preserved.
- Delete behavior is explicitly defined and tested.

## 10. Milestone 6 — Dashboard and Reporting

### Tasks
- Implement task summary queries.
- Provide counts for total, To Do, In Progress, and Completed tasks.
- Provide upcoming and overdue task summaries.
- Scope all results to the authenticated user and authorized projects.
- Avoid unnecessary database queries.
- Add tests for date boundaries and user isolation.

### Acceptance Criteria
- Dashboard values agree with the underlying task data.
- Overdue and upcoming tasks are calculated consistently.
- Dashboard responses do not expose unauthorized data.

## 11. Milestone 7 — Frontend Foundation and Authentication UX

### Tasks
- Establish feature-based frontend organization.
- Create shared layout and reusable UI components.
- Implement registration, login, and logout screens.
- Add loading, error, empty, and success states.
- Add route protection appropriate to the selected authentication strategy.
- Implement accessible forms and validation feedback.
- Add component and interaction tests.

### Acceptance Criteria
- Authentication flows work against the API.
- Forms are accessible and usable on different screen sizes.
- API failures are communicated clearly.
- Authentication state is handled consistently.

## 12. Milestone 8 — Task Management UX

### Tasks
- Implement task list and task detail views.
- Implement create and edit forms.
- Implement status and priority controls.
- Add search, filters, sorting, and pagination.
- Add project and category selection.
- Provide loading, empty, error, and success states.
- Implement a responsive layout.
- Add a board-style view when the core list workflow is stable.
- Add component and interaction tests.

### Acceptance Criteria
- Users can complete the main task workflow through the UI.
- The UI reflects server-confirmed changes.
- Forms handle invalid input and API errors.
- Keyboard navigation and visible focus states are supported.
- The interface works at mobile and desktop sizes.

## 13. Milestone 9 — Dashboard and Final UX Polish

### Tasks
- Build the dashboard.
- Show task summaries and upcoming or overdue tasks.
- Improve navigation and information hierarchy.
- Standardize spacing, typography, colors, and reusable components.
- Add suitable feedback for important actions.
- Review accessibility and responsive behavior.
- Add frontend tests for critical interactions.

### Acceptance Criteria
- Dashboard figures match API responses.
- Navigation is intuitive and consistent.
- Loading, empty, error, and success states are implemented.
- The UI is polished enough for a portfolio demonstration.

## 14. Milestone 10 — Quality, Security, and End-to-End Validation

### Tasks
- Expand unit and integration test coverage for critical behavior.
- Add Playwright end-to-end tests for essential user journeys.
- Test registration, login, task CRUD, filtering, and logout.
- Verify user isolation and authorization boundaries.
- Review validation, error handling, logging, and secret management.
- Review API pagination and query behavior.
- Review keyboard accessibility and responsive layouts.
- Verify database setup instructions from a clean environment.
- Review and complete README documentation.

### Acceptance Criteria
- Backend builds and automated tests pass.
- Frontend linting, type checking, build, and tests pass.
- Critical end-to-end workflows pass.
- No known critical authorization defects remain.
- Setup and test instructions are reproducible.
- Known limitations are documented honestly.

## 15. Deferred Work — Do Not Implement Yet

The following are intentionally deferred until the application is stable and tested:

- Docker and Docker Compose
- CI/CD pipelines
- Azure App Service deployment
- Azure SQL deployment configuration
- SonarQube
- Microservices
- Kubernetes
- Message brokers and distributed processing
- Complex enterprise workflow features

Do not introduce these technologies during earlier milestones unless the project scope is explicitly revised.

## 16. Implementation Strategy

Work in small, reviewable changes. Complete one milestone before moving to the next unless a documented dependency requires a different order.

Prefer a vertical slice when implementing features: domain behavior, application use case, persistence, API, frontend, and tests should fit together coherently.

Do not generate the entire application in a single Copilot prompt. Ask Copilot to inspect the relevant documentation and implement one specific task at a time.

If a requirement is ambiguous, identify the ambiguity and propose options before making a consequential architectural decision.

Keep the project understandable to another developer reviewing the repository for the first time.
