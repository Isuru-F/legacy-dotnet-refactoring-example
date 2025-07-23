-- Create database (run this in SQL Server Management Studio or similar tool)
-- CREATE DATABASE LegacyECommerceDb;
-- USE LegacyECommerceDb;

-- Create Customers table
CREATE TABLE Customers (
    CustomerId int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(100) NOT NULL,
    LastName nvarchar(100) NOT NULL,
    Email nvarchar(255) NOT NULL UNIQUE,
    Phone nvarchar(20) NULL,
    Address nvarchar(500) NULL,
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE()
);

-- Create Products table
CREATE TABLE Products (
    ProductId int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(200) NOT NULL,
    Description nvarchar(1000) NULL,
    Price decimal(18,2) NOT NULL,
    StockQuantity int NOT NULL DEFAULT 0,
    Category nvarchar(100) NULL,
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    IsActive bit NOT NULL DEFAULT 1
);

-- Create Orders table
CREATE TABLE Orders (
    OrderId int IDENTITY(1,1) PRIMARY KEY,
    CustomerId int NOT NULL,
    OrderDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    TotalAmount decimal(18,2) NOT NULL,
    Status nvarchar(50) NOT NULL DEFAULT 'Pending',
    ShippingAddress nvarchar(500) NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

-- Create OrderItems table
CREATE TABLE OrderItems (
    OrderItemId int IDENTITY(1,1) PRIMARY KEY,
    OrderId int NOT NULL,
    ProductId int NOT NULL,
    Quantity int NOT NULL,
    UnitPrice decimal(18,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- Insert sample data
INSERT INTO Customers (FirstName, LastName, Email, Phone, Address) VALUES
('John', 'Smith', 'john.smith@email.com', '555-0101', '123 Main St, City, State 12345'),
('Jane', 'Johnson', 'jane.johnson@email.com', '555-0102', '456 Oak Ave, City, State 12346'),
('Bob', 'Williams', 'bob.williams@email.com', '555-0103', '789 Pine Rd, City, State 12347');

INSERT INTO Products (Name, Description, Price, StockQuantity, Category) VALUES
('Laptop Computer', 'High-performance laptop for business and gaming', 999.99, 50, 'Electronics'),
('Wireless Mouse', 'Ergonomic wireless mouse with USB receiver', 29.99, 100, 'Electronics'),
('Office Chair', 'Comfortable ergonomic office chair', 199.99, 25, 'Furniture'),
('Coffee Mug', 'Ceramic coffee mug 12oz', 9.99, 200, 'Kitchen'),
('Notebook', 'Spiral bound notebook 200 pages', 4.99, 150, 'Office Supplies');

INSERT INTO Orders (CustomerId, TotalAmount, Status, ShippingAddress) VALUES
(1, 1029.98, 'Completed', '123 Main St, City, State 12345'),
(2, 209.98, 'Pending', '456 Oak Ave, City, State 12346'),
(3, 39.98, 'Shipped', '789 Pine Rd, City, State 12347');

INSERT INTO OrderItems (OrderId, ProductId, Quantity, UnitPrice) VALUES
(1, 1, 1, 999.99),
(1, 2, 1, 29.99),
(2, 3, 1, 199.99),
(2, 4, 1, 9.99),
(3, 2, 1, 29.99),
(3, 4, 1, 9.99);

-- Create indexes for better performance
CREATE INDEX IX_Customers_Email ON Customers(Email);
CREATE INDEX IX_Products_Category ON Products(Category);
CREATE INDEX IX_Products_IsActive ON Products(IsActive);
CREATE INDEX IX_Orders_CustomerId ON Orders(CustomerId);
CREATE INDEX IX_Orders_Status ON Orders(Status);
CREATE INDEX IX_OrderItems_OrderId ON OrderItems(OrderId);
CREATE INDEX IX_OrderItems_ProductId ON OrderItems(ProductId);
