using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Exceptions;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.IService;
using EcommerceWebApi.Models;
using EcommerceWebApi.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceWebApi.Service
{
    public class UserService(
        IUserRepository userRepository,
        IMapper mapper,
        IConfiguration configuration
    ) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;

        public async Task<StandardResponse<CreateUserDto>> CreateUser(CreateUserDto createUserDto)
        {
            //check if user exists
            var existingUser = await _userRepository.GetUserByEmail(createUserDto.Email);

            if (existingUser is not null)
            {
                throw new NotFoundException("User Already Exists");
            }

            var user = _mapper.Map<User>(createUserDto);

            user.PasswordHash = _passwordHasher.HashPassword(user, createUserDto.Password);

            await _userRepository.Create(user);

            return new StandardResponse<CreateUserDto>
            {
                Message = "Created Successfully",
                Data = createUserDto,
            };
        }

        public async Task<StandardResponse<LoginResponseDto>> LoginUser(LoginUserDto loginUserDto)
        {
            //check if user exists
            var existingUser = await _userRepository.GetUserByEmail(loginUserDto.Email);

            if (existingUser is null)
            {
                throw new NotFoundException("User Does Not Exist");
            }

            var hasherResult = _passwordHasher.VerifyHashedPassword(
                existingUser,
                existingUser.PasswordHash,
                loginUserDto.Password
            );

            if (hasherResult == PasswordVerificationResult.Failed)
                throw new UnauthorizedException("Invalid Password");

            var token = GenerateJwtToken(existingUser);

            var user = _mapper.Map<UserDto>(existingUser);

            user.Role = Enum.GetName(existingUser.Role) ?? string.Empty;
            // Assign enum value directly

            return new StandardResponse<LoginResponseDto>
            {
                Data = new() { Data = user, Token = token },
            };
        }

        public async Task<StandardResponse<List<UserDto>>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            var result = _mapper.Map<List<UserDto>>(users);

            return new StandardResponse<List<UserDto>> { Message = "success", Data = result };
        }

        public async Task<StandardResponse<PaginatedResponse<UserDto>>> GetPaginatedAllUsers(
            PaginationQuery query
        )
        {
            var users = await _userRepository.GetPaginatedAll(query, null);

            var mappedItems = _mapper.Map<List<UserDto>>(users.Data);

            return new StandardResponse<PaginatedResponse<UserDto>>
            {
                Message = "success",
                Data = new PaginatedResponse<UserDto>(
                    mappedItems,
                    users.TotalRecords,
                    users.PageNumber,
                    users.PageSize
                ),
            };
        }

        public async Task<StandardResponse<User>> DeleteUser(int Id)
        { //check if user exists
            var existingUser = await _userRepository.GetById(Id);

            if (existingUser is null)
            {
                throw new UnprocessibleEntityException("User Does Not Exist");
            }

            var result = await _userRepository.Delete(existingUser);

            return new StandardResponse<User> { Message = "success", Data = result };
        }

        public async Task<StandardResponse<UpdateUserDto>> UpdateUser(
            int Id,
            UpdateUserDto updateUserDto
        )
        { //check if user exists
            var existingUser = await _userRepository.GetById(Id);

            if (existingUser is null)
            {
                throw new UnprocessibleEntityException("User Does Not Exist");
            }

            var user = _mapper.Map(updateUserDto, existingUser);

            await _userRepository.Update(user);

            return new StandardResponse<UpdateUserDto>
            {
                Message = "success",
                Data = updateUserDto,
            };
        }

        public async Task<StandardResponse<User>> GetUsersById()
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
