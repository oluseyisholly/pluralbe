using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceWebApi.Common.Model;

namespace EcommerceWebApi.Models
{
    public class Product : Base
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = null!;
        public ICollection<CartItem> CartItems { get; set; } = null!;
    }
}
