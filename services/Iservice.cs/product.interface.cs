using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface IProductService
    {
        Task<StandardResponse<List<CreateProductDto>>> GetAllProducts();
        Task<StandardResponse<Product>> GetProductById();
        Task<StandardResponse<CreateProductDto>> CreateProduct(CreateProductDto createProductDto);
        Task<StandardResponse<CreateProductDto>> DeleteProduct(int Id);
        Task<StandardResponse<UpdateProductDto>> UpdateProduct(
            int Id,
            UpdateProductDto createProductDto
        );
        Task<StandardResponse<PaginatedResponse<ProductDto>>> GetPaginatedAllProducts(
            ProductsQuery query
        );
    }
}
