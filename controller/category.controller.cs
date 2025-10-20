using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceWebApi.Common.Attributes;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IService;
using EcommerceWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController(ICategoryService CategoryService) : ControllerBase
    {
        private readonly ICategoryService _CategoryService = CategoryService;

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaginatedAllCategorys([FromQuery] PaginationQuery query)
        {
            var Categorys = await _CategoryService.GetPaginatedAllCategories(query);
            return Ok(Categorys);
        }

        // [HttpGet("all")]
        // [AllowAnonymous]
        // public async Task<IActionResult> GetAll()
        // {
        //     var Categorys = await _CategoryService.GetAllCategories();
        //     return Ok(Categorys);
        // }

        // [HttpGet("{id}")]
        // // [AllowAnonymous]

        // public IActionResult GetById(
        //     int id
        // // [FromCategoryClaim(ClaimTypes.NameIdentifier)] string CategoryId
        // )
        // {
        //     var item = new { Id = id, Name = $"Item {id}" };
        //     return Ok(item);
        // }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCategory(
            [FromBody] CreateCategoryDto createCategoryDto
        )
        {
            var data = await _CategoryService.CreateCategory(createCategoryDto);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var data = await _CategoryService.DeleteCategory(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCategory(
            int id,
            [FromBody] UpdateCategoryDto updateCategoryDto
        )
        {
            var data = await _CategoryService.UpdateCategory(id, updateCategoryDto);
            return Ok(data);
        }
    }
}
