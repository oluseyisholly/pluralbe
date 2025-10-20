using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    public class ProductImages : Base
    {
        [Required]
        [Url]
        public string Url { get; set; } = null!;

        [MaxLength(100)]
        public string? AltText { get; set; }

        public bool IsPrimary { get; set; } = false;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
