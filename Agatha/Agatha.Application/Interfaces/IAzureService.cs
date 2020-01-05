using Agatha.Application.ProductImages.Models;
using System.Threading.Tasks;

namespace Agatha.Application.Interfaces
{
    public interface IAzureService
    {
        Task<string> UploadImageAsync(ImageUpload imageUpload);
    }
}
