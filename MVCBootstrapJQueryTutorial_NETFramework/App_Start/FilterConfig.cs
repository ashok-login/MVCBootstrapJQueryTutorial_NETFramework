using System.Web;
using System.Web.Mvc;

namespace MVCBootstrapJQueryTutorial_NETFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
