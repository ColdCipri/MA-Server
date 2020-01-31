using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet()]
        public IEnumerable<User> Get()
        {
            using var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString());
            var querySelect = Utils.QueryUser.getSelect();
            _conn.Open();
            using var cmd = new SqlCommand(querySelect, _conn);
            using var reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(new ReadUser(reader));
            }
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{email}")]
        public IEnumerable<User> Get(string email)
        {
            using (var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString()))
            {
                var querySelect = Utils.QueryUser.getSelectEmail() + email + "'";
                _conn.Open();
                using (var cmd = new SqlCommand(querySelect, _conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {

                        List<User> users = new List<User>();
                        while (reader.Read())
                        {
                            users.Add(new ReadUser(reader));
                        }
                        return users;

                    }
                }
            }
        }

        // POST: api/Users
        [HttpPost()]
        public string Post([FromBody]CreateUser value)
        {
            using var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString());

            var queryInsert = Utils.QueryUser.getInsert();
            using SqlCommand insertCommand = new SqlCommand(queryInsert, _conn);

            insertCommand.Parameters.AddWithValue("@email", value.email);
            insertCommand.Parameters.AddWithValue("@password", value.password);
            insertCommand.Parameters.AddWithValue("@name", value.name);
            insertCommand.Parameters.AddWithValue("@age", value.age);
            insertCommand.Parameters.AddWithValue("@color", value.color);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
                return "true";
            else
                return "false";
        }

        // PUT: api/Users/5
        [HttpPut("{email}")]

        public string Put(string email, [FromBody]CreateUser value)
        {
            using var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString());

            var queryUpdate = Utils.QueryUser.getUpdate() + email;
            SqlCommand updateCommand = new SqlCommand(queryUpdate, _conn);

            updateCommand.Parameters.AddWithValue("@email", value.email);
            updateCommand.Parameters.AddWithValue("@password", value.password);
            updateCommand.Parameters.AddWithValue("@name", value.name);
            updateCommand.Parameters.AddWithValue("@age", value.age);
            updateCommand.Parameters.AddWithValue("@color", value.color);

            _conn.Open();
            int result = updateCommand.ExecuteNonQuery();
            if (result > 0)
                return "true";
            else
                return "false";
        }

        // DELETE: api/Users/5
        [HttpDelete("{email}")]
        public string Delete(string email)
        {
            using var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString());

            var queryDelete = Utils.QueryUser.getDelete() + email;
            SqlCommand deleteCommand = new SqlCommand(queryDelete, _conn);

            _conn.Open();
            int result = deleteCommand.ExecuteNonQuery();
            if (result > 0)
                return "true";
            else
                return "false";
        }
    }
}