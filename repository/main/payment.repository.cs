using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Repository
{
    public class PaymentRepository(AppDbContext context, IMapper mapper)
        : BaseRepository<Payment>(context.Payments, context, mapper),
            IPaymentRepository { }
}
