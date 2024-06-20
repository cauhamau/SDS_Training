using Dapper;
using Practice5b_Dapper.Interfaces.IData;
using Practice5b_Dapper.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5b_Dapper.Data.Files
{
    internal class StudentFileData : IStudentData
    {
        
        string _connectionString;
        SqlConnection _connection;


        public StudentFileData(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public List<Student> GetAll()
        {
            //List<Student> result = new List<Student>();
            _connection.Open();
            
            string sql = "Select * from SINHVIEN";
            List<Student> result = _connection.Query<Student>(sql, typeof(Student)).ToList();
            _connection.Close();

            return result;
        }
        public List<SubjectRegisted> GetNumberSubjectRegisted(int MSSV)
        {
            _connection.Open();
            string sql = $"Select * from DANGKYMH WHERE MSSV={MSSV}";
            List<SubjectRegisted> result = _connection.Query<SubjectRegisted>(sql, typeof(SubjectRegisted)).ToList();

            _connection.Close();
            if (result is null) return null;
            return result; 
        }
        public DataTable GetEnrolledCourseInfoForStudent(int MSSV)
        {
            _connection.Open();
            string sql = $"Select DANGKYMH.MAMH,TENMH, DTP, DQT from DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH WHERE MSSV={MSSV}";
            SqlCommand cmd = new SqlCommand(sql, _connection);
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);
            _connection.Close();

            if (result is null) return null;
            return result;
        }

        public DataTable GetResultStudent(int MSSV)
        {
            _connection.Open();
            string sql = "Select DANGKYMH.MAMH,TENMH, DTP, DQT, ROUND((DTP*RATEDTP+DQT*RATEDQT),2) AS DTK,"+
                          " CASE WHEN ROUND((DTP*RATEDTP+DQT*RATEDQT),2) > 4.0 THEN 'Pass' ELSE 'Fail' END AS KETQUA"+
                          " FROM DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH"+
                          $" WHERE MSSV={MSSV}";
            SqlCommand cmd = new SqlCommand(sql, _connection);
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);
            _connection.Close();

            if (result is null) return null;
            return result;
        }


        public void InputDataScore(SubjectRegisted subjectRegisted)
        {
            _connection.Open();
            string sql = "INSERT INTO DANGKYMH(MAMH, MSSV, DQT, DTP) VALUES (@MAMH,@MSSV,@DQT,@DTP)";
            try
            {
                _connection.Execute(sql,subjectRegisted);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nhập điểm không thành công, môn học đã có điểm.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }

            _connection.Close();
        }
    }
}

