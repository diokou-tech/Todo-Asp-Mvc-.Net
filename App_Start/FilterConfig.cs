using System.Web;
using System.Web.Mvc;

namespace Todo_Asp_Mvc.Net
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
