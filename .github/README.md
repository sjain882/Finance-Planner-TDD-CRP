# 📈 Finance Planner

Payroll system for businesses that allows tracking of wages and automatic calculation of gross incomes according to relevant tax codes.

## 🧰 Technologies used

### Backend
- Primary language: [C# 13](https://dotnet.microsoft.com/en-us/languages/csharp) / [ASP.NET Core 9](https://dotnet.microsoft.com/en-us/apps/aspnet)
- Database: [PostgreSQL / Npgsql](https://www.npgsql.org/)
- Tests: [NUnit 4](https://nunit.org/)
- Test Containers: [Testcontainers.PostgreSql](https://www.nuget.org/packages/Testcontainers.PostgreSql)
- Test Mocks: [Moq](https://github.com/devlooped/moq)

### Frontend
- Web Framework: [Next.js](https://nextjs.org/) ([React](https://react.dev/))
- Style: [Tailwind CSS](https://tailwindcss.com/)
- Invalidation: [Tanstack Query](https://tanstack.com/query/latest)
- UI Components: [Shadcn](https://ui.shadcn.com/)

### DevOps

- Containerisation: [Docker](https://www.docker.com/)
- CI/CD: [Github Actions](https://github.com/features/actions)

### Development tools
- Frontend IDE: [Visual Studio Code](https://code.visualstudio.com/)
- Backend IDE: [Jetbrains Rider](https://www.jetbrains.com/rider/)
- Database Management: [pgAdmin 4](https://www.pgadmin.org/)
- Testing API endpoints: [Insomnia](https://insomnia.rest/), [Swagger](https://swagger.io/)
- Frontend development subsystem: [WSL](https://learn.microsoft.com/en-us/windows/wsl/about)
- Planning: [Github Projects Kanban](https://github.com/users/sjain882/projects/1)

‎
‎
## 📚 Architectures & patterns
I use this project to learn & implement various design patterns to ensure my work remains performant, maintainable and scalable.

Currently, the root level uses [Command Query Responsibility Segregation (CQRS)](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs) and sub-services (e.g, `./src/[Commands|Queries]/Wage`) use [Controller Service Repository (CSR)](https://www.youtube.com/watch?v=8fFBWmbUaIg), to ensure good separation of logic.

Despite this, each service is fully self-contained, meaning they can adhere to any pattern (e.g, another one could be a Modular Monolith).

The core backend code (`FinancePlanner.Wage.Queries.Application`) uses [Chain of Responsibility (CoR)](https://refactoring.guru/design-patterns/chain-of-responsibility), which divides logic into modular blocks that can be included or excluded as required throughout the codebase, minimising code duplication.

The Wage Calculation feature of this project was the most suitable use for this pattern, as each employee's wage warrants different [tax codes](https://www.gov.uk/tax-codes/what-your-tax-code-means), but never all of them simultaneously. This requires the ability to "mix and match" tax code handlers (`FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers[.TaxCode]`), which is exactly what CoR is designed for.

Usage of the [Result pattern](https://medium.com/@aseem2372005/the-result-pattern-in-c-a-smarter-way-to-handle-errors-c6dee28a0ef0) ensures that performance-intensive exception handling is only used for fatal errors, rather than simple API response codes.

Finally, I adhere to [Test Driven Development (TDD)](https://en.wikipedia.org/wiki/Test-driven_development) and [Behaviour Driven Development (BDD)](https://en.wikipedia.org/wiki/Behavior-driven_development) throughout the project, to ensure my code remains accurate and independently organised from its implementation details. The latter can be largely observed in the directory structure & filenames of all tests.

‎
‎
## 🖼️ Gallery
| ![wage-calcuator light](https://github.com/sjain882/Finance-Planner-TDD-CRP/blob/main/.github/Previews/Frontend/Nextjs/Light/wage-calculator.png?raw=true) | ![wage-register light](https://github.com/sjain882/Finance-Planner-TDD-CRP/blob/main/.github/Previews/Frontend/Nextjs/Light/wage-register.png?raw=true) |
|-|-|
| ![wage-calcuator dark](https://github.com/sjain882/Finance-Planner-TDD-CRP/blob/main/.github/Previews/Frontend/Nextjs/Dark/wage-calculator.png?raw=true) | ![wage-register dark](https://github.com/sjain882/Finance-Planner-TDD-CRP/blob/main/.github/Previews/Frontend/Nextjs/Dark/wage-register.png?raw=true) |

‎
‎
## 🛠️ Building
### Backend
#### Command and Query together
Run docker in ./backend:
```bash
cd ./backend
docker compose up
```
If you've made changes locally, rebuild it (unchanged projects will be cached):
```bash
cd ./backend
docker compose up --build
```
### Frontend
Run:
```bash
cd ./frontend
npm run dev
```

‎
‎
## ✔️ Testing

### Via cloud
Simply run Github Actions.

### Via Docker engine (WSL) on Windows
Ensure Docker Desktop is running.

Then, simply run:
```bash
cd ./backend
dotnet test
```

#### Tests not running due to connection being refused?

```bash
touch /etc/docker/daemon.json
nano /etc/docker/daemon.json
```
Enter the following contents then save & exit:
```json
{
    "hosts": ["tcp://0.0.0.0:2375","unix:///var/run/docker.sock"]
} 
```