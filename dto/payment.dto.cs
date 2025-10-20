using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;

namespace EcommerceWebApi.Models
{
    public class CreatePaymentDto
    {
        public int OrderId { get; set; }
    }

    public class UpdatePaymentDto
    {
        public int OrderId { get; set; }
    }

    public class PaymentDto : BaseDto
    {
        public int OrderId { get; set; }
    }

    public class PaymentsQuery : PaginationQuery
    {
        public int? OrderId { get; set; }
    }
}
