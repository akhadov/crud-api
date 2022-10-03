using DemoWeb.Api.Dbcontexts;
using DemoWeb.Api.Interfaces.Repositories;
using DemoWeb.Api.Models;
#pragma warning disable
namespace DemoWeb.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbo;
        public UserRepository(AppDbContext appDbContext)
        {
            this._dbo = appDbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            var result = await _dbo.Users.AddAsync(user);
            await _dbo.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var result = await _dbo.Users.FindAsync(id);
            if(result is not null)
            {
                _dbo.Users.Remove(result);
                await _dbo.SaveChangesAsync();
            }
            return false;
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            return _dbo.Users;
        }


        public async Task<User?> GetAsync(long id)
        {
            var result = await _dbo.Users.FindAsync(id);
            if (result is not null) return result;
            return null;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _dbo.Update(user);
            await _dbo.SaveChangesAsync();
            return user;
        }
    }
}
