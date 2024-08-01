using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GoFruity.Pages
{
    
    
    public class Config
    {
        public string dbConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GoFruity;Integrated Security=True";
        
        
        public void GenAllFruits()
        {
            
            SqlConnection conn = new SqlConnection(dbConnection);
            string queryAllFruits = "select * from fruits";
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryAllFruits, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = (" ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = false;
                
                
                    using (XmlWriter writer = XmlWriter.Create(@"wwwroot\reports\fruits.xml", settings))
                    {
                    writer.WriteStartElement("fruits");
                    while (rdr.Read())
                    {
                        writer.WriteStartElement("fruit");
                        writer.WriteElementString("id", rdr["id"].ToString());
                        writer.WriteElementString("name", rdr["name"].ToString());
                        writer.WriteElementString("price", rdr["price"].ToString());
                        writer.WriteElementString("description", rdr["description"].ToString());
                        writer.WriteElementString("image", rdr["image"].ToString());
                        writer.WriteEndElement();
                    }
                        
                        
                        writer.Flush();
                }
                
            }
            
            
            

        }

        public void GenAllUsers()
        {
            SqlConnection conn = new SqlConnection(dbConnection);
            string queryAllUsers = "select * from users ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryAllUsers, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = (" ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = false;


                using (XmlWriter writer = XmlWriter.Create(@"Pages\users.xml", settings))
                {
                    writer.WriteStartElement("users");
                    while (rdr.Read())
                    {
                        writer.WriteStartElement("user");
                        writer.WriteElementString("id", rdr["id"].ToString());
                        writer.WriteElementString("name", rdr["name"].ToString());
                        writer.WriteElementString("password", rdr["password"].ToString());
                        writer.WriteElementString("email", rdr["email"].ToString());
                        writer.WriteElementString("role", rdr["role"].ToString());
                        writer.WriteElementString("address", rdr["address"].ToString());
                        writer.WriteElementString("phone", rdr["phone"].ToString());
                        writer.WriteEndElement();
                    }


                    writer.Flush();
                }

            }
        }

        public void GenAllOrders()
        {
            SqlConnection conn = new SqlConnection(dbConnection);
            string queryAllOrders = "select fruit_id,user_id,bought,fruits.name,fruits.price,fruits.description,fruits.image,users.email,users.address,users.phone,users.name as username from cart join fruits on fruits.id = cart.fruit_id join users on users.id = cart.user_id where bought = 1";
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryAllOrders, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = (" ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = false;


                using (XmlWriter writer = XmlWriter.Create(@"wwwroot\reports\orders.xml", settings))
                {
                    writer.WriteStartElement("orders");
                    while (rdr.Read())
                    {
                        writer.WriteStartElement("order");
                        writer.WriteElementString("fruitId", rdr["fruit_id"].ToString());
                        writer.WriteElementString("userId", rdr["user_id"].ToString());
                        writer.WriteElementString("bought", rdr["bought"].ToString());
                        writer.WriteElementString("fruitName", rdr["name"].ToString());
                        writer.WriteElementString("price", rdr["price"].ToString());
                        writer.WriteElementString("description", rdr["description"].ToString());
                        writer.WriteElementString("image", rdr["image"].ToString());
                        writer.WriteElementString("email", rdr["email"].ToString());
                        writer.WriteElementString("address", rdr["address"].ToString());
                        writer.WriteElementString("phone", rdr["phone"].ToString());
                        writer.WriteElementString("username", rdr["username"].ToString());
                        writer.WriteEndElement();
                    }


                    writer.Flush();
                }

            }
        }

        public void Exportdatabase()
        {
            string tableCart = "select * from cart";

            SqlConnection conn = new SqlConnection(dbConnection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(tableCart, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = (" ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = false;


                using (XmlWriter writer = XmlWriter.Create(@"wwwroot\reports\cart.xml", settings))
                {
                    writer.WriteStartElement("fruits");
                    while (rdr.Read())
                    {
                        writer.WriteStartElement("cartItem");
                        writer.WriteElementString("id", rdr["id"].ToString());
                        writer.WriteElementString("fruit_id", rdr["fruit_id"].ToString());
                        writer.WriteElementString("user_id", rdr["user_id"].ToString());
                        writer.WriteElementString("bought", rdr["bought"].ToString());
                        writer.WriteEndElement();
                    }


                    writer.Flush();
                }

            }

            //for fruits call
            GenAllFruits();
            GenAllUsers();

        }
    }

  
}
