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

The project is set up to be split into multiple services, with each one representing a bounded context. The Wage service uses [Command Query Responsibility Segregation (CQRS)](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs), with each model (i.e, Command/Query) being cleanly split using [Controller Service Repository (CSR)](https://tom-collings.medium.com/controller-service-repository-16e29a4684e5).

The core backend code (`FinancePlanner.Wage.Queries.Application`) uses [Chain of Responsibility (CoR)](https://refactoring.guru/design-patterns/chain-of-responsibility), which divides logic into modular blocks that can be included or excluded as required throughout the codebase, allowing for easier testing.

The Wage Calculation feature of this project was the most suitable use for this pattern, as each employee's wage warrants different [tax codes](https://www.gov.uk/tax-codes/what-your-tax-code-means), but never all of them simultaneously. This requires the ability to "pick" tax code handlers (`FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers[.TaxCode]`), which is what CoR is designed for.

Usage of the [Result pattern](https://medium.com/@aseem2372005/the-result-pattern-in-c-a-smarter-way-to-handle-errors-c6dee28a0ef0) ensures that performance-intensive exception handling is reserved for fatal errors, rather than simple API response codes.

Finally, I leverage [Test Driven Development (TDD)](https://en.wikipedia.org/wiki/Test-driven_development) using [Behaviour Driven Development (BDD)](https://en.wikipedia.org/wiki/Behavior-driven_development) throughout the project, to ensure my code remains high quality and independently organised from its implementation details. The latter can be largely observed in the directory structure & filenames of all tests.

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