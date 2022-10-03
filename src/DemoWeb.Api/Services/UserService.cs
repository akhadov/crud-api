using DemoWeb.Api.Exceptions;
using DemoWeb.Api.Interfaces.Repositories;
using DemoWeb.Api.Interfaces.Services;
using DemoWeb.Api.Models;
using DemoWeb.Api.Security;
using DemoWeb.Api.Utils;
using DemoWeb.Api.ViewModels.Users;
using Microsoft.AspNetCore.Identity;

namespace DemoWeb.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IFileService _fileService;
        public UserService(IUserRepository repository,
            IFileService fileService)
        {
            this._repository = repository;
            this._fileService = fileService;
        }
        public async Task<(int statusCode, string message)> CreateAsync(UserCreateViewModel userViewModel)
        {
            var user = (User)userViewModel;
            if (userViewModel.Image is not null)
                user.ImagePath = await _fileService.SaveImageAsync(userViewModel.Image);
            var hasherResult = PasswordHasher.Hash(userViewModel.Password);
            user.Salt = hasherResult.Salt;
            user.PasswordHash = hasherResult.Hash;
            await _repository.CreateAsync(user);
            return (statusCode: 200, message: "");
        }

        public async Task<(int statusCode, string message)> DeleteAsync(long id)
        {
            var user = await _repository.GetAsync(id);
            if (user is null) return (statusCode: 404, message: "User not found");
            else
            {
                await _repository.DeleteAsync(id);
                return (statusCode: 200, message: "");
            }
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params)
        {
            var users = (await _repository.GetAllAsync()).Skip(@params.GetSkipCount()).Take(@params.PageSize);
            var userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                userViewModels.Add((UserViewModel)user);
            }
            return userViewModels;
        }

        public async Task<(int statusCode, UserViewModel? userViewModel, string message)> GetAsync(long id)
        {
            var user = await _repository.GetAsync(id);
            if (user is null) 
                return (statusCode: 404, userViewModel: null, message: "User not found");
            
            return (statusCode: 200, userViewModel: user, message: "");
        }

        public async Task<(int statusCode, string message)> UpdateAsync(long id, UserCreateViewModel userViewModel)
        {
            var user = await _repository.GetAsync(id);
            if (user is null)
                return new StatusCodeException()


            if (userViewModel.Image is not null)
                user.ImagePath = await _fileService.SaveImageAsync(userViewModel.Image);

            var hasherResult = PasswordHasher.Hash(userViewModel.Password);
            user.Salt = hasherResult.Salt;
            user.PasswordHash = hasherResult.Hash;
            user.Email = userViewModel.Email;
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.PhoneNumber = userViewModel.PhoneNumber;

            await _repository.UpdateAsync(user);
            return (statusCode: 200, message: "");
        }
    }
}
