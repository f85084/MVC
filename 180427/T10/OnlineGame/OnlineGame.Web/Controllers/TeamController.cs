using System.Web.Mvc;
namespace OnlineGame.Web.Controllers
{
    public class TeamController : Controller
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
            return View();
        }
    }
}
