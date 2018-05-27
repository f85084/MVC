using System.Web.Mvc;

namespace OnlineGame.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index3()
        {
            return View("Index3", "_Layout3");
        }
    }
}