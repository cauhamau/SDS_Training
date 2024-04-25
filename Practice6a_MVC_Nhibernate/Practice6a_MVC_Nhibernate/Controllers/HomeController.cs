using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Data;
using System.Web.UI.WebControls;
using Practice6a_MVC_Nhibernate.Data;
using Practice6a_MVC_Nhibernate.App_Start;
namespace Practice6a_MVC_Nhibernate.Controllers
{
    public class HomeController : Controller
    {
        //IWindsorInstaller _installer;
        private readonly IStudentService _studentService;
        private readonly ISubjectData _subjectData;
        private readonly ISubjectRegistedService _registedService;
        public HomeController()
        {
            using (var container = DependencyContainer.Bootstrap())
            {
                _studentService = container.Container.Resolve<IStudentService>();
                _subjectData = container.Container.Resolve<ISubjectData>();
                _registedService = container.Container.Resolve<ISubjectRegistedService>();
            }
        }

        // GET: Student
        public ActionResult Index()
        {

            IList<Student> students = _studentService.GetAll();

            return View(students);
        }
    }
}