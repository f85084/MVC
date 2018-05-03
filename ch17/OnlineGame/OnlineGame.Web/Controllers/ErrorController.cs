using System.Web.Mvc;
namespace OnlineGame.Web.Controllers
{
    public class ErrorController : Controller
    {
        //error statusCode="401"
        [HttpGet]
        public ActionResult UnauthorizedError()
        {
            return View();
        }
        //error statusCode="404"
        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
        //error statusCode="500"
        [HttpGet]
        public ActionResult InternalServerError()
        {
            return View();
        }
    }
}
/*
1.
In the Web.config
//<customErrors mode="On" defaultRedirect="Error/DefaultError">
//    <error statusCode="401" redirect="Error/UnauthorizedError" />
//    <error statusCode="404" redirect="Error/NotFound" />
//    <error statusCode="500" redirect="Error/InternalServerError" />
//</customErrors>
We notice that it will still show the Views/Shared/Error.cshtml
when exception occurs.
Thus, we can delete Views/Shared/DefaultError.cshtml.
We also can delete DefaultError() in ErrorController.cs
In the Web.config, we can set as the following.
//<customErrors mode="On">
//    <error statusCode="401" redirect="Error/UnauthorizedError" />
//    <error statusCode="404" redirect="Error/NotFound" />
//    <error statusCode="500" redirect="Error/InternalServerError" />
//</customErrors>
*/

