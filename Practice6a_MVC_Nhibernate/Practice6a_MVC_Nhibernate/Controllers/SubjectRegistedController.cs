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
            
            ViewBag.Id = Id;    
            DataTable resultStudent = _registedService.GetResultSubjectRegisted(Id);
            ViewBag.resultStudent = resultStudent;
            return PartialView();
        }

        [HttpPost]
        public ActionResult ResultSubjectRegisted(int Id, string MAMH, int SOLANHOC)
        {
            ViewBag.Id = Id;

            var subjectRegisted = new SubjectRegisted { MAMH = MAMH, MSSV = Id, SOLANHOC = SOLANHOC };
            ViewBag.response = _registedService.DeleteRegisted(subjectRegisted);
            DataTable resultStudent = _registedService.GetResultSubjectRegisted(Id);
            ViewBag.resultStudent = resultStudent;
            return PartialView();


        }

        public ActionResult InsertScore(int Id)
        {

            ViewBag.IdStudent = Id;
            return View();
        }

        [ChildActionOnly]
        [HttpGet]
        public ActionResult PostScore(int Id)
        {
            ViewBag.IdStudent = Id;
            TempData["success"] = null;
            IList<SubjectRegisted> subjectRegisted = _registedService.GetSubjectRegisted(Id);
            ViewBag.subjectRegisted = subjectRegisted;
            ViewBag.response = null;
            return PartialView();

        }
        [HttpPost]
        public ActionResult PostScore(SubjectRegisted subjectRegisted)
        {
            string response = _registedService.InsertDataScore(subjectRegisted);
            TempData["success"] = response;
            ViewBag.IdStudent = subjectRegisted.MSSV;
            IList<SubjectRegisted> subjectRegisteds = _registedService.GetSubjectRegisted(subjectRegisted.MSSV);
            ViewBag.subjectRegisted = subjectRegisteds;
            return PartialView();
        }


        public ActionResult SubjectRegister(int Id)
        {
            ViewBag.Id = Id;

            IList<Subject> subject = _subjectService.GetUnregistered(Id);
            ViewBag.subject = subject;
            ViewBag.response = null;
            return View();
        }


        [HttpPost]
        public ActionResult SubjectRegister(int Id, FormCollection form)
        {
            ViewBag.Id = Id;
            var selectedSubjects = form.GetValues("selectedSubjects");

            IList<SubjectRegisted> listSubjectRegisteds = _registedService.GetSubjectRegisted(Id);
            string response = null;
            foreach (string maMH  in selectedSubjects)
            {
                SubjectRegisted subjectRegister = new SubjectRegisted();
                subjectRegister.MAMH = maMH;
                subjectRegister.MSSV = Id;
                SubjectRegisted subjectRegisted = listSubjectRegisteds.SingleOrDefault(x => x.MAMH == maMH);
                if(subjectRegisted != null)
                {
                    subjectRegister.SOLANHOC = subjectRegisted.SOLANHOC+1;
                }
                else
                {
                    subjectRegister.SOLANHOC = 1;
                }
                response = _registedService.SubjectRegister(subjectRegister);
            }

            IList<Subject> subject = _subjectService.GetUnregistered(Id);
            ViewBag.subject = subject;
            ViewBag.IdStudent = Id;

            TempData["success"] = response;

            return RedirectToAction("Index", "Home");
        }
    }
}