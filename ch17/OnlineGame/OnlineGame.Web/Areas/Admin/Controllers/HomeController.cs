using System.Web.Mvc;
namespace OnlineGame.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}