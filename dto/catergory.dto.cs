using System.ComponentModel.DataAnnotations;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Dto
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }

    public class UpdateCategoryDto
    {
        public string Name { get; set; } = null!;
    }

    public class CategoryDto : BaseDto
    {
        public string Name { get; set; } = null!;
    }
}
