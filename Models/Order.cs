using System.ComponentModel.DataAnnotations;

namespace LegacyECommerceApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        
        public Customer? Customer { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0")]
        public decimal TotalAmount { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";
        
        [StringLength(500)]
        public string? ShippingAddress { get; set; }
        
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
    
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        
        [Required]
        public int OrderId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        public Product? Product { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
        public decimal UnitPrice { get; set; }
    }
}
