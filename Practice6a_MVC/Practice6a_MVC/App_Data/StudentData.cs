using Dapper;
using Practice6a_MVC.Interfaces;
using Practice6a_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practice6a_MVC.App_Data
{
    public class StudentData : IStudentData
    {
        private readonly string _connectionString;
        public StudentData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "Select * from SINHVIEN";

                students = connection.Query<Student>(sql, typeof(Student)).ToList();
                connection.Close();
            }
            return students;
        }

        public Student GetByID(object id)
        {
            Student student;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"Select * from SINHVIEN WHERE MSSV={id}";
                student = connection.Query<Student>(sql, typeof(Student)).FirstOrDefault();
                connection.Close();
            }
            return student;
        }

        public DataTable GetResultSubjectRegisted(int id)
        {

            DataTable result = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "Select DANGKYMH.MAMH,TENMH, DTP, DQT, RATEDQT, RATEDTP, ROUND((DTP*RATEDTP+DQT*RATEDQT),2) AS DTK," +
              " CASE WHEN ROUND((DTP*RATEDTP+DQT*RATEDQT),2) > 4.0 THEN 'Pass' ELSE 'Fail' END AS KETQUA" +
              " FROM DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH" +
              $" WHERE MSSV={id}";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
            }
            return result;
        }

        public string InputDataScore(SubjectRegisted subjectRegisted)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO DANGKYMH(MAMH, MSSV, DQT, DTP) VALUES (@MAMH,@MSSV,@DQT,@DTP)";
                try
                {
                    connection.Execute(sql, subjectRegisted);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                    {
                        return "Môn học đã có điểm";
                    }
                    else
                    {
                        return ex.ToString();
                    }
                }
            }
            return "Nhập điểm thành công";
        }

        public void Insert(Student item)
        {
            throw new NotImplementedException();
        }
    }
}