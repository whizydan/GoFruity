using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GoFruity.Pages
{
    public class DeleteModel : PageModel
    {
        public void OnGet()
        {
            string cart_id = Request.Query["area"];
            Config config = new Config();
            SqlConnection conn = new SqlConnection(config.dbConnection);
            string query = $"delete from cart where id = {cart_id}";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            var result = cmd.ExecuteNonQuery();
            if(result > 0)
            {
                Response.Redirect("/Cart");
            }
        }
    }
}
