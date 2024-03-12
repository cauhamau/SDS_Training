using Practice5a_Nhibernate.Interfaces.IData;
using Practice5a_Nhibernate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Data.Files
{
    internal class SubjectFileData : ISubjectData
    {
        string _connectionString;
        SqlConnection _cnn;

        public SubjectFileData(string connectionString)
        {
            _connectionString = connectionString;
            _cnn = new SqlConnection(_connectionString);
        }

        public List<MonHoc> GetAll()
        {
            List<MonHoc> result = new List<MonHoc>();
            _cnn.Open();
            if (_cnn != null)
            {
                string sql = "Select * from MONHOC";
                SqlCommand cmd = new SqlCommand(sql, _cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new MonHoc(reader.GetString(1), reader.GetString(0), float.Parse(reader.GetDecimal(2).ToString()), float.Parse(reader.GetDecimal(3).ToString()), reader.GetInt32(4)));
                }
            }
            _cnn.Close();
            return result;
        }

    }
}
