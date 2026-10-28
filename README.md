# Task Management Platform

A full-stack task management application built as an independent portfolio project to demonstrate modern web development, secure API design, clean architecture, automated testing, and maintainable software engineering.

## Project Status

**Current phase:** Application scaffolding. The API health endpoint and frontend shell are in place; product workflows are not implemented yet.

The application is being developed incrementally. Features will be implemented, tested, and documented milestone by milestone.

## Technology Stack

### Backend
- .NET 10 LTS
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Clean Architecture principles within a modular monolith

### Frontend
- React
- TypeScript
- Vite

### Testing
- xUnit
- ASP.NET Core integration testing
- Vitest
- React Testing Library
- Playwright

## Planned Features

- User registration and authentication
- Secure, user-specific task management
- Task priorities, statuses, and due dates
- Projects and categories
- Task search, filtering, sorting, and pagination
- Dashboard with task summaries and overdue items
- Responsive and accessible user interface
- Automated tests for critical workflows

## Repository Structure

```text
task-management-platform/
├── .github/
│   ├── instructions/
│   ├── prompts/
│   └── copilot-instructions.md
├── backend/
│   ├── src/
│   │   ├── TaskManagement.Api/
│   │   ├── TaskManagement.Application/
│   │   ├── TaskManagement.Domain/
│   │   └── TaskManagement.Infrastructure/
│   ├── tests/
│   │   ├── TaskManagement.IntegrationTests/
│   │   └── TaskManagement.UnitTests/
│   └── TaskManagement.slnx
├── frontend/
│   ├── src/
│   └── package.json
├── docs/
│   ├── architecture.md
│   ├── definition_of_done.md
│   ├── implementation_plan.md
│   └── project.md
├── .gitignore
└── README.md
```

## Local Development

### Backend API

From the repository root:

```powershell
dotnet run --project backend/src/TaskManagement.Api/TaskManagement.Api.csproj
```

### Frontend

Use Node.js 20.19 or later in the 20.x line, or 22.12 or later. From the repository root:

```powershell
Set-Location frontend
npm ci
npm run dev
```

In the frontend directory, run the available checks with:

```powershell
npm run lint
npm run format:check
npm test
npm run build
```

The frontend does not call the API yet, so it has no environment variables to configure. Database and API configuration will be documented when those integrations are implemented.

## Documentation

- [Project Vision and Requirements](docs/project.md)
- [Architecture](docs/architecture.md)
- [Implementation Plan](docs/implementation_plan.md)
- [Definition of Done](docs/definition_of_done.md)

## Development Environment

The project is developed using Visual Studio Code, Git, GitHub, and GitHub Copilot.

The project is under active development. See [Project Status](docs/project_status.md) for verified progress and the next task.

## Current Scope

The initial focus is a reliable, secure, well-tested application.

Docker, CI/CD, Azure deployment, SonarQube, Kubernetes, and microservices are deferred until the core application is stable.
