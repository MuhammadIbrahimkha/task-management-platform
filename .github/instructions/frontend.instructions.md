---
applyTo: "frontend/**/*.{ts,tsx,css,scss}"
---

# Frontend Instructions

## Framework and structure
- Use React, TypeScript, and Vite.
- Follow the root Copilot instructions and `architecture.md`.
- Organize code by feature and responsibility.
- Use functional components and React hooks.
- Keep components focused and manageable.
- Extract reusable components when they provide clear value.
- Avoid unnecessary abstractions and duplicated state.

## TypeScript
- Keep strict type checking enabled.
- Prefer explicit, meaningful types for API contracts and important state.
- Avoid `any` unless there is a justified reason.
- Do not suppress type errors merely to make the build pass.
- Keep API request and response types consistent with the actual backend contracts.

## API communication and state
- Follow the established frontend API layer.
- Handle loading, success, empty, and error states.
- Avoid duplicating server state unnecessarily.
- Do not assume an API operation succeeded before its response confirms success.
- Handle authentication failures consistently.
- Never rely on frontend route protection as the security boundary.

## UI, accessibility, and responsive behavior
- Use semantic HTML and accessible labels.
- Ensure keyboard navigation and visible focus indicators.
- Provide clear validation and error feedback for forms.
- Do not use color as the sole indicator of important state.
- Support mobile and desktop layouts.
- Keep styling and components consistent with the project's existing design system.

## Security
- Never include secrets or privileged credentials in frontend code.
- Do not store bearer tokens in `localStorage` by default.
- Follow the documented authentication strategy.
- Do not treat client-side validation as a replacement for server-side validation.

## Tests and verification
- Use Vitest and React Testing Library for component and interaction tests.
- Test observable user behavior.
- Cover relevant validation, loading, and error states.
- Run the available ESLint, TypeScript, test, and production-build commands.
- Report any checks that could not be executed.

Inspect existing files before editing and keep changes limited to the requested task.
