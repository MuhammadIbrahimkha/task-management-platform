# Task Management Platform — Project Specification

## 1. Vision

Build a modern, secure, maintainable full-stack task management platform that demonstrates sound software engineering practices and can evolve into a cloud-hosted application.

The project will be developed from scratch as an independent portfolio project.

## 2. Target Users

- Individual users managing personal tasks.
- Users organizing work into projects and categories.
- Future teams collaborating on shared projects.

## 3. Technology Stack

- Backend: ASP.NET Core Web API on .NET 10 LTS.
- Frontend: React, TypeScript, and Vite.
- Data access: Entity Framework Core.
- Database: SQL Server, with Azure SQL as a deployment option.
- Backend tests: xUnit and ASP.NET Core integration testing.
- Frontend tests: Vitest and React Testing Library.
- End-to-end tests: Playwright for critical user journeys.

## 4. MVP Features

### Authentication
- User registration, login, and logout.
- Secure password handling.
- Authenticated access to private application areas.
- Server-enforced authorization.

### Task Management
- Create, view, update, and delete tasks.
- Task status: To Do, In Progress, Completed.
- Priority: Low, Medium, High.
- Optional due date and description.
- Categories and project association.
- Search, filtering, sorting, and pagination.
- Users may access only tasks they are authorized to manage.

### Dashboard
- Task counts by status and priority.
- Upcoming and overdue tasks.
- Clear empty, loading, success, and error states.

### User Experience
- Responsive layout.
- Accessible forms and navigation.
- Consistent validation and error messages.
- List view and a board view for task status.

### Projects
- Organize tasks into projects.
- Enforce project membership and access rules when collaboration is introduced.

## 5. Quality Requirements

- Business rules must be tested.
- Important API workflows must have integration tests.
- Critical frontend interactions must have automated tests.
- API inputs must be validated server-side.
- Secrets must never be committed.
- Database schema changes must use explicit migrations.
- Errors must not expose sensitive implementation details.
- Setup and testing instructions must be documented.

## 6. Explicit Non-Goals for the Initial Release

- Microservices.
- Kubernetes.
- Distributed messaging.
- Complex enterprise workflow engines.
- SonarQube integration.
- Docker, CI/CD, and Azure infrastructure implementation.

DevOps capabilities will be introduced after the application and its tests are working reliably.

## 7. Acceptance Criteria

The MVP is acceptable when:

1. A new developer can follow the documented setup instructions.
2. The backend and frontend start successfully.
3. Authentication and task workflows function end-to-end.
4. Authorization prevents unauthorized access to another user's data.
5. Database migrations can be applied through a documented process.
6. Automated tests cover important business rules and user journeys.
7. The interface works on desktop and mobile-sized screens.
8. The repository contains clear documentation of its architecture and limitations.