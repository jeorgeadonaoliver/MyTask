
# MyTask – Detailed Functional Specification
Monolithic .NET 8 API • Next.js 15 • SQL Server  
**Delivery model:** 8 two‑week sprints, Scrum

---

## Sprint 0 – Foundation / Boilerplate
| ID | Story | Acceptance Criteria |
|----|-------|---------------------|
| F‑0.1 | As a developer I want one‑command startup so onboarding < 10 min | • `dotnet run` + `npm run dev` start API on 5000 & UI on 3000<br>• README includes copy‑paste commands |

**Definition of Done**  
*Repo skeleton, Dockerfile (optional), ESLint & Prettier hooks, empty Playwright test passes.*

---

## Sprint 1 – Authentication & Session
| ID | Story | Acceptance Criteria (Given / When / Then) |
|----|-------|-------------------------------------------|
| A‑1.1 | Register | **Given** unique email **When** POST `/auth/register` **Then** 201 & user row exists |
| A‑1.2 | Login | **Given** valid creds **When** POST `/auth/login` **Then** 200 + access & refresh tokens |
| A‑1.3 | Logout | **Given** refresh token **When** POST `/auth/logout` **Then** token revoked |

**DoD**  
*90 % unit coverage on Auth; Swagger docs for `/auth/*`; error i18n stubs.*

---

## Sprint 2 – Projects & Members
| ID | Story | Acceptance Criteria |
|----|-------|---------------------|
| P‑2.1 | Create project | POST `/projects` returns `ProjectId`, creator Owner |
| P‑2.2 | Invite members | POST `/projects/{id}/members` emails → pending invites |
| P‑2.3 | Accept invite | GET `/invites` lists; PATCH `/invites/{id}/accept` activates membership |

**DoD**  
*Project list page; role‑based middleware; tests green.*

---

## Sprint 3 – Task Lists (Kanban) & CRUD
| ID | Story | Acceptance Criteria |
|----|-------|---------------------|
| T‑3.1 | Manage columns | POST `/tasklists`, reorder via PATCH `/tasklists/reorder` |
| T‑3.2 | Create task | POST `/tasks` with ListId returns 201 |
| T‑3.3 | Edit/Delete task | PATCH or DELETE `/tasks/{id}` updates or removes |
| T‑3.4 | Drag task | PUT `/tasks/{id}/move` updates List & Status; SignalR stub ready |

**DoD**  
*Playwright drag‑drop; SignalR compiles.*

---

## Sprint 4 – Assignments, Tags & Filters
| ID | Story | Acceptance Criteria |
|----|-------|---------------------|
| G‑4.1 | Assign users | POST `/tasks/{id}/assign` stores TaskAssignments |
| G‑4.2 | Filter board | GET `/board?assignee=…&tag=…&q=` returns filtered tasks |
| G‑4.3 | Manage tags | CRUD `/tags` |

**DoD**  
*Indexed search; Cypress filter tests.*

---

## Sprint 5 – Subtasks, Comments & Attachments
| ID | Story | Acceptance Criteria |
|----|-------|---------------------|
| D‑5.1 | Subtasks | POST `/subtasks`; completing all prompts parent Done |
| D‑5.2 | Threaded comments | POST `/tasks/{id}/comments` (ParentId optional) |
| D‑5.3 | Attach files | POST `/attachments` multipart; 50 MB max; saved to `/wwwroot/uploads` |

**DoD**  
*Markdown in comments; virus‑scan stub; attachment tests.*

---

## Sprint 6 – Sprints & Reporting
| ID | Story | Acceptance Criteria |
|----|-------|---------------------|
| S‑6.1 | Create sprint | POST `/sprints` (no date overlap) |
| S‑6.2 | Scope tasks | PATCH `/tasks/{id}` sets SprintId; blocked if sprint Closed |
| S‑6.3 | Burndown API | GET `/sprints/{id}/burndown` returns `{date, remainingHours}` JSON |

**DoD**  
*Validation rules; burndown maths tests.*

---

## Sprint 7 – Notifications & Audit
| ID | Story | Acceptance Criteria |
|----|-------|---------------------|
| N‑7.1 | Unread count | GET `/notifications?unread=true` latest 20; PATCH mark‑read |
| N‑7.2 | Trigger events | Assignment / mention create Notification rows |
| N‑7.3 | Audit viewer | GET `/audit?entity=Tasks&entityId=…` returns diff |

**DoD**  
*\"Follow task\" toggle; JSON diff; 95 % service coverage.*

---

## Sprint 8 – Hardening & Portfolio Polish
| Deliverable | Criteria |
|-------------|----------|
| Regression tests | Full e2e flow via Playwright |
| Performance | 95th‑percentile board load < 400 ms |
| Docs & Media | GIF demos, DB diagram |
| Release | Manual publish & smoke‑test checklist |

---

### Roadmap Overview
| Sprint | Theme | Outcome |
|--------|-------|---------|
| 0 | Foundation | Project boots locally |
| 1 | Auth | Secure login flows |
| 2 | Projects | Multi‑project support |
| 3 | Board basics | Lists + task CRUD/drag |
| 4 | Ownership | Assignment, tags, filters |
| 5 | Deep task | Subtasks, files, chat |
| 6 | Sprints | Time‑boxed planning |
| 7 | Notify & Audit | Awareness & history |
| 8 | Polish | Portfolio‑ready demo |

---

*Generated on 2025-06-06.*
