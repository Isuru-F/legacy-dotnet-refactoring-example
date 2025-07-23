using LegacyECommerceApi.Models;
using Xunit;

namespace LegacyECommerceApi.Tests
{
    public class ModelTests
    {
        [Fact]
        public void Customer_WithValidData_ShouldCreateInstance()
        {
            // Arrange & Act
            var customer = new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123-456-7890",
                Address = "123 Main St",
                CreatedDate = DateTime.UtcNow
            };

            // Assert
            Assert.Equal(1, customer.CustomerId);
            Assert.Equal("John", customer.FirstName);
            Assert.Equal("Doe", customer.LastName);
            Assert.Equal("john.doe@example.com", customer.Email);
            Assert.Equal("123-456-7890", customer.Phone);
            Assert.Equal("123 Main St", customer.Address);
            Assert.True(customer.CreatedDate > DateTime.MinValue);
        }

        [Fact]
        public void Product_WithValidData_ShouldCreateInstance()
        {
            // Arrange & Act
            var product = new Product
            {
                ProductId = 1,
                Name = "Test Product",
                Description = "Test Description",
                Price = 19.99m,
                StockQuantity = 100,
                Category = "Electronics",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            // Assert
            Assert.Equal(1, product.ProductId);
            Assert.Equal("Test Product", product.Name);
            Assert.Equal("Test Description", product.Description);
            Assert.Equal(19.99m, product.Price);
            Assert.Equal(100, product.StockQuantity);
            Assert.Equal("Electronics", product.Category);
            Assert.True(product.IsActive);
            Assert.True(product.CreatedDate > DateTime.MinValue);
        }

        [Fact]
        public void Order_WithValidData_ShouldCreateInstance()
        {
            // Arrange & Act
            var order = new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 99.99m,
                Status = "Pending",
                ShippingAddress = "456 Oak Ave",
                OrderItems = new List<OrderItem>()
            };

            // Assert
            Assert.Equal(1, order.OrderId);
            Assert.Equal(1, order.CustomerId);
            Assert.True(order.OrderDate > DateTime.MinValue);
            Assert.Equal(99.99m, order.TotalAmount);
            Assert.Equal("Pending", order.Status);
            Assert.Equal("456 Oak Ave", order.ShippingAddress);
            Assert.NotNull(order.OrderItems);
            Assert.Empty(order.OrderItems);
        }

        [Fact]
        public void OrderItem_WithValidData_ShouldCreateInstance()
        {
            // Arrange & Act
            var orderItem = new OrderItem
            {
                OrderItemId = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 2,
                UnitPrice = 25.50m
            };

            // Assert
            Assert.Equal(1, orderItem.OrderItemId);
            Assert.Equal(1, orderItem.OrderId);
            Assert.Equal(1, orderItem.ProductId);
            Assert.Equal(2, orderItem.Quantity);
            Assert.Equal(25.50m, orderItem.UnitPrice);
        }

        [Fact]
        public void Customer_DefaultConstructor_ShouldInitializeWithDefaults()
        {
            // Arrange & Act
            var customer = new Customer();

            // Assert
            Assert.Equal(0, customer.CustomerId);
            Assert.Equal(string.Empty, customer.FirstName);
            Assert.Equal(string.Empty, customer.LastName);
            Assert.Equal(string.Empty, customer.Email);
            Assert.Null(customer.Phone);
            Assert.Null(customer.Address);
            Assert.Equal(DateTime.MinValue, customer.CreatedDate);
        }

        [Fact]
        public void Order_DefaultConstructor_ShouldInitializeOrderItemsList()
        {
            // Arrange & Act
            var order = new Order();

            // Assert
            Assert.NotNull(order.OrderItems);
            Assert.Empty(order.OrderItems);
        }
    }
}
