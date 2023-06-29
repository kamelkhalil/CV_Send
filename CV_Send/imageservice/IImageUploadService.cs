using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CV_Send.imageservice
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile Im);
    }
}
