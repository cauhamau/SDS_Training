using Castle.MicroKernel.Registration;
using NHibernate.Loader.Custom;
using Practice6a_MVC_Nhibernate.App_Start;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice6a_MVC_Nhibernate.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
            using (var container = DependencyContainer.Bootstrap())
            {
                _studentService = container.Container.Resolve<IStudentService>();
            }
        }
        public ActionResult Result(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        //PartialView Student Information
        [ChildActionOnly]
        public ActionResult InfoStudent(int Id)
        {
            Student student = _studentService.GetByID(Id);
            ViewBag.Student = student;
            return PartialView();
        }

        public ActionResult Details(int Id)
        {
            Student student = _studentService.GetByID(Id);
            ViewBag.student = student;
            ViewBag.response = null;
            return View();
        }

        [HttpPost]
        public ActionResult Details(Student student)
        {
            string response = _studentService.SaveStudent(student);
            TempData["success"] = response;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            string response = _studentService.SaveStudent(student);
            TempData["success"] = response;
            
            return RedirectToAction("Index", "Home");
        }
    }
}