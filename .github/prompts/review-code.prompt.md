---
name: Review Code
description: Review code changes for correctness, maintainability, architecture, and regressions without modifying files by default.
agent: ask
---

Review the current changes as a careful senior engineer.

Read the relevant project documentation and instructions first. Inspect the diff and surrounding code before drawing conclusions.

Prioritize findings in this order:
1. Bugs and incorrect behavior.
2. Security and authorization weaknesses.
3. Data integrity and persistence issues.
4. Architecture boundary violations.
5. Missing or inadequate tests.
6. Error handling and edge cases.
7. Maintainability and unnecessary complexity.
8. Performance issues supported by evidence.

For each finding:
- Assign a severity: Critical, High, Medium, or Low.
- Identify the affected file and relevant code location.
- Explain the concrete scenario that could cause the problem.
- Explain the impact.
- Recommend a specific fix.

Rules:
- Do not invent issues without evidence.
- Do not report stylistic preferences as bugs.
- Do not modify files unless explicitly asked.
- Do not claim tests were run unless you actually ran them.
- If there are no significant findings, say so and mention any limitations in the review.

End with a concise summary of the most important risks and missing verification.
