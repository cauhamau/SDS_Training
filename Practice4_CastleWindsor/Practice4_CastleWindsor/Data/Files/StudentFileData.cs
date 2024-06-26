﻿using Practice4_CastleWindsor.Interfaces.IData;
using Practice4_CastleWindsor.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        public List<string> GetNumberSubjectRegisted(int MSSV)
        {
            _connection.Open();
            string sql = $"Select DANGKYMH.MAMH,TENMH from DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH WHERE MSSV={MSSV}";
            SqlCommand cmd = new SqlCommand(sql, _connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> result = new List<string>();
            while (reader.Read())
            {
                result.Add($"{reader.GetString(1).Replace(" ", "")}({reader.GetString(0).Replace(" ","")})");
            }
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


        public void InputDataScore(int  MSSV, string MAMH, float DQT, float DTP)
        {
            _connection.Open();
            string sql = $"INSERT INTO DANGKYMH(MAMH, MSSV, DQT, DTP) VALUES ('{MAMH}',{MSSV},{DQT},{DTP})";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.ExecuteNonQuery();
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

