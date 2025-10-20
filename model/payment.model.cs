using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceWebApi.Common.Model;

namespace EcommerceWebApi.Models
{
    public class Payment : Base
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public string Status { get; set; } = PaymentStatus.paid.ToString(); // Paid, Failed, Refunded
        public DateTime PaidAt { get; set; }
    }
}
