using GoFruity.UploadService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace GoFruity.Pages
{
    public class DatabaseModel : PageModel
    {
        public string msg = "";
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            Config config = new Config();
            config.Exportdatabase();

            msg = msg = $"<div class=\"alert alert-success\" role=\"alert\">Files have been saved to wwwroot/reports! </div>";
        }
    }
}
