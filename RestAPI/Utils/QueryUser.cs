using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Utils
{
    public static class QueryUser
    {
        static string querySelect = "SELECT * FROM Users";
        static string querySelectEmail = "SELECT * FROM Users WHERE email='";
        static string queryInsert = "INSERT INTO Users(email, password, name, age, color) VALUES (@email, @password, @name, @age, @color)";
        static string queryUpdate = "UPDATE Users SET email=@email, password=@password, name=@name, age=@age, color=@color WHERE email=";
        static string queryDelete = "DELETE FROM Users WHERE email=";
    

    public static string getSelect() { return querySelect; }

    public static string getSelectEmail() { return querySelectEmail; }

    public static string getInsert() { return queryInsert; }

    public static string getUpdate() { return queryUpdate; }

    public static string getDelete() { return queryDelete; }
    }
}
