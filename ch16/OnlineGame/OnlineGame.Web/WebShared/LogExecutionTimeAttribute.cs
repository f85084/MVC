using System;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace MVCDemo.WebShared
{
    public class LogExecutionTimeAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string logText = $"\n[{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName} : {filterContext.ActionDescriptor.ActionName}] -> OnActionExecuting \t- {DateTime.Now}\n";
            LogExecutionTimeIntoFile(logText);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string logText = $"\n[{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName} : {filterContext.ActionDescriptor.ActionName}] -> OnActionExecuted \t- {DateTime.Now}\n";
            LogExecutionTimeIntoFile(logText);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string logText = $"\n[{filterContext.RouteData.Values["controller"]} : {filterContext.RouteData.Values["action"]}] -> OnResultExecuting \t- {DateTime.Now} \n";
            LogExecutionTimeIntoFile(logText);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string logText = $"\n[{filterContext.RouteData.Values["controller"]} : {filterContext.RouteData.Values["action"]}] -> OnResultExecuted \t- {DateTime.Now} \n";
            LogExecutionTimeIntoFile(logText);
            LogExecutionTimeIntoFile("---------------------------------------------------------\n");
        }
        public void OnException(ExceptionContext filterContext)
        {
            string logText = $"\n[{filterContext.RouteData.Values["controller"]} : {filterContext.RouteData.Values["action"]}] -> \n OnException Message: {filterContext.Exception.Message}OnResultExecuted \t- {DateTime.Now} \n";
            LogExecutionTimeIntoFile(logText);
            LogExecutionTimeIntoFile("---------------------------------------------------------\n");
        }
        private void LogExecutionTimeIntoFile(string logText)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/LogExecutionTime/LogExecutionTime.txt"), logText);
        }
    }
}

