using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoFruity.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            Response.Cookies.Delete("id");
            Response.Cookies.Delete("role");
            Response.Cookies.Delete("address");
            Response.Cookies.Delete("phone");
            Response.Cookies.Delete("rname");
            Response.Cookies.Delete("email");

            Response.Redirect("/Index");
        }
    }
}
