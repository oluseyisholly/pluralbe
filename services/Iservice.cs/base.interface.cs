using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface IBaseService
    {
        Task<StandardResponse<List<User>>> GetAll();
        User GetById();
        Task<StandardResponse<CreateUserDto>> Create(CreateUserDto createUserDto);
        Task<StandardResponse<CreateUserDto>> Delete(int Id);
        Task<StandardResponse<CreateUserDto>> Update(UpdateUserDto createUserDto, int Id);
        Task<StandardResponse<PaginatedResponse<User>>> GetPaginatedAll(PaginationQuery query);
    }
}
