using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace GoFruity.Pages
{
    public class LoginModel : PageModel
    {
        public string errorText = "";

        public void OnGet()
        {
            //if logged nin redirect to appropriate page
            var coookie = Request.Cookies["role"];
            if(coookie != null && coookie.Length > 0)
            {
                if(coookie == "0")
                {
                    Response.Redirect("/Dashboard");
                }
                else
                {
                    Response.Redirect("/Index");
                }
            }
        }
        public void OnPost()
        {
            //after loggin get the id , name , role , address and save to cookie
            var email = Request.Form["email"];
            var password = Request.Form["pwd"];

            Config config = new Config();
            config.GenAllFruits();
            config.GenAllUsers();
            config.GenAllOrders();
            SqlConnection conn = new SqlConnection(config.dbConnection);
            string query = @$"select * from users where email = '{email}' and password = '{password}'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    SetCookie("role", rdr["role"].ToString());
                    SetCookie("id", rdr["id"].ToString());
                    SetCookie("address", rdr["address"].ToString());
                    SetCookie("phone", rdr["phone"].ToString());
                    SetCookie("name", rdr["name"].ToString());
                    SetCookie("email", rdr["email"].ToString());
                    if (rdr["role"].ToString() == "0")
                    {
                        Response.Redirect("/Dashboard");
                    }
                    else
                    {
                        Response.Redirect("/Index");
                    }
                }
            }
            else
            {
                errorText = "<div class=\"alert alert-warning\" role=\"alert\">Invalid Credentials</div>";
            }

        }
        public void SetCookie(string key, string role)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";
            Response.Cookies.Append(key, role, cookieOptions);
        }
    }
}
