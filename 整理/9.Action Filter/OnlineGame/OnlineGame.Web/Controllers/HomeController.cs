using System.Web.Mvc;

namespace OnlineGame.Web.Controllers
{
    ////[Authorize]
    //1.
    //[Authorize] Need authentication to access
    //2.
    //[Authorize] can apply to controller level.

    [Authorize]
    public class HomeController : Controller
    {
        //1.
        ////[AllowAnonymous]
        //If [Authorize] apply to controller level,
        //then you need [AllowAnonymous] to apply to NonSecureIndex()
        [HttpGet]   //Home/NonSecureIndex
        [AllowAnonymous]
        public ActionResult NonSecureIndex()
        {
            return View();
        }


        //[Authorize] //Need authentication to access
        [HttpGet]   //Home/SecureIndex
        public ActionResult SecureIndex()
        {
            return View();
        }
    }
}