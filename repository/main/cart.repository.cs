using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Repository
{
    public class CartRepository(AppDbContext context, IMapper mapper)
        : BaseRepository<Cart>(context.Carts, context, mapper),
            ICartRepository { }
}
