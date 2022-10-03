using DemoWeb.Api.Models;

namespace DemoWeb.Api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllAsync();

        Task<User> CreateAsync(User user);

        Task<User?> GetAsync(long id);

        Task<bool> DeleteAsync(long id);

        Task<User> UpdateAsync(User user);
    }
}
