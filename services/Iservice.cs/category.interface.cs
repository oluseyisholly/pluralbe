using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface ICategoryService
    {
        Task<StandardResponse<List<CreateCategoryDto>>> GetAllCategories();
        Task<StandardResponse<Category>> GetCategoryById();
        Task<StandardResponse<CreateCategoryDto>> CreateCategory(
            CreateCategoryDto createCategoryDto
        );
        Task<StandardResponse<CreateCategoryDto>> DeleteCategory(int Id);
        Task<StandardResponse<UpdateCategoryDto>> UpdateCategory(
            int Id,
            UpdateCategoryDto createCategoryDto
        );

        Task<StandardResponse<PaginatedResponse<CategoryDto>>> GetPaginatedAllCategories(
            PaginationQuery query
        );
    }
}
