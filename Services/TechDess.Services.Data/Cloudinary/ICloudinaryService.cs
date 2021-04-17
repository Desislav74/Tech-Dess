using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TechDess.Services.Data.Cloudinary
{
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
