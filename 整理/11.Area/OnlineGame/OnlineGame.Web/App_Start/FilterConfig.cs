using System.Web.Mvc;
namespace WebApplication1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
/*
1.
Register Customized Error View
1.1.
Register HandleErrorAttribute to global filter
In Global.asax,
//FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
We pass the GlobalFilters.Filters to
//public static void RegisterGlobalFilters(GlobalFilterCollection filters)
Here, we register "HandleErrorAttribute" to global filter.
1.2.
In Web.Config, add the customErrors mode="On"
//<system.web>
//    <customErrors mode="On">
//    </customErrors>
1.3.
Create error view, Views/Shared/Error.cshtml
*/
