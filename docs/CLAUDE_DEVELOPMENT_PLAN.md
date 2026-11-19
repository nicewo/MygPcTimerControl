# MyG PC Timer Control — Claude Development Plan

**Audit first. No code changes until the audit and roadmap are approved.**
Repository: nicewo/MygPcTimerControl
## Mission
Make this repository reproducible, stable, maintainable and accurately documented. Preserve existing useful behavior; avoid speculative rewrites.
## Phase 0: Audit only
Read the README, docs, source, project files, configuration and commit history. Verify README claims. Classify features as implemented/partial/placeholder/broken/unverified. Run build/tests where possible and record exact commands/results. Check secrets, .gitignore, dependencies, TODO/FIXME, duplicated or dead code, unsafe defaults. Report evidence with file paths, blockers, risks and unknowns. Do not edit anything in this phase.
## Specific audit focus
Build, tray lifecycle, overlay, schedule/time edge cases, JSON endpoint, update ZIP güvenliği, offline/network failures, user settings ve tests.
## Phase 1: Hygiene and baseline
After approval, fix confirmed documentation/config hygiene, dependency pinning, ignore rules and reproducible build/test baseline; add CI only if justified.
## Phase 2: Prioritized implementation
Derive tasks from findings. Each task must include priority, rationale, dependencies, scope, effort/risk and acceptance criteria. Correctness/security/reliability before polish.
## Phase 3: Tests and verification
Add regression/unit/integration checks. Test normal and failure paths, edge cases and persistence. Clearly label anything not verified in target environment/hardware.
## Phase 4: Documentation and release readiness
Setup/build/run/test, troubleshooting, known limitations, release checklist and deployment steps. Never include secrets.
## Claude workflow
1) Audit only, no changes. 2) Report evidence and roadmap. 3) Wait for approval. 4) Implement one milestone at a time, scoped commits. 5) Run checks after each milestone and report actual results. 6) Ask before destructive changes, migrations, deployments, hardware actions or breaking changes. 7) Update this plan only with verified progress.
## Acceptance
Reproducible documented build/tests; clear project scope; critical risks fixed or tracked; core behavior verified; limitations honest.
## Checklist
- [ ] Audit  - [ ] Roadmap approved  - [ ] Hygiene baseline  - [ ] Milestones verified  - [ ] Release docs
## First task for Claude
Read this plan and the entire repo. Return evidence-based audit and roadmap only. Make no edits.