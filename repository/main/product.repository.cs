using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Repository
{
    public class ProductRepository(AppDbContext context, IMapper mapper)
        : BaseRepository<Product>(context.Products, context, mapper),
            IProductRepository { }
}
