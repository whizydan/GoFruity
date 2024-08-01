using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GoFruity.Pages
{
    public class ProfileModel : PageModel
    {
        public string msg;
        public void OnGet()
        {
            string userId = Request.Cookies["id"];
            if (userId == null)
            {
                Response.Redirect("/Login");
            }
            if (Request.Cookies["role"] == "0")
            {
                Response.Redirect("/Dashboard");
            }

        }
        public void OnPost()
        {
            
            int userId = int.Parse(Request.Cookies["id"]);
            Config config = new Config();
            string phone = Request.Form["phone"];
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string password = Request.Form["pwd"];
            SqlConnection conn = new SqlConnection(config.dbConnection);
            string query = $"update users set password = '{password}', phone = '{phone}' , name = '{name}',email = '{email}',address = '{address}' where id = {userId}";

            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                msg = $"<div class=\"alert alert-success\" role=\"alert\">{name} has been modified</div>";
            }
            else
            {
                msg = $"<div class=\"alert alert-warning\" role=\"alert\">Could not modify {name}</div>";
            }
        }
    }
}
