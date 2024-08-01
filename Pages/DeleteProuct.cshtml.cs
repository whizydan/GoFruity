using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GoFruity.Pages
{
    public class DeleteProuctModel : PageModel
    {
        public void OnGet()
        {
            string fruitId = Request.Query["area"];
            Config config = new Config();

            string query = $"delete from fruits where id = '{fruitId}'";
            SqlConnection conn = new SqlConnection(config.dbConnection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Redirect("/Dashboard");
            }
        }
    }
}
