using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice6a_MVC_Nhibernate.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string idUrl = httpContext.Request.Url.Segments.LastOrDefault(); //student/details?id=2024001
            foreach (var role in allowedroles)
            {
                if (httpContext.User.IsInRole(role))
                {
                    if (role=="student" && httpContext.User.Identity.Name!= idUrl)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}