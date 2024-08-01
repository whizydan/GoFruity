using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GoFruity.Pages
{
    public class CartModel : PageModel
    {
        public int cartTotal = 0;
        public string msg = "";
        public void OnGet()
        {
            var coookie = Request.Cookies["id"];
            if (coookie == null)
            {
                Response.Redirect("/Login");
            }
        }
        public void OnPost()
        {
            
            
            
                string userId = Request.Cookies["id"];
                Config config = new Config();
                SqlConnection conn = new SqlConnection(config.dbConnection);
                string fruitID = Request.Form["fruit_id"];
                conn.Open();
                string query = $"update cart set bought = 1 where user_id = {userId}";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    msg = $"<div class=\"alert alert-success\">Your items will be shipped to : {Request.Cookies["address"]} !.</div><br />";
                }
        }
    }
}
