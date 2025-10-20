using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    public class ShippingAddress : Base
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Street { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string State { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string ZipCode { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Country { get; set; } = null!;

        public bool IsDefault { get; set; } = false;
    }
}
