using Practice4_CastleWindsor.Interfaces.IData;
using Practice4_CastleWindsor.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4_CastleWindsor.Data.Files
{
    internal class StudentFileData : IStudentData
    {
        
        string _connectionString;
        SqlConnection _cnn;


        public StudentFileData(string connectionString)
        {
            _connectionString = connectionString;
            _cnn = new SqlConnection(_connectionString);
        }

        public List<Student> GetAll()
        {
            List<Student> result = new List<Student>();
            _cnn.Open();
            if (_cnn!=null)
            {
                string sql = "Select * from SINHVIEN";
                SqlCommand cmd = new SqlCommand(sql, _cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetInt32(5)));
                }
            }
            _cnn.Close();
            return result;
        }
        public List<string> GetNumberSubjectRegisted(int MSSV)
        {
            _cnn.Open();
            string sql = $"Select DANGKYMH.MAMH,TENMH from DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH WHERE MSSV={MSSV}";
            SqlCommand cmd = new SqlCommand(sql, _cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> result = new List<string>();
            while (reader.Read())
            {
                result.Add($"{reader.GetString(1).Replace(" ", "")}({reader.GetString(0).Replace(" ","")})");
            }
            _cnn.Close();
            if (result is null) return null;
            return result; 
        }
        public DataTable GetEnrolledCourseInfoForStudent(int MSSV)
        {
            _cnn.Open();
            string sql = $"Select DANGKYMH.MAMH,TENMH, DTP, DQT from DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH WHERE MSSV={MSSV}";
            SqlCommand cmd = new SqlCommand(sql, _cnn);
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);
            _cnn.Close();

            if (result is null) return null;
            return result;
        }

        public DataTable GetResultStudent(int MSSV)
        {
            _cnn.Open();
            string sql = "Select DANGKYMH.MAMH,TENMH, DTP, DQT, ROUND((DTP*RATEDTP+DQT*RATEDQT),2) AS DTK,"+
                          " CASE WHEN ROUND((DTP*RATEDTP+DQT*RATEDQT),2) > 4.0 THEN 'Pass' ELSE 'Fail' END AS KETQUA"+
                          " FROM DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH"+
                          $" WHERE MSSV={MSSV}";
            SqlCommand cmd = new SqlCommand(sql, _cnn);
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);
            _cnn.Close();

            if (result is null) return null;
            return result;
        }


        public void InputDataScore(int  MSSV, string MAMH,float DQT, float DTP)
        {
            _cnn.Open();
            string sql = $"INSERT INTO DANGKYMH(MAMH, MSSV, DQT, DTP) VALUES ('{MAMH}',{MSSV},{DQT},{DTP})";
            Console.WriteLine(sql);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            _cnn.Close();
        }
    }
}

