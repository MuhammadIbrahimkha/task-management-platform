---
applyTo: "backend/**/*.cs"
---

# Backend Instructions

## Architecture
- Follow `ARCHITECTURE.md` and the root Copilot instructions.
- Keep Domain, Application, Infrastructure, and API responsibilities separate.
- Domain must not depend on ASP.NET Core, EF Core, or Infrastructure.
- Application contains use cases and abstractions, not HTTP-specific behavior.
- Infrastructure implements persistence and external technology integrations.
- API handles HTTP, authentication configuration, authorization policies, middleware, and dependency injection composition.
- Do not introduce microservices or unnecessary abstractions.

## C# and ASP.NET Core
- Use nullable reference types and meaningful types.
- Use asynchronous I/O APIs where appropriate.
- Propagate cancellation tokens through relevant asynchronous operations.
- Use dependency injection.
- Validate input on the server.
- Use request and response DTOs; never expose EF Core entities directly as API contracts.
- Keep business rules out of controllers and endpoint handlers when they belong in Domain or Application.
- Use consistent HTTP status codes and the established Problem Details error format.
- Do not leak exception details to clients.

## EF Core and SQL Server
- Keep EF Core and SQL Server concerns in Infrastructure.
- Define entity relationships and delete behavior intentionally.
- Add migrations for schema changes.
- Avoid N+1 queries and unnecessary database calls.
- Use pagination for potentially large result sets.
- Use relational database integration tests for behavior that depends on relational constraints or SQL Server semantics.

## Security
- Enforce authorization server-side.
- Check resource ownership and permissions on every relevant operation.
- Never trust client-supplied user IDs to establish ownership.
- Validate access to related projects, categories, and tasks.
- Never log credentials, tokens, or secrets.
- Never hardcode credentials or commit production secrets.
- Follow the authentication design documented for the project.

## Tests and verification
- Add or update xUnit unit tests for business behavior.
- Add integration tests for important API, authentication, authorization, and persistence behavior.
- Test failure cases and unauthorized access.
- Run relevant `dotnet build` and `dotnet test` commands.
- Report commands that were not run or could not pass.

Inspect existing files before editing. Make only the changes needed for the requested task.
