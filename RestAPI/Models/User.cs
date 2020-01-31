using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string color { get; set; }
    }


    public class CreateUser : User
    {

    }

    public class ReadUser : User
    {
        public ReadUser(SqlDataReader row)
        {
            email = row["email"].ToString();
            password = row["password"].ToString();
            name = row["name"].ToString();
            age = Convert.ToInt32(row["age"]);
            color = row["color"].ToString();
        }
    }
}