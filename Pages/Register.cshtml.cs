using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace GoFruity.Pages
{
    public class RegisterModel : PageModel
    {
        public string name;
        public string email;
        public string phone;
        public string address;
        public string password;
        public string msg;

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            name = Request.Form["name"];
            email = Request.Form["email"];
            phone = Request.Form["phone"];
            address = Request.Form["address"];
            password = Request.Form["pwd"];
            Config config = new Config();
            SqlConnection conn = new SqlConnection(config.dbConnection);
            string query = $"insert into users(name,password,email,role,address,phone) values('{name}','{password}','{email}',1,'{address}','{phone}')";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Redirect("/Login");
            }
            else
            {
                msg = $"<div class=\"alert alert-warning\" role=\"alert\">Could not create account for {name}</div>";
            }
        }
    }
}
