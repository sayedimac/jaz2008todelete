---
applyTo: "**/*.css,**/*.scss"
---

# CSS / SCSS Instructions

These instructions apply to stylesheet files in this ASP.NET Core MVC
web application.

## General

- Keep styles in dedicated `.css`/`.scss` files under `wwwroot`; avoid
  inline `style` attributes and `<style>` blocks in Razor views.
- Use consistent, descriptive class names (e.g. `kebab-case`, following
  a BEM-like convention such as `block__element--modifier`) instead of
  presentational or overly generic names.
- Prefer CSS custom properties (variables) for shared values such as
  colors, spacing, and fonts, defined once (e.g. on `:root`) and reused
  throughout the stylesheets.
- Use relative units (`rem`, `em`, `%`) over fixed `px` values for
  typography and spacing where reasonable, to support accessibility and
  responsive layouts.
- Follow a mobile-first, responsive approach using media queries rather
  than duplicating styles for different breakpoints.

## Organization

- Group related rules together and keep selectors as shallow as possible
  (avoid deeply nested selectors, especially in SCSS).
- Avoid `!important`; resolve specificity conflicts by adjusting selector
  structure instead.
- Reuse existing utility classes/variables already defined in the
  project's stylesheets instead of introducing duplicate styles.

## Accessibility & Performance

- Ensure sufficient color contrast for text and interactive elements.
- Ensure focus states remain visible for keyboard navigation (do not
  remove `:focus` outlines without providing an accessible alternative).
- Avoid unnecessary duplication of styles; keep stylesheets lean to
  minimize page load size.
