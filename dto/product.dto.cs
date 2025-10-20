using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;

namespace EcommerceWebApi.Models
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateProductDto
    {
        [MaxLength(120)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; } = null!;

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductDto : BaseDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; } = null!;
    }

    public class ProductsQuery : PaginationQuery
    {
        public int? CategoryId { get; set; }
    }
}
