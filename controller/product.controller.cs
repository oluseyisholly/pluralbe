using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IService;
using EcommerceWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    // [Authorize(Roles = nameof(RoleEnum.Admin))]
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class ProductController(IProductService ProductService) : ControllerBase
    {
        private readonly IProductService _ProductService = ProductService;

        [HttpGet("all")]
        public async Task<IActionResult> GetPaginatedAllProducts([FromQuery] ProductsQuery query)
        {
            var Products = await _ProductService.GetPaginatedAllProducts(query);
            return Ok(Products);
        }

        // [HttpGet("all")]
        // [AllowAnonymous]
        // public async Task<IActionResult> GetAll()
        // {
        //     var Products = await _ProductService.GetAllCategories();
        //     return Ok(Products);
        // }

        // [HttpGet("{id}")]
        // // [AllowAnonymous]

        // public IActionResult GetById(
        //     int id
        // // [FromProductClaim(ClaimTypes.NameIdentifier)] string ProductId
        // )
        // {
        //     var item = new { Id = id, Name = $"Item {id}" };
        //     return Ok(item);
        // }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var data = await _ProductService.CreateProduct(createProductDto);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var data = await _ProductService.DeleteProduct(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteProduct(
            int id,
            [FromBody] UpdateProductDto updateProductDto
        )
        {
            var data = await _ProductService.UpdateProduct(id, updateProductDto);
            return Ok(data);
        }
    }
}
