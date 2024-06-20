using Practice6a_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Practice6a_MVC.Interfaces;
using Castle.Windsor;
using Practice6a_MVC.App_Data;
using Castle.MicroKernel.Registration;
using System.Data;
using System.Web.UI.WebControls;
namespace Practice6a_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentData _studentData;
        private readonly ISubjectData _subjectData;
        public HomeController()
        {
            using (var container = new WindsorContainer())
            {
                container.Register(Component.For<IStudentData>().ImplementedBy<StudentData>().DependsOn(Dependency.OnValue("connectionString", "data source=.;initial catalog=QLSV;integrated security=true;")),
                                       Component.For<ISubjectData>().ImplementedBy<SubjectData>().DependsOn(Dependency.OnValue("connectionString", "data source=.;initial catalog=QLSV;integrated security=true;")));
                _studentData = container.Resolve<IStudentData>();
                _subjectData = container.Resolve<ISubjectData>();
            }
        }
        //static string _connectionString = "data source=.;initial catalog=QLSV;integrated security=true;";
        // GET: Student
        public ActionResult Index()
        {

            IList<Student> students = _studentData.GetAll();

            return View(students);
        }


        public ActionResult Details(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }


        [ChildActionOnly]
        public ActionResult ResultSubjectRegisted(int Id)
        {
            DataTable resultStudent = _studentData.GetResultSubjectRegisted(Id);
            ViewBag.resultStudent = resultStudent;
            return PartialView();
        }


        //PartialView Student Information
        [ChildActionOnly]
        public ActionResult InfoStudent(int Id)
        {
            Student student = _studentData.GetByID(Id);
            ViewBag.Student = student;
            return PartialView();
        }

        public ActionResult InsertScore(int Id)
        {
            ViewBag.IdStudent = Id;
            IList<Subject> subjects = _subjectData.GetAll();
            ViewBag.Subjects = subjects;
            return View();            
        }
        public ActionResult PostScore(int Id)
        {
            ViewBag.IdStudent = Id;
            IList<Subject> subjects = _subjectData.GetAll();

            //ViewBag.Subjects = subjects;
            ViewBag.response = null;
            ViewBag.Subjects = new SelectList(subjects, "MAMH", "TENMH");
            return PartialView();
        }
        [HttpPost]
        public ActionResult PostScore(SubjectRegisted subjectRegisted)
        {
            //ViewBag.IdStudent = Id;
            IList<Subject> subjects = _subjectData.GetAll();
            ViewBag.IdStudent = subjectRegisted.MSSV;
            //ViewBag.Subjects = subjects;
            ViewBag.Subjects = new SelectList(subjects, "MAMH", "TENMH");
            
            string response = _studentData.InsertDataScore(subjectRegisted);
            ViewBag.response = response;
            return PartialView();
            //return PartialView();//RedirectToAction("ResultSubjectRegisted", new { Id = subjectRegisted.MSSV });
        }
    }
}