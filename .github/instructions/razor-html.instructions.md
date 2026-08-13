---
applyTo: "**/*.cshtml,**/*.html"
---

# Razor / HTML Instructions

These instructions apply to Razor views (`.cshtml`) and static HTML files
in this ASP.NET Core MVC web application.

## General

- Use semantic HTML elements (`<header>`, `<nav>`, `<main>`, `<section>`,
  `<article>`, `<footer>`, etc.) instead of generic `<div>`/`<span>` where
  a semantic element fits.
- Always provide `alt` text for images and appropriate `aria-*`
  attributes/labels for interactive elements to keep pages accessible.
- Keep markup free of inline styles and inline JavaScript; put styles in
  CSS files and scripts in JavaScript files referenced via `<script>` tags.
- Use the shared `_Layout.cshtml` and partial views/view components for
  repeated UI (headers, footers, navigation) instead of duplicating
  markup across views.

## Razor Specifics

- Use strongly-typed views (`@model MyViewModel`) instead of `dynamic`
  or `ViewBag`/`ViewData` where possible.
- Use Tag Helpers (`asp-for`, `asp-action`, `asp-controller`, etc.)
  instead of hard-coded URLs or raw `<a href="...">` for links to
  controller actions.
- Encode all user-supplied or dynamic data with Razor's built-in HTML
  encoding (`@model.Property`); avoid `@Html.Raw()` unless the content is
  known to be safe/sanitized, to prevent XSS.
- Keep C# logic in `.cshtml` files minimal — prefer view models and view
  components over complex `@{ }` code blocks.
- Use partial views (`_PartialName.cshtml`) or view components to break
  down large or reused chunks of markup.

## Forms

- Use `asp-validation-summary` and `asp-validation-for` Tag Helpers to
  surface model validation errors to the user.
- Include anti-forgery tokens on forms that submit data (enabled by
  default via `asp-action`/`asp-controller` Tag Helpers).
