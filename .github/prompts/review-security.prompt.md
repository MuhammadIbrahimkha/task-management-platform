---
name: Review Security
description: Review authentication, authorization, data access, validation, configuration, and other security-sensitive code.
agent: ask
---

Perform a focused security review of the relevant code and its surrounding execution paths.

Read the architecture and project instructions first. Trace how requests enter the application, how identity is established, how permissions are checked, and how data is accessed.

Check for:
- Missing authentication or authorization.
- Broken resource ownership checks and insecure direct object references.
- Trust in client-supplied user IDs.
- Unauthorized access through related projects, categories, or tasks.
- Unsafe authentication or session handling.
- Missing CSRF protections where cookie authentication requires them.
- Insecure password handling.
- Sensitive information in logs or error responses.
- Hardcoded secrets and unsafe configuration defaults.
- Missing server-side validation.
- Mass assignment or unintended property updates.
- Unsafe database access.
- Excessive data exposure through API responses.
- Missing pagination or other relevant resource limits.
- Dependencies or configuration that create a clearly supported security risk.

For every finding:
1. State severity.
2. Identify the affected file and code location.
3. Describe a realistic exploitation or failure scenario.
4. Explain the impact.
5. Recommend a concrete mitigation.
6. Identify a test that would help prevent regression.

Do not claim that the application is secure based solely on a code review. Distinguish confirmed findings from areas that could not be verified.

Do not modify files unless explicitly asked. Do not invent vulnerabilities, credentials, test results, or runtime behavior.
