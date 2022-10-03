using DemoWeb.Api.Models;

namespace DemoWeb.Api.ViewModels.Users
{
    public class UserViewModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string ImageUrl { get; set; } = String.Empty;

        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImagePath
            };
        }
    }
}
