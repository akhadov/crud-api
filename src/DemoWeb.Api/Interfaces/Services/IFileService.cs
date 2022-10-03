namespace DemoWeb.Api.Interfaces.Services
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile image);
    }
}
