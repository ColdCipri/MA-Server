using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Utils
{
    public static class Utils
    {
        static string querySelect = "SELECT * FROM Meds";
        static string querySelectId = "SELECT * FROM Meds WHERE id=";
        static string queryInsert = "INSERT INTO Meds(name, exp_date, pieces, base_subst, quantity, description) VALUES (@name, @exp_date, @pieces, @base_subst, @quantity, @description)";
        static string queryUpdate = "UPDATE Meds SET name=@name, exp_date=@exp_date, pieces=@pieces, base_subst=@base_subst, quantity=@quantity, description=@description WHERE id=";
        static string queryDelete = "DELETE FROM Meds WHERE id=";

        public static string GetConnectionString()
        {
            return @"Data Source = CIPRI-ROG\SQLEXPRESS; " +
                    "Initial Catalog = med_db; " +
                    "Integrated Security = True; " +
                    "MultipleActiveResultSets = True;";
        }

        public static string getSelect() { return querySelect; }

        public static string getSelectId() { return querySelectId; }

        public static string getInsert() { return queryInsert; }

        public static string getUpdate() { return queryUpdate; }

        public static string getDelete() { return queryDelete; }
    }
}