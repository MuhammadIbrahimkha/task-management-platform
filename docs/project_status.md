# Project Status

## Project
Task Management Platform

## Purpose
Build a polished, production-minded full-stack task management application for an independent software engineering portfolio.

## Source of Truth
- Requirements: `docs/project.md`
- Architecture: `docs/architecture.md`
- Implementation milestones: `docs/implementation_plan.md`
- Quality standards: `docs/definition_of_done.md`
- AI instructions: `.github/copilot-instructions.md`
- Current progress: `docs/project_status.md`

When documents conflict, identify the conflict rather than silently choosing a new requirement.

## Technology Stack
- Backend: .NET 10, ASP.NET Core Controllers, C#
- Architecture: modular monolith with Clean Architecture principles
- Frontend: React, TypeScript, Vite
- Database: SQL Server / Azure SQL
- Persistence: Entity Framework Core
- Testing: xUnit, ASP.NET Core integration tests, Vitest, React Testing Library, Playwright
- Development environment: VS Code and GitHub Copilot

## Current Progress

### Completed
- [x] Repository documentation and Copilot instruction files established.
- [x] Backend solution created with Domain, Application, Infrastructure, API, UnitTests, and IntegrationTests projects.
- [x] Project references configured.
- [x] Solution restored and built successfully.
- [x] Initial generated xUnit tests passed.
- [x] API converted to controller-based routing.
- [x] Health endpoint implemented and manually verified.
- [x] TaskItem entity and domain invariants implemented.
- [x] Task status and priority enums aligned with the MVP values.
- [x] Domain unit tests cover defaults, normalization, timestamp updates, input validation, and enum values.
- [x] React, TypeScript, and Vite frontend scaffolded with strict TypeScript and ESLint.
- [x] Accessible frontend welcome shell and an RTL/Vitest rendering smoke test added.
- [x] Root setup instructions updated for backend and frontend development.
- [x] Backend persistence foundation started: EF Core SQL Server and Design packages referenced, `ApplicationDbContext` and explicit `TaskItemConfiguration` added, and Infrastructure registered by the API.
- [x] Development LocalDB connection configured without credentials.
- [x] Persistence metadata and Infrastructure dependency-injection tests cover TaskItem mapping, SQL Server provider registration, and missing-connection-string failure.
- [x] Implementation plan reordered into backend completion, frontend completion, and then integration.

### Verified Limitations
- [ ] Persistence tests currently verify model metadata and DI only; they do not prove a database connection or relational save behavior.
- [ ] A prior migration-generation attempt stopped during NuGet restore, so no migration file was generated. No database update was run; applying any migration requires explicit project-owner approval.
- [ ] A normal NuGet restore is currently blocked by `api.nuget.org` DNS/timeouts. The current build and tests pass using the existing local package assets with `--no-restore`.
- [ ] The backend dependency graph reports known vulnerabilities in transitive `System.Security.Cryptography.Pkcs` 9.0.4 and `System.Security.Cryptography.Xml` 9.0.0 packages; review/update these when package restore is available.
- [ ] Domain implementation is verified, but full task-management acceptance criteria are not complete.
- [ ] Frontend is a scaffold only; it is not connected to the API and has no task or authentication workflows.

### Backend Not Started
- [ ] Generate the initial migration and document database setup; do not apply it without explicit approval.
- [ ] Verify a connection and persistence behavior against local SQL Server.
- [ ] Authentication and resource-level authorization.
- [ ] Application use cases, task API, projects/categories, and dashboard endpoints.
- [ ] Backend contract, security, and integration-test review.

### Deferred Until Backend Completion
- [ ] Frontend authentication, task-management, and dashboard workflows.
- [ ] Frontend/backend API integration and end-to-end testing.
- [ ] Docker, CI/CD, and Azure deployment.

## Current Next Action
Continue Backend Milestone 1 by restoring packages from a working NuGet source, reviewing/updating the flagged transitive dependencies, then generate the initial migration and document database setup. Stop before applying that migration until the project owner explicitly approves it.

## Working Rules
1. Read the relevant project documentation and scoped instructions before implementation.
2. Work on one milestone at a time.
3. Inspect existing code before creating or replacing files.
4. Do not silently change the agreed architecture or technology stack.
5. Never claim a build or test passed unless the command was run successfully.
6. Do not introduce packages without a clear need.
7. Keep secrets out of source control.
8. After each milestone, update this file with verified completion, test results, known issues, and the next action.
9. Do not mark a milestone complete just because code was generated.
10. Keep changes focused and reviewable.

## Latest Verification
- Date: 2026-10-29
- Backend build: `dotnet build backend/TaskManagement.slnx --no-restore --nologo` passed using packages already available locally. NuGet emitted vulnerability warnings for transitive `System.Security.Cryptography.Pkcs` 9.0.4 and `System.Security.Cryptography.Xml` 9.0.0.
- Backend tests: `dotnet test backend/TaskManagement.slnx --no-restore --nologo --verbosity minimal` passed 13 unit tests and 3 integration tests.
- NuGet restore: `dotnet restore backend/TaskManagement.slnx --nologo` did not complete because downloads from `api.nuget.org` timed out or failed DNS resolution. A clean restore has not been verified.
- Database: No migration file was generated and no database update was run in this step. No database was changed.
- Plan and setup documentation: implementation order is now backend first, frontend second, then integration; README reflects backend-only current work and states migrations are not applied automatically.
- Frontend dependency compatibility: `npm ci` installed from the lockfile successfully; `npm ls --depth=0` showed no unresolved dependencies. TypeScript 6.0.3 satisfies `typescript-eslint`'s `<6.1` peer range, Vitest 5 supports Vite 8, and Node 22.15 meets Vite's Node `^20.19.0 || >=22.12.0` requirement. The supported Node range is documented.
- Frontend build: `npm run build` passed, including strict TypeScript checking and the Vite production build.
- Frontend tests: `npm test` passed (1 rendering test for the welcome heading and supporting text).
- Frontend static checks: `npm run lint` and `npm run format:check` passed.
- Dependency audit: `npm ci` reported 0 vulnerabilities.
- Historical frontend HTTP smoke test returned 200 with the expected page title; the temporary Vite process was stopped.
- Known issues: database connectivity and migration workflow have not been verified. Frontend coverage remains limited to the static scaffold.
- Commit: Not committed.
