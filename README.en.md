# Telemarketing Performance

A backend system for tracking performance indicators in telemarketing companies, developed with .NET 8 and following Domain-Driven Design (DDD) principles. The project focuses on business logic, automated testing, and a clean architecture, providing a solid foundation for performance management and data-driven decision-making.

## Features
- Register and manage performance indicators
- Record collections (results) for each indicator
- Calculate and analyze performance metrics
- Error handling and validation
- Automated unit tests for domain and application layers
- RESTful API endpoints (Swagger/OpenAPI)

## Technologies Used
- .NET 8
- C#
- Entity Framework Core
- xUnit (unit testing)
- Swagger (OpenAPI)
- DDD (Domain-Driven Design)

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- Git

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/giacominimarco/telemarketing_v2.git
   cd telemarketing_v2
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Build the solution:
   ```bash
   dotnet build
   ```
4. Run the tests:
   ```bash
   dotnet test
   ```
5. Run the API:
   ```bash
   cd TelemarketingPerformance.WebApi
   dotnet run
   ```
6. Access the API documentation:
   - Open [http://localhost:5000/swagger](http://localhost:5000/swagger) or the URL shown in the terminal.

## Project Structure
```
TelemarketingPerformance.sln
├── TelemarketingPerformance.Domain/        # Domain entities, enums, repositories
├── TelemarketingPerformance.Application/   # DTOs, services, interfaces
├── TelemarketingPerformance.Infrastructure/# EF Core, repository implementations
├── TelemarketingPerformance.WebApi/        # REST API (controllers, Program.cs)
├── TelemarketingPerformance.Tests/         # Unit tests (domain, application)
```

## Usage Example
- Create an indicator
- Add collections (results) to the indicator
- Calculate and retrieve performance metrics via the API

## Contribution
See [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines on how to contribute, report issues, or suggest improvements.

## License
This project is licensed under the MIT License. See [LICENSE](LICENSE) for more information.

## Author
- Marco Giacomini

## Acknowledgments
- .NET and C# community
- DDD and clean architecture references
- Open source contributors 