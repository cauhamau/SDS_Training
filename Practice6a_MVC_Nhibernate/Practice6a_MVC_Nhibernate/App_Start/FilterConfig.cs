using System.Web;
using System.Web.Mvc;

namespace Practice6a_MVC_Nhibernate
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
