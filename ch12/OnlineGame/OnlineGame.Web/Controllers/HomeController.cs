using System.Web.Mvc;
namespace OnlineGame.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [Authorize (Users = "Tony")]
        public ActionResult Delete()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [ChildActionOnly]
        public ActionResult ForPartialView()
        {
            return PartialView();
        }

        [OutputCache(Duration = 30)]
        public ActionResult OutputCache()
        {
            ViewBag.Time = DateTime.Now.ToLongTimeString();
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
