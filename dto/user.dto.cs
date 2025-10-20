using System.ComponentModel.DataAnnotations;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Dto
{
    public class CreateUserDto : LoginUserDto
    {
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
    }

    public class LoginUserDto
    {
        [Required]
        [StringLength(50)]
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }

    public class UpdateUserDto
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }
    }

    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }

    public class LoginResponseDto
    {
        [Required]
        [StringLength(50)]
        public required UserDto Data { get; set; }

        [Required]
        [EmailAddress]
        public string? Token { get; set; }
    }
}
