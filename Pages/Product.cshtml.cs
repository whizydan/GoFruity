using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GoFruity.Pages
{
    public class ProductModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var coookie = Request.Cookies["id"];
            if (coookie == null)
            {
                Response.Redirect("/Login");
            }

            string userId = Request.Cookies["id"];
            Config config = new Config();
            SqlConnection conn = new SqlConnection(config.dbConnection);
            string fruitID = Request.Form["fruit_id"];
            string query = $"insert into cart(fruit_id,user_id,bought) values('{fruitID}','{userId}',0)";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Redirect("/Cart");
            }
        }
    }
}
