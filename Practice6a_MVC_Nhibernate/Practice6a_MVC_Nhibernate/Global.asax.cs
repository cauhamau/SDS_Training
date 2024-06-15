using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Practice6a_MVC_Nhibernate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //log4net.Config.XmlConfigurator.Configure();
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
  
                    var identity = (FormsIdentity)HttpContext.Current.User.Identity;

                    var ticket = identity.Ticket;

                    string[] roles = ticket.UserData.Split(',');

                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(identity, roles);
                }
            }
        }
    }
}
