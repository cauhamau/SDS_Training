using Practice6a_MVC_Nhibernate.App_Start;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using Practice6a_MVC_Nhibernate.Models;
using Practice6a_MVC_Nhibernate.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Practice6a_MVC_Nhibernate.Controllers
{
    public class SubjectRegistedController : Controller
    {
        // GET: SubjectRegisted
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private readonly ISubjectRegistedService _registedService;
        private readonly ISubjectService _subjectService;
        public SubjectRegistedController()
        {
            using (var container = DependencyContainer.Bootstrap())
            {
                _registedService = container.Container.Resolve<ISubjectRegistedService>();
                _subjectService = container.Container.Resolve<ISubjectService>();
            }
        }
        [ChildActionOnly]
        public ActionResult ResultSubjectRegisted(int Id)
        {
            DataTable resultStudent = _registedService.GetResultSubjectRegisted(Id);
            ViewBag.resultStudent = resultStudent;
            return PartialView();
        }

        public ActionResult InsertScore(int Id)
        {
            ViewBag.IdStudent = Id;
            return View();
        }

        public ActionResult PostScore(int Id)
        {
            ViewBag.IdStudent = Id;

            IList<SubjectRegisted> subjectRegisted = _registedService.GetSubjectRegisted(Id);
            ViewBag.subjectRegisted = subjectRegisted;
            ViewBag.response = null;
            return PartialView();
        }
        [HttpPost]
        public ActionResult PostScore(SubjectRegisted subjectRegisted)
        {
            string response = _registedService.InsertDataScore(subjectRegisted);

            ViewBag.IdStudent = subjectRegisted.MSSV;
            IList<SubjectRegisted> subjectRegisteds = _registedService.GetSubjectRegisted(subjectRegisted.MSSV);
            ViewBag.subjectRegisted = subjectRegisteds;
            ViewBag.response = response;
            return PartialView();
        }


        public ActionResult SubjectRegister(int Id)
        {
            ViewBag.IdStudent = Id;

            IList<Subject> subject = _subjectService.GetUnregistered(Id);
            ViewBag.subject = subject;
            ViewBag.response = null;
            return View();
        }


        [HttpPost]
        public ActionResult SubjectRegister(SubjectRegisted subjectRegister)
        {
            ViewBag.IdStudent = subjectRegister.MSSV;
            IList<SubjectRegisted> listSubjectRegisteds = _registedService.GetSubjectRegisted(subjectRegister.MSSV);
            IList<SubjectRegisted> filteredList = listSubjectRegisteds.Where(model => model.MAMH == subjectRegister.MAMH).ToList();

            if (filteredList.Count > 0)
            {
                subjectRegister.SOLANHOC = filteredList[0].SOLANHOC+1;
            }

            IList<Subject> subject = _subjectService.GetUnregistered(subjectRegister.MSSV);
            ViewBag.subject = subject;

            string response = _registedService.SubjectRegister(subjectRegister);
            ViewBag.response = response;
            return View();
        }
    }
}