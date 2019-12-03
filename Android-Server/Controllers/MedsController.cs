using Android_Server.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Android_Server.Controllers
{
    public class MedsController : ApiController
    {
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        

        // GET: api/Meds

        [ResponseType(typeof(IEnumerable<Med>))]
        public IEnumerable<Med> Get()
        {
            _conn = new SqlConnection(Utils.Utils.GetConnectionString());
            DataTable _dt = new DataTable();
            var querySelect = Utils.Utils.getSelect();
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(querySelect, _conn)
            };
            _adapter.Fill(_dt);
            List<Med> meds = new List<Med>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach(DataRow medsRecords in _dt.Rows)
                {
                    meds.Add(new ReadMed(medsRecords));
                }
            }

            return meds;
        }

        // GET: api/Meds/5
        public IEnumerable<Med> Get(int id)
        {
            _conn = new SqlConnection(Utils.Utils.GetConnectionString());
            DataTable _dt = new DataTable();
            var querySelect = Utils.Utils.getSelectId() + id;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(querySelect, _conn)
            };
            _adapter.Fill(_dt);
            List<Med> meds = new List<Med>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow medsRecords in _dt.Rows)
                {
                    meds.Add(new ReadMed(medsRecords));
                }
            }

            return meds;
        }

        // POST: api/Meds
        public string Post([FromBody]CreateMed value)
        {
            _conn = new SqlConnection(Utils.Utils.GetConnectionString());

            var queryInsert = Utils.Utils.getInsert();
            SqlCommand insertCommand = new SqlCommand(queryInsert, _conn);

            insertCommand.Parameters.AddWithValue("@name", value.name);
            insertCommand.Parameters.AddWithValue("@exp_date", value.exp_date);
            insertCommand.Parameters.AddWithValue("@pieces", value.pieces);
            insertCommand.Parameters.AddWithValue("@base_subst", value.base_subst);
            insertCommand.Parameters.AddWithValue("@quantity", value.quantity);
            insertCommand.Parameters.AddWithValue("@description", value.description);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
                return "true";
            else
                return "false";
        }

        // PUT: api/Meds/5
        public string Put(int id, [FromBody]CreateMed value)
        {
            _conn = new SqlConnection(Utils.Utils.GetConnectionString());

            var queryUpdate = Utils.Utils.getUpdate() + id;
            SqlCommand updateCommand = new SqlCommand(queryUpdate, _conn);

            updateCommand.Parameters.AddWithValue("@name", value.name);
            updateCommand.Parameters.AddWithValue("@exp_date", value.exp_date);
            updateCommand.Parameters.AddWithValue("@pieces", value.pieces);
            updateCommand.Parameters.AddWithValue("@base_subst", value.base_subst);
            updateCommand.Parameters.AddWithValue("@quantity", value.quantity);
            updateCommand.Parameters.AddWithValue("@description", value.description);

            _conn.Open();
            int result = updateCommand.ExecuteNonQuery();
            if (result > 0)
                return "true";
            else
                return "false";
        }

        // DELETE: api/Meds/5
        public string Delete(int id)
        {
            _conn = new SqlConnection(Utils.Utils.GetConnectionString());

            var queryDelete = Utils.Utils.getDelete() + id;
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
