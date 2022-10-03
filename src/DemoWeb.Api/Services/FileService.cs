using DemoWeb.Api.Helpers;
using DemoWeb.Api.Interfaces.Services;

namespace DemoWeb.Api.Services
{
    public class FileService : IFileService
    {
        private readonly string _basePath = String.Empty;
        private const string _imagesFolderName = "images";
        public FileService(IWebHostEnvironment env)
        {
            _basePath = env.WebRootPath;
        }
        // filename = IMG_32Ffef_4543_rasm.jpg
        // partPath = images/IMG_32Ffef_4543_rasm.jpg
        // server = kun.uz/images/IMG_32Ffef_4543_rasm.jpg
        public async Task<string> SaveImageAsync(IFormFile image)
        {
            string filename = ImageHelper.MakeImageName(image.FileName);
            string partPath = Path.Combine(_imagesFolderName, filename);
            string path = Path.Combine(_basePath, partPath);
            await image.CopyToAsync(new FileStream(path, FileMode.Create));
            return partPath;
        }
    }
}
