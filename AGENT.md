# AGENT.md - Legacy .NET E-Commerce API Migration Project

## Build/Test Commands
- `dotnet build` - Build the project
- `dotnet run` - Run the application (https://localhost:7xxx/swagger for API docs)
- `dotnet clean` - Clean build outputs
- No unit tests currently exist in this legacy codebase

## Architecture
- **Framework**: .NET 7 Web API (LEGACY - requires migration to .NET 8+)
- **Database**: SQL Server LocalDB with deprecated System.Data.SqlClient driver
- **Pattern**: Repository pattern with controller-based REST API
- **Structure**: Controllers/ (API endpoints), Models/ (domain entities), Repositories/ (data access)
- **DI Container**: Built-in Microsoft.Extensions.DependencyInjection

## Database & APIs
- **Connection**: LocalDB via "DefaultConnection" in appsettings.json (INSECURE: Encrypt=false)
- **Entities**: Customer, Product, Order with CRUD operations
- **Data Access**: Raw ADO.NET with manual resource management (legacy pattern)

## Code Style & Conventions
- **Namespace**: Uses project-based namespacing (LegacyECommerceApi.*)
- **Async**: Mixed async/sync patterns (INCONSISTENT - needs standardization)
- **Imports**: Uses deprecated System.Data.SqlClient (must migrate to Microsoft.Data.SqlClient)
- **Error Handling**: Try-catch with structured logging using ILogger
- **Validation**: Data annotations on models, ModelState validation in controllers
- **Naming**: PascalCase for public members, camelCase for parameters/locals

## Critical Legacy Issues
- System.Data.SqlClient has HIGH SEVERITY security vulnerabilities
- .NET 7 is End-of-Life (requires .NET 8+ migration)
- Connection string uses Encrypt=false (security violation)
- Mixed async/sync repository methods need standardization
