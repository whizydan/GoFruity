using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoFruity.UploadService;
using System.Data.SqlClient;

namespace GoFruity.Pages
{
    public class AddModel : PageModel
    {
        private readonly IFileUploadService fileUploadService;
        private readonly ILogger<AddModel> _logger;
        public string msg = "";

        public AddModel(ILogger<AddModel> logger,IFileUploadService fileUploadService) 
        { 
            _logger = logger;
            this.fileUploadService = fileUploadService;
        }

        public void OnGet()
        {
            var coookie = Request.Cookies["role"];
            if (coookie != null && coookie.Length > 0)
            {
                if (coookie != "0")
                {
                    Response.Redirect("/Index");
                }
            }
        }

        public async void OnPost(IFormFile file) 
        {
            if(file != null)
            {
                var image = file.FileName;
                var filename = fileUploadService.UploadFileAsync(file);
                var name = Request.Form["name"];
                var description = Request.Form["desc"];
                var price = Request.Form["price"];
                
                Config config = new Config();
                SqlConnection conn = new SqlConnection(config.dbConnection);
                string query = $"insert into fruits(name,price,description,image) values('{name}',{price},'{description}','{image}')";
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteNonQuery();
                if(result > 0)
                {
                    msg = $"<div class=\"alert alert-success\" role=\"alert\">{name} has been added</div>";
                }
                else
                {
                    msg = $"<div class=\"alert alert-warning\" role=\"alert\">Could not add {name}</div>";
                }
            }
            
        }
    }
}
