using AutoMapper;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class UserRepository(AppDbContext context, IMapper mapper)
        : BaseRepository<User>(context.Users, context, mapper),
            IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<User?> GetUserByEmail(string email)
        {
            var _email = email;
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
