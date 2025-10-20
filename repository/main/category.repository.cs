using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Repository
{
    public class CategoryRepository(AppDbContext context, IMapper mapper)
        : BaseRepository<Category>(context.Categories, context, mapper),
            ICategoryRepository { }
}
