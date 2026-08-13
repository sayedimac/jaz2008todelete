# Copilot Instructions for jaz2008todelete

## Project Overview

This repository hosts a web application for browsing and displaying Azure
Storage blobs. It is built as an **ASP.NET Core MVC application targeting
.NET 10**.

When implementing features, keep the following architecture in mind:

- **Controllers** handle incoming requests, coordinate with services, and
  select the view/model to return. Keep controllers thin — business logic
  belongs in services, not controllers.
- **Models** represent the data passed between controllers and views
  (view models) as well as the domain data returned from Azure Storage.
- **Views** (Razor `.cshtml`) render HTML using the shared layout and
  partials. Avoid embedding business logic in views.
- **Services** encapsulate interaction with Azure Storage (e.g. via
  `Azure.Storage.Blobs`) and other external dependencies. Access Azure
  Storage only through injected service abstractions so that they can be
  unit tested and mocked.

## General Guidelines

- Follow the existing project structure and naming conventions; do not
  reorganize folders unless explicitly asked.
- Prefer async/await for any I/O-bound operations, especially calls to
  Azure Storage.
- Use dependency injection for services and Azure SDK clients instead of
  instantiating them directly inside controllers or views.
- Never commit secrets, connection strings, or account keys. Read
  configuration (e.g. Azure Storage connection strings) from
  `appsettings.json`, user secrets, environment variables, or Azure Key
  Vault — never hard-code them.
- Write clear, descriptive commit messages and keep changes focused and
  minimal.
- Add or update unit tests when you change behavior, using the test
  project/framework already present in the repository.

## File-Type Specific Guidance

More detailed, file-type specific instructions live under
`.github/instructions/` and are automatically applied based on the file
being edited:

- `csharp.instructions.md` – C# / .NET coding conventions.
- `razor-html.instructions.md` – Razor views and HTML markup conventions.
- `css.instructions.md` – CSS/SCSS styling conventions.
- `javascript.instructions.md` – Client-side JavaScript conventions.

Refer to those files for detailed rules when working on the corresponding
file types.
