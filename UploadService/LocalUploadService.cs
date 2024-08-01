namespace GoFruity.UploadService
{
    public class LocalUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment environment;

        public LocalUploadService(IWebHostEnvironment environment) 
        { 
            this.environment = environment;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine(environment.ContentRootPath, @"wwwroot\img", file.FileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return file.FileName;
        }
        
    }
}
