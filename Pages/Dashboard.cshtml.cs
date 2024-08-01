using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoFruity.Pages
{
    public class DashboardModel : PageModel
    {
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
            else
            {
                Response.Redirect("/Login");
            }
        }
    }
}
