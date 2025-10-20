using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceWebApi.Common.Model;

namespace EcommerceWebApi.Models
{
    public class Order : Base
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = OrderStatus.pending.ToString(); // e.g. Paid, Shipped, Delivered
        public ICollection<OrderItem> Items { get; set; } = null!;
        public Payment Payment { get; set; } = null!;
        public int? ShippingAddressId { get; set; }
        public ShippingAddress? ShippingAddress { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string ShipToName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string ShipToStreet { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string ShipToCity { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string ShipToState { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string ShipToCountry { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string ShipToZipCode { get; set; } = null!;
    }
}
