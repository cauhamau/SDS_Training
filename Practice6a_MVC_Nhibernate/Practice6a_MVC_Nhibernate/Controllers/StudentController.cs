using Castle.MicroKernel.Registration;
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
        public ActionResult Details(int Id)
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

    }
}