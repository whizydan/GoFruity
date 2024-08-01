using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Xml.Xsl;
using System.Xml;

namespace GoFruity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var coookie = Request.Cookies["role"];
            if (coookie != null && coookie.Length > 0)
            {
                if (coookie == "0")
                {
                    Response.Redirect("/Dashboard");
                }
            }
        }

    }
}