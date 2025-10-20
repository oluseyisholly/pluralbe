using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface IPaymentService
    {
        Task<StandardResponse<List<CreatePaymentDto>>> GetAllPayments();
        Task<StandardResponse<Payment>> GetPaymentById();
        Task<StandardResponse<UpdatePaymentDto>> UpdatePayment(
            int Id,
            UpdatePaymentDto createPaymentDto
        );
        Task<StandardResponse<PaginatedResponse<PaymentDto>>> GetPaginatedAllPayments(
            PaymentsQuery query
        );
    }
}
