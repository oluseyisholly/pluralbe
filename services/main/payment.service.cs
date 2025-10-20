using System.Linq.Expressions;
using AutoMapper;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Exceptions;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.IService;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Service
{
    public class PaymentService(IPaymentRepository PaymentRepository, IMapper mapper)
        : IPaymentService
    {
        private readonly IPaymentRepository _PaymentRepository = PaymentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<StandardResponse<CreatePaymentDto>> CreatePayment(
            CreatePaymentDto createPaymentDto
        )
        {
            var Payment = _mapper.Map<Payment>(createPaymentDto);

            await _PaymentRepository.Create(Payment);

            return new StandardResponse<CreatePaymentDto>
            {
                Message = "Created Successfully",
                Data = createPaymentDto,
            };
        }

        public async Task<StandardResponse<List<CreatePaymentDto>>> GetAllPayments()
        {
            var Payments = await _PaymentRepository.GetAll();

            var result = _mapper.Map<List<CreatePaymentDto>>(Payments);

            return new StandardResponse<List<CreatePaymentDto>>
            {
                Message = "success",
                Data = result,
            };
        }

        public async Task<StandardResponse<PaginatedResponse<PaymentDto>>> GetPaginatedAllPayments(
            PaymentsQuery query
        )
        {
            var filter =
                query.CategoryId != null
                    ? (Expression<Func<Payment, bool>>)(p => p.OrderId == query.OrderId)
                    : null;

            var Payments = await _PaymentRepository.GetPaginatedAll(query, filter, p => p.Order);

            var mappedItems = _mapper.Map<List<PaymentDto>>(Payments.Data);

            return new StandardResponse<PaginatedResponse<PaymentDto>>
            {
                Message = "success",
                Data = new PaginatedResponse<PaymentDto>(
                    mappedItems,
                    Payments.TotalRecords,
                    Payments.PageNumber,
                    Payments.PageSize
                ),
            };
        }

        public async Task<StandardResponse<CreatePaymentDto>> DeletePayment(int Id)
        { //check if Payment exists
            var existingPayment = await _PaymentRepository.GetById(Id);

            if (existingPayment is null)
            {
                throw new UnprocessibleEntityException("Payment Does Not Exist");
            }

            var result = await _PaymentRepository.Delete(existingPayment);

            var Payment = _mapper.Map<CreatePaymentDto>(result);

            return new StandardResponse<CreatePaymentDto> { Message = "success", Data = Payment };
        }

        public async Task<StandardResponse<UpdatePaymentDto>> UpdatePayment(
            int Id,
            UpdatePaymentDto updatePaymentDto
        )
        { //check if Payment exists
            var existingPayment = await _PaymentRepository.GetById(Id);

            if (existingPayment is null)
            {
                throw new UnprocessibleEntityException("Payment Does Not Exist");
            }

            var Payment = _mapper.Map(updatePaymentDto, existingPayment);

            await _PaymentRepository.Update(Payment);

            return new StandardResponse<UpdatePaymentDto>
            {
                Message = "success",
                Data = updatePaymentDto,
            };
        }

        public async Task<StandardResponse<Payment>> GetPaymentById()
        {
            throw new NotImplementedException();
        }
    }
}
