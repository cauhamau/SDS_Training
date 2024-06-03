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
using System.Web.Security;
namespace Practice6a_MVC_Nhibernate.Controllers
{
    public class HomeController : Controller
    {
        //IWindsorInstaller _installer;
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly IEncryptService _encryptService;
        public HomeController()
        {
            using (var container = DependencyContainer.Bootstrap())
            {
                _studentService = container.Container.Resolve<IStudentService>();
                _userService = container.Container.Resolve<IUserService>();
                _encryptService = container.Container.Resolve<IEncryptService>();
            }
        }

        // GET: Student
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            var a = user;
            
            if (Session["user"]==null)
            {
                return RedirectToAction("Login", "Home");
            }
            else if (user.ROLE=="admin")
            {
                IList<Student> student = _studentService.GetAll();
                return View(student);
            }
            else if (user.ROLE=="student")
            {   
                return RedirectToAction("Details", "Student", new { Id = user.USERNAME });
            }
            else if (user.ROLE=="teacher")
            {
                IList<Student> student = _studentService.GetAll();
                return View(student);
            }
            return RedirectToAction("Login", "Home");
        }
        
        public ActionResult Login(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                // Store the returnUrl in ViewBag or ViewData to access it in the view
                ViewBag.ReturnUrl = returnUrl;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (!(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))) {
                byte[] password_en = _encryptService.HashPasswordSHA256(password);
                User user = _userService.CheckAccountLogIn(username, password_en);
                if (user == null)
                {
                    TempData["warning"] = "Tài khoản hoặc mật khẩu không chính xác";
                    return View();
                }

                FormsAuthentication.SetAuthCookie(username, false);
                Session["user"] = user;

                var authTicket = new FormsAuthenticationTicket(
                    1,                      // Version
                    username,               // User Name
                    DateTime.Now,           // Issue Date
                    DateTime.Now.AddMinutes(15), // Expiration
                    false,                  // Is Persistent
                    user.ROLE                 // User Data (Roles)
                );

                // Mã hóa ticket
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                // Tạo cookie chứa ticket đã mã hóa
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);


                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}