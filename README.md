# Legacy E-Commerce API - System.Data.SqlClient Migration Demo

## 🚨 PROJECT STATUS: LEGACY CODEBASE REQUIRING MIGRATION

This is a .NET 7 Web API application that intentionally demonstrates a **realistic legacy enterprise codebase** using deprecated technologies that require immediate migration for security, compliance, and support reasons.

## 📊 Current Technology Stack

| Component | Technology | Version | Status |
|-----------|------------|---------|---------|
| **Framework** | .NET | 7.0 | ❌ **End of Life** (May 2024) |
| **Database Driver** | System.Data.SqlClient | 4.8.5 | ❌ **Deprecated** |
| **Database** | SQL Server LocalDB | Latest | ✅ Supported |
| **API Documentation** | Swagger/OpenAPI | 6.5.0 | ✅ Supported |
| **Dependency Injection** | Microsoft.Extensions.DI | Built-in | ✅ Supported |

## 🔴 Critical Legacy Issues & Enterprise Support Problems

### 1. **SECURITY VULNERABILITIES**
```
WARNING NU1903: Package 'System.Data.SqlClient' 4.8.5 has a known 
HIGH SEVERITY vulnerability: https://github.com/advisories/GHSA-98g6-xh36-x2p7
```
- **Impact**: Production deployment blocked by security scanners
- **Risk**: Potential SQL injection and connection string exposure
- **Compliance**: Fails SOC2, PCI-DSS, and enterprise security audits

### 2. **FRAMEWORK END-OF-LIFE**
```
WARNING NETSDK1138: The target framework 'net7.0' is out of support 
and will not receive security updates
```
- **Impact**: No security patches, bug fixes, or support from Microsoft
- **Risk**: Zero-day vulnerabilities will remain unpatched
- **Enterprise**: Violates enterprise support lifecycle policies

### 3. **DEPRECATED DATABASE DRIVER**
- **System.Data.SqlClient** deprecated since .NET Core 2.0 (2018)
- **Microsoft recommendation**: Migrate to Microsoft.Data.SqlClient
- **Features missing**: Modern async patterns, performance improvements
- **Support**: No new features, limited bug fixes only

### 4. **INSECURE CONNECTION CONFIGURATION**
```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LegacyECommerceDb;Trusted_Connection=true;Encrypt=false"
```
- **Issue**: `Encrypt=false` transmits data in plaintext
- **Compliance**: Violates data protection regulations (GDPR, HIPAA)
- **Modern requirement**: Encryption by default in newer drivers

## 🔧 Legacy Technical Debt

### Code Pattern Issues
1. **Mixed Async/Sync Operations**
   ```csharp
   // ❌ Inconsistent patterns
   public async Task<Customer?> GetByIdAsync(int id) // Async method
   public Customer Add(Customer customer)           // Sync method
   ```

2. **Manual Resource Management**
   ```csharp
   // ❌ Manual disposal patterns
   using (var connection = new SqlConnection(_connectionString))
   using (var command = new SqlCommand(query, connection))
   ```

3. **Legacy Namespace Imports**
   ```csharp
   using System.Data;
   using System.Data.SqlClient; // ❌ Deprecated namespace
   ```

4. **Traditional ADO.NET Patterns**
   - Manual parameter binding with `AddWithValue()`
   - String-based SQL queries without modern query builders
   - No modern features like bulk operations or async enumeration

## 🏢 Enterprise Impact Assessment

### **Immediate Risks**
- **Security**: Production deployment blocked by vulnerability scanners
- **Compliance**: Audit failures for security frameworks
- **Support**: No Microsoft support for framework or driver issues
- **Performance**: Missing modern optimizations and features

### **Business Continuity Issues**
- **Maintenance**: Difficulty finding developers familiar with legacy patterns
- **Scalability**: Performance bottlenecks with outdated data access patterns
- **Integration**: Compatibility issues with modern cloud services
- **Cost**: Higher maintenance costs due to technical debt

### **Regulatory Compliance Failures**
- **SOC 2**: Security controls around encryption in transit
- **PCI DSS**: Data encryption requirements for payment systems
- **GDPR/HIPAA**: Data protection in transit requirements
- **ISO 27001**: Information security management standards

## 🎯 Migration Requirements

### **Critical Path Items**
1. **Framework Migration**: .NET 7 → .NET 8+ (LTS)
2. **Driver Migration**: System.Data.SqlClient → Microsoft.Data.SqlClient
3. **Security**: Enable connection encryption by default
4. **Patterns**: Standardize on async/await throughout
5. **Performance**: Implement modern data access patterns

### **Compliance Targets**
- Remove all security vulnerabilities
- Enable encryption in transit
- Implement modern authentication patterns
- Add comprehensive audit logging
- Establish proper error handling and monitoring

## Domain Model

The application manages a simple e-commerce system with:
- **Customers** - Customer information and contact details
- **Products** - Product catalog with inventory
- **Orders** - Customer orders with line items

## Database Setup

1. Ensure SQL Server LocalDB is installed
2. Run the SQL script in `DatabaseSetup.sql` to create the database and sample data
3. The connection string in `appsettings.json` points to LocalDB with `Encrypt=false`

## Running the Application

```bash
dotnet build
dotnet run
```

Navigate to `https://localhost:7xxx/swagger` to access the Swagger UI.

## API Endpoints

### Customers
- `GET /api/customers` - Get all customers
- `GET /api/customers/{id}` - Get customer by ID
- `POST /api/customers` - Create new customer
- `PUT /api/customers/{id}` - Update customer
- `DELETE /api/customers/{id}` - Delete customer
- `GET /api/customers/by-email/{email}` - Get customer by email

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create new product
- `PUT /api/products/{id}` - Update product
- `DELETE /api/products/{id}` - Delete product
- `GET /api/products/category/{category}` - Get products by category
- `GET /api/products/active` - Get active products with stock

### Orders
- `GET /api/orders` - Get all orders
- `GET /api/orders/{id}` - Get order by ID with line items
- `POST /api/orders` - Create new order with items
- `PUT /api/orders/{id}` - Update order
- `DELETE /api/orders/{id}` - Delete order and items
- `GET /api/orders/customer/{customerId}` - Get orders by customer
- `GET /api/orders/status/{status}` - Get orders by status

## Known Issues (Perfect for Migration Practice)

1. **Security Vulnerability**: System.Data.SqlClient has known high severity vulnerabilities
2. **Deprecated Package**: System.Data.SqlClient is no longer maintained
3. **Connection String**: Uses `Encrypt=false` which is insecure
4. **Mixed Patterns**: Inconsistent async/sync patterns in repository methods
5. **Manual Resource Management**: Manual connection/command disposal

## Migration Goals

This codebase is designed to practice migrating:
1. **System.Data.SqlClient** → **Microsoft.Data.SqlClient**
2. Legacy connection strings → Modern secure connection strings
3. Mixed sync/async patterns → Consistent async patterns
4. Manual resource management → Modern `using` statements and patterns
5. Update to current .NET version

## Build Warnings (Expected)

You'll see these warnings when building - they indicate the migration need:
- NETSDK1138: .NET 7.0 is out of support
- NU1903: System.Data.SqlClient has known vulnerabilities

This is exactly what enterprises face with legacy codebases!
