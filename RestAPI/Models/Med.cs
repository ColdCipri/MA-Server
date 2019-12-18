using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class Med
    {
        public int id { get; set; }
        public string name { get; set; }
        public string exp_date { get; set; }
        public int pieces { get; set; }
        public string base_subst { get; set; }
        public string quantity { get; set; }
        public string description { get; set; }

    }

    public class CreateMed : Med
    {

    }

    public class ReadMed : Med
    {
        public ReadMed(SqlDataReader row)
        {
            id = Convert.ToInt32(row["id"]);
            name = row["name"].ToString();
            exp_date = row["exp_date"].ToString();
            pieces = Convert.ToInt32(row["pieces"]);
            base_subst = row["base_subst"].ToString();
            quantity = row["quantity"].ToString();
            description = row["description"].ToString();

        }
    }
}