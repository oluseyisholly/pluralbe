using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    public class ProductReview : Base
    {
        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        // FK to User
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // FK to Product
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
