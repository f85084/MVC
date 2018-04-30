using System.Web.Mvc;
namespace OnlineGame.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //home/index
        //[AcceptVerbs(HttpVerbs.Get)]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //home/list2
        [ActionName("List2")]
        public ActionResult Index2()
        {
            return View();
        }
        //home/List3
        [ActionName("List3")]
        public ActionResult Index3()
        {
            return View("Index3");
        }
        //home/Index4
        public string Index4()
        {
            return "<h1>Index4</h1>";
        }
        //home/Index5
        [NonAction] // It is a bad design to use [NonAction] attribute
        public string Index5()
        {
            return "<h1>Index5</h1>";
        }
        //home/Index6
        private string Index6()
        {
            return "<h1>Index6</h1>";
        }
    }
}
