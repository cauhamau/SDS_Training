using Practice3_ServiceDI_StudentManagement.Interfaces.IData;
using Practice3_ServiceDI_StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement.Data.Files
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

        //public void Add(Student student)
        //{
        //    _cnn.Open();
        //    if (_cnn!=null)
        //    {
        //        string sql = $"INSERT INTO SINHVIEN(MASV, HOTENSV, MAKHOA, NAMSINH, QUEQUAN) VALUES ({student.MASV},'{student.HOTEN}','{student.MAKHOA}',{student.NAMSINH},'{student.QUEQUAN}')";

        //        SqlCommand cmd = new SqlCommand(sql, _cnn);

        //        cmd.ExecuteNonQuery();
                
        //    }
        //    else
        //    {
        //        Console.WriteLine("SQLConection is null");
        //    }
        //    _cnn.Close();
        //}

        public List<Student> GetAll()
        {
            List<Student> result = new List<Student>();
            //SqlConnection cnn = new SqlConnection(_connectionString);
            _cnn.Open();
            if (_cnn!=null)
            {
                string sql = "Select * from SINHVIEN";
                SqlCommand cmd = new SqlCommand(sql, _cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Console.WriteLine(reader.GetInt32(0));
                    result.Add(new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetInt32(5)));
                }
            }
            _cnn.Close();
            return result;
        }
    }
}
