using Dapper;
using Practice5b_Dapper.Interfaces.IData;
using Practice5b_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5b_Dapper.Data.Files
{
    internal class SubjectFileData : ISubjectData
    {
        string _connectionString;
        SqlConnection _connection;

        public SubjectFileData(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public List<Subject> GetAll()
        {
            _connection.Open();
            List<Subject> result = new List<Subject>();
            if (_connection != null)
            {
                string sql = "Select * from MONHOC";
                result = _connection.Query<Subject>(sql, typeof(Subject)).ToList();

            }
            _connection.Close();
            return result;
        }

    }
}
