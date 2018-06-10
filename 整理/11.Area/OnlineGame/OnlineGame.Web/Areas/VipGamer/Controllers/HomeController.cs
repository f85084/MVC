using System.Web.Mvc;
namespace OnlineGame.Web.Areas.VipGamer.Controllers
{
    public class HomeController : Controller
    {
        // GET: VipGamer/Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
