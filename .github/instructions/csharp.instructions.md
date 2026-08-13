---
applyTo: "**/*.cs"
---

# C# / .NET Coding Instructions

These instructions apply to all C# source files in this ASP.NET Core MVC
(.NET 10) web application.

## General

- Target modern C# language features available in .NET 10 (e.g. primary
  constructors, collection expressions, pattern matching) when they
  improve readability, but prefer clarity over cleverness.
- Enable and respect nullable reference types; avoid introducing
  nullable warnings.
- Use `async`/`await` for all I/O-bound work (Azure Storage calls,
  database access, HTTP calls). Do not block on async code with `.Result`
  or `.Wait()`.
- Use dependency injection (constructor injection) for services, Azure
  SDK clients, and configuration options instead of creating instances
  directly (`new`) inside controllers, services, or Razor pages.
- Keep controllers thin: validate input, call a service/business layer,
  and return a result. Business logic and Azure Storage interaction
  belong in dedicated service classes.
- Follow standard .NET naming conventions: `PascalCase` for classes,
  methods, and public members; `camelCase` for local variables and
  parameters; `_camelCase` for private fields.
- Use meaningful, descriptive names for classes, methods, and variables.

## MVC Specifics

- Use view models to pass data to views instead of passing domain/entity
  types directly.
- Use data annotations or `FluentValidation` for model validation, and
  always check `ModelState.IsValid` before processing input in
  controller actions.
- Return appropriate HTTP status codes and use `IActionResult`/
  `ActionResult<T>` return types.

## Azure Storage Access

- Access Azure Blob Storage only through an injected client/service
  (e.g. `BlobServiceClient` wrapped in a service interface), never by
  instantiating clients ad hoc inside controllers.
- Never hard-code connection strings, SAS tokens, or account keys in
  source code. Load them from configuration (`appsettings.json`, user
  secrets, environment variables, or Azure Key Vault).
- Handle `Azure.RequestFailedException` and other Azure SDK exceptions
  gracefully, and avoid leaking internal exception details to end users.

## Error Handling & Logging

- Use the built-in `ILogger<T>` for logging instead of `Console.WriteLine`.
- Do not swallow exceptions silently; log them with sufficient context.

## Testing

- When adding or changing behavior, add or update unit tests using the
  test framework already configured in the repository (if present).
- Favor testing services/business logic directly; mock Azure SDK clients
  rather than hitting real Azure Storage in unit tests.
