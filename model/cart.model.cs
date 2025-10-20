using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    public class Cart : Base
    {
        public int? UserId { get; set; }
        public User? User { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<CartItem> Items { get; set; } = null!;
    }
}
