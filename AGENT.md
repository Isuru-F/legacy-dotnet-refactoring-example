# AGENT.md - Modern .NET E-Commerce API

## Build/Test Commands
- `dotnet build` - Build the project
- `dotnet run` - Run the application (https://localhost:7xxx/swagger for API docs)
- `dotnet clean` - Clean build outputs
- `dotnet test` - Run unit tests

## Architecture
- **Framework**: .NET 8 Web API (Modern LTS version)
- **Database**: SQL Server LocalDB with Microsoft.Data.SqlClient driver
- **Pattern**: Repository pattern with controller-based REST API
- **Structure**: Controllers/ (API endpoints), Models/ (domain entities), Repositories/ (data access), Tests/ (unit tests)
- **DI Container**: Built-in Microsoft.Extensions.DependencyInjection

## Database & APIs
- **Connection**: LocalDB via "DefaultConnection" in appsettings.json (SECURE: Encrypt=true)
- **Entities**: Customer, Product, Order with CRUD operations
- **Data Access**: Raw ADO.NET with async/await patterns throughout

## Code Style & Conventions
- **Namespace**: Uses project-based namespacing (LegacyECommerceApi.*)
- **Async**: Fully async/await patterns standardized across all repositories
- **Imports**: Uses modern Microsoft.Data.SqlClient (secure and maintained)
- **Error Handling**: Try-catch with structured logging using ILogger
- **Validation**: Data annotations on models, ModelState validation in controllers
- **Naming**: PascalCase for public members, camelCase for parameters/locals

## Modernization Complete
- ✅ Upgraded to .NET 8 (resolved EOL warnings)
- ✅ Migrated to Microsoft.Data.SqlClient (resolved security vulnerabilities)
- ✅ Enabled connection encryption (Encrypt=true;TrustServerCertificate=true)
- ✅ Standardized async/await patterns across all repositories
- ✅ Added comprehensive unit test coverage
