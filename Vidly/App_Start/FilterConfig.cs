using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // 3shan at2kd eny el user 3amel login f el  APP kolh
            filters.Add(new RequireHttpsAttribute()); //#shan m3mlsh run ll App bta3y 3 HTTP a5leh bs 3 HTTPS
        }
    }
}
