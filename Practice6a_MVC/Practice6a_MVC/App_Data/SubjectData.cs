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
using System.Web.Mvc;

namespace Practice6a_MVC.App_Data
{
    internal class SubjectData : ISubjectData
    {
        string _connectionString;

        public SubjectData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Subject Get(object key)
        {
            throw new NotImplementedException();
        }

        public IList<Subject> GetAll()
        {
            List<Subject> students = new List<Subject>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "Select * from MONHOC";
                
                students = connection.Query<Subject>(sql, typeof(Subject)).ToList();
                connection.Close();
            }
            return students;
        }

        public Subject GetByID(object key)
        {
            throw new NotImplementedException();
        }

    }
}