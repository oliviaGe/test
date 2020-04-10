using System.Web.Mvc;
using SSO.Utilities;


namespace TestA.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeBaseAttribute());
        }
    }
}