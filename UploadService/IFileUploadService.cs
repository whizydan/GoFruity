using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GoFruity.UploadService
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);
        
    }
}
