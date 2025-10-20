using EcommerceWebApi.Models;

namespace EcommerceWebApi.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmail(string email);
    }
}
