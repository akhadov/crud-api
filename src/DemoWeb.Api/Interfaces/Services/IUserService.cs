using DemoWeb.Api.Utils;
using DemoWeb.Api.ViewModels.Users;

namespace DemoWeb.Api.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params);

        Task<(int statusCode, UserViewModel? userViewModel, string message)> GetAsync(long id);

        Task<(int statusCode, string message)> CreateAsync(UserCreateViewModel userViewModel);

        Task<(int statusCode, string message)> UpdateAsync(long id, UserCreateViewModel userViewModel);

        Task<(int statusCode, string message)> DeleteAsync(long id);
    }
}
