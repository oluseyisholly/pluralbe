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
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaginatedAllUsers([FromQuery] PaginationQuery query)
        {
            var users = await _userService.GetPaginatedAllUsers(query);
            return Ok(users);
        }

        // [HttpGet("all")]
        // [AllowAnonymous]
        // public async Task<IActionResult> GetAll()
        // {
        //     var users = await _userService.GetAllUsers();
        //     return Ok(users);
        // }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginUserDto loginUserDto)
        {
            var data = await _userService.LoginUser(loginUserDto);
            return Ok(data);
        }

        // [HttpGet("{id}")]
        // [AllowAnonymous]

        // public IActionResult GetById(
        //     int id
        // // [FromUserClaim(ClaimTypes.NameIdentifier)] string userId
        // )
        // {
        //     var item = new { Id = id, Name = $"Item {id}" };
        //     return Ok(item);
        // }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var data = await _userService.CreateUser(createUserDto);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var data = await _userService.DeleteUser(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var data = await _userService.UpdateUser(id, updateUserDto);
            return Ok(data);
        }
    }
}
