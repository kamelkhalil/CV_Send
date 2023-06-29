using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace CV_Send.imageservice
{
    public class LocalImageUploadService : IImageUploadService
    {
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment;
        public LocalImageUploadService(Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public async Task<string> UploadImageAsync(IFormFile Im)
        {
            var ImagePath = Path.Combine(Environment.ContentRootPath, @"wwwroot\Images", Im.FileName);
            using var fileStream = new FileStream(ImagePath, FileMode.Create);
            await Im.CopyToAsync(fileStream);
            return "/Images/" +Im.FileName;
        }
    }
}
