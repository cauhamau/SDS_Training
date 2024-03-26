using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        static string _connectionString = "data source=.;initial catalog=QLSV;integrated security=true;";
        

        //static IList<Student> studentList = 
        // GET: Student
        public ActionResult Index()
        {
            List<Student> result = new List<Student>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "Select * from SINHVIEN";
                result = connection.Query<Student>(sql, typeof(Student)).ToList();
                connection.Close();
            }

            return View(result);
        }
        public ActionResult Edit(int Id)
        {
            List<Student> result = new List<Student>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "Select * from SINHVIEN";
                result = connection.Query<Student>(sql, typeof(Student)).ToList();
                connection.Close();
            }

            //getting a student from collection for demo purpose
            var std = result.Where(s => s.MSSV == Id).FirstOrDefault();

            return View(std);
        }
    }
}