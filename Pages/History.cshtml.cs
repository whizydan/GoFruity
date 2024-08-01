using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GoFruity.Pages
{
    public class HistoryModel : PageModel
    {
        public void OnGet()
        {
            var coookie = Request.Cookies["role"];
            if (coookie == null)
            {
                Response.Redirect("/Login");
            }
            if (Request.Cookies["role"] == "0")
            {
                Response.Redirect("/Dashboard");
            }
        }
    }
}
