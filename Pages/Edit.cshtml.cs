using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GoFruity.Pages
{
    public class EditModel : PageModel
    {
        public string id = "";
        public void OnGet()
        {
            id = Request.Query["area"];
        }
        public void OnPost()
        {
            string fruitId = Request.Form["fruit_id"];
            string name = Request.Form["name"];
            string description = Request.Form["description"];
            string price = Request.Form["price"];
            Config config = new Config();
            SqlConnection conn = new SqlConnection(config.dbConnection);
            string query = $"update fruits set price = {price}, description = '{description}',name = '{name}' where id = {fruitId}";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            if(cmd.ExecuteNonQuery() > 0)
            {
                Response.Redirect("/Dashboard");
            }
        }
    }
}
