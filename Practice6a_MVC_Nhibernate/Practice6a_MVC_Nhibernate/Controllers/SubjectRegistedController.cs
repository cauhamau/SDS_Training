using Practice6a_MVC_Nhibernate.App_Start;
using Practice6a_MVC_Nhibernate.Filters;
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
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SubjectRegistedController()
        {
            using (var container = DependencyContainer.Bootstrap())
            {
                _registedService = container.Container.Resolve<ISubjectRegistedService>();
                _subjectService = container.Container.Resolve<ISubjectService>();
            }
        }
        [ChildActionOnly]
        public ActionResult ResultSubjectRegisted(int id)
        {
            
            ViewBag.id = id;    
            DataTable resultStudent = _registedService.GetResultSubjectRegisted(id);
            ViewBag.resultStudent = resultStudent;
            return PartialView();
        }

        [HttpPost]
        public ActionResult ResultSubjectRegisted(int id, string MAMH, int SOLANHOC)
        {
            ViewBag.id = id;

            var subjectRegisted = new SubjectRegisted { MAMH = MAMH, MSSV = id, SOLANHOC = SOLANHOC };
            ViewBag.response = _registedService.DeleteRegisted(subjectRegisted);
            DataTable resultStudent = _registedService.GetResultSubjectRegisted(id);
            ViewBag.resultStudent = resultStudent;
            return PartialView();


        }

        [CustomAuthorize("admin", "teacher")]
        public ActionResult InsertScore(int id)
        {
            ViewBag.idStudent = id;
            IList<SubjectRegisted> subjectRegisted = _registedService.GetSubjectRegisted(id);
            if (subjectRegisted.Count == 0)
            {
                TempData["warning"] = "Sinh viên chưa đăng ký môn học";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [ChildActionOnly]
        [HttpGet]
        public ActionResult PostScore(int id)
        {
            ViewBag.idStudent = id;
            IList<SubjectRegisted> subjectRegisted = _registedService.GetSubjectRegisted(id);
            ViewBag.subjectRegisted = subjectRegisted;
            ViewBag.response = null;
            return PartialView();

        }
        [HttpPost]
        public ActionResult PostScore(SubjectRegisted subjectRegisted)
        {
            string response = _registedService.InsertDataScore(subjectRegisted);

            if (response == "success")
            {
                _log.Info("Nhập điểm thành công");
                TempData["success"] = "Nhập điểm thành công";
            }    
            else
            {
                TempData["warning"] = response;
            }
            ViewBag.idStudent = subjectRegisted.MSSV;
            IList<SubjectRegisted> subjectRegisteds = _registedService.GetSubjectRegisted(subjectRegisted.MSSV);
            ViewBag.subjectRegisted = subjectRegisteds;
            return PartialView();
        }

        [CustomAuthorize("admin", "student")]
        public ActionResult SubjectRegister(int id)
        {
            User user = (User)Session["user"];

            ViewBag.id = id;

            IList<Subject> subject = _subjectService.GetUnregistered(id);
            ViewBag.subject = subject;
            return View();


        }


        [HttpPost]
        public ActionResult SubjectRegister(int id, FormCollection form)
        {
            ViewBag.id = id;
            var selectedSubjects = form.GetValues("selectedSubjects");

            IList<SubjectRegisted> listSubjectRegisteds = _registedService.GetSubjectRegisted(id);
            string response = null;
            foreach (string maMH  in selectedSubjects)
            {
                SubjectRegisted subjectRegister = new SubjectRegisted();
                subjectRegister.MAMH = maMH;
                subjectRegister.MSSV = id;
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
                if (response != "success")
                {
                    TempData["warning"] = response;
                    return RedirectToAction("Index", "Home");
                }
            }
            _log.Info("Đăng ký môn học thành công");
            TempData["success"] = "Đăng ký môn học thành công";
            return RedirectToAction("Index", "Home");
        }
    }
}