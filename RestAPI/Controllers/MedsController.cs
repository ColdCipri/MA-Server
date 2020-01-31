using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedsController : ControllerBase
    {
        [HttpGet()]
        public IEnumerable<Med> Get()
        {
            using var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString());
            var querySelect = Utils.QueryMed.getSelect();
            _conn.Open();
            using var cmd = new SqlCommand(querySelect, _conn);
            using var reader = cmd.ExecuteReader();
            List<Med> meds = new List<Med>();
            while (reader.Read())
            {
                meds.Add(new ReadMed(reader));
            }
            return meds;
        }

        // GET: api/Meds/5
        [HttpGet("{id:int}")]
        public IEnumerable<Med> Get(int id)
        {
            using (var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString()))
            {
                var querySelect = Utils.QueryMed.getSelectId() + id;
                _conn.Open();
                using (var cmd = new SqlCommand(querySelect, _conn))
                {
                    using (var reader = cmd.ExecuteReader()) {

                        List<Med> meds = new List<Med>();
                        while (reader.Read())
                        {
                            meds.Add(new ReadMed(reader));
                        }
                        return meds;

                    }
                }
            }
        }

        // GET: api/Meds/user
        [HttpGet("{user}")]
        public IEnumerable<Med> Get(string user)
        {
            using (var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString()))
            {
                var querySelect = Utils.QueryMed.getSelectUser() + user + "'";
                _conn.Open();
                using (var cmd = new SqlCommand(querySelect, _conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<Med> meds = new List<Med>();
                        while (reader.Read())
                        {
                            meds.Add(new ReadMed(reader));
                        }
                        return meds;

                    }
                }
            }
        }

        // POST: api/Meds
        [HttpPost()]
        public string Post([FromBody]CreateMed value)
        {
            using var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString());

            var queryInsert = Utils.QueryMed.getInsert();
            using SqlCommand insertCommand = new SqlCommand(queryInsert, _conn);

            insertCommand.Parameters.AddWithValue("@name", value.name);
            insertCommand.Parameters.AddWithValue("@exp_date", value.exp_date);
            insertCommand.Parameters.AddWithValue("@pieces", value.pieces);
            insertCommand.Parameters.AddWithValue("@base_subst", value.base_subst);
            insertCommand.Parameters.AddWithValue("@quantity", value.quantity);
            insertCommand.Parameters.AddWithValue("@description", value.description);
            insertCommand.Parameters.AddWithValue("@userEmail", value.userEmail);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
                return "true";
            else
                return "false";
        }

        // PUT: api/Meds/5
        [HttpPut("{id}")]

        public string Put(int id, [FromBody]CreateMed value)
        {
            using var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString());

            var queryUpdate = Utils.QueryMed.getUpdate() + id;
            SqlCommand updateCommand = new SqlCommand(queryUpdate, _conn);

            updateCommand.Parameters.AddWithValue("@name", value.name);
            updateCommand.Parameters.AddWithValue("@exp_date", value.exp_date);
            updateCommand.Parameters.AddWithValue("@pieces", value.pieces);
            updateCommand.Parameters.AddWithValue("@base_subst", value.base_subst);
            updateCommand.Parameters.AddWithValue("@quantity", value.quantity);
            updateCommand.Parameters.AddWithValue("@description", value.description);
            updateCommand.Parameters.AddWithValue("@userEmail", value.userEmail);

            _conn.Open();
            int result = updateCommand.ExecuteNonQuery();
            if (result > 0)
                return "true";
            else
                return "false";
        }

        // DELETE: api/Meds/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            using var _conn = new SqlConnection(Utils.QueryMed.GetConnectionString());

            var queryDelete = Utils.QueryMed.getDelete() + id;
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
