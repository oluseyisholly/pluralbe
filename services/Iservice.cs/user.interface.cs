using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface IUserService
    {
        Task<StandardResponse<List<UserDto>>> GetAllUsers();
        Task<StandardResponse<LoginResponseDto>> LoginUser(LoginUserDto loginUserDto);
        Task<StandardResponse<User>> GetUsersById();
        Task<StandardResponse<CreateUserDto>> CreateUser(CreateUserDto createUserDto);
        Task<StandardResponse<User>> DeleteUser(int Id);
        Task<StandardResponse<UpdateUserDto>> UpdateUser(int Id, UpdateUserDto createUserDto);

        Task<StandardResponse<PaginatedResponse<UserDto>>> GetPaginatedAllUsers(
            PaginationQuery query
        );
    }
}
