---
applyTo: "**/*.js"
---

# JavaScript Instructions

These instructions apply to client-side JavaScript files in this
ASP.NET Core MVC web application.

## General

- Write modern JavaScript (ES6+): use `const`/`let` instead of `var`,
  arrow functions where appropriate, template literals, and
  destructuring.
- Keep JavaScript in dedicated `.js` files under `wwwroot`; avoid inline
  `<script>` blocks and inline event handler attributes (`onclick="..."`)
  in Razor views/HTML.
- Use `fetch` (or the project's existing HTTP helper, if one exists) for
  calling server endpoints; handle errors and rejected promises
  explicitly instead of leaving them unhandled.
- Avoid polluting the global namespace — wrap code in modules or
  IIFEs/namespaces consistent with existing scripts in the project.

## DOM & Accessibility

- Query the DOM using stable selectors (IDs or data attributes) rather
  than fragile CSS class selectors that may change for styling reasons.
- When dynamically updating content, preserve accessibility (e.g. update
  `aria-*` attributes, manage focus) for elements that change state.
- Avoid manipulating the DOM in ways that duplicate what Razor
  server-side rendering already provides; prefer progressive enhancement.

## Security

- Never insert unsanitized user input into the DOM via `innerHTML`;
  prefer `textContent` or properly escape/sanitize any HTML that must be
  inserted, to avoid XSS.
- Do not hard-code API keys, connection strings, or secrets in
  client-side JavaScript.
