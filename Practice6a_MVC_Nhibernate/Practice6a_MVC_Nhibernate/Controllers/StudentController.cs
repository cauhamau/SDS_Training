using Castle.MicroKernel.Registration;
using NHibernate.Loader.Custom;
using Practice6a_MVC_Nhibernate.App_Start;
using Practice6a_MVC_Nhibernate.Filters;
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
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public StudentController()
        {
            using (var container = DependencyContainer.Bootstrap())
            {
                _studentService = container.Container.Resolve<IStudentService>();
            }
        }

        [CustomAuthorize("admin", "teacher", "student")]
        public ActionResult Result(int id)
        {
            ViewBag.id = id;
            return View();
        }
        //PartialView Student Information
        [ChildActionOnly]
        public ActionResult InfoStudent(int id)
        {
            Student student = _studentService.GetByID(id);
            ViewBag.Student = student;
            return PartialView();
        }

        //[Authorize(Roles = "student")]
        [CustomAuthorize("admin","teacher","student")]
        public ActionResult Details(int id)
        {
            Student student = _studentService.GetByID(id);
            ViewBag.student = student;
            ViewBag.response = null;
            return View();
        }

        [HttpPost]
        public ActionResult Details(Student student)
        {
            string response = _studentService.SaveStudent(student);
            if(response=="success")
            {
                _log.Info("Cập nhật thành công sinh viên: " + student.MSSV);
                TempData["success"] = "Cập nhật sinh viên thành công";
            }
            else
            {
                _log.Error(response);
                TempData["warning"] = response;
            }

            return RedirectToAction("Index", "Home");
            
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            string response = _studentService.SaveStudent(student);
            if (response == "success")
            {
                _log.Info("Thêm thành công sinh viên: " + student.MSSV);
                TempData["success"] = "Thêm sinh viên thành công";
            }
            else
            {
                _log.Error(response);
                TempData["warning"] = response;
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}