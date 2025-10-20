using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface ICartService
    {
        Task<StandardResponse<List<CreateCartDto>>> GetAllCarts();
        Task<StandardResponse<Cart>> GetCartById();
        Task<StandardResponse<CreateCartDto>> CreateCart(CreateCartDto createCartDto);
        Task<StandardResponse<CreateCartDto>> DeleteCart(int Id);
        Task<StandardResponse<UpdateCartDto>> UpdateCart(
            int Id,
            UpdateCartDto createCartDto
        );
        Task<StandardResponse<PaginatedResponse<CartDto>>> GetPaginatedAllCarts(
            CartsQuery query
        );
    }
}
