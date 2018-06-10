using System;
using System.Web.Mvc;

namespace OnlineGame.Web.Controllers
{
    public class Home3Controller : Controller
    {
        // GET: Home3
        [HttpGet]   //Home3/Index
        [HandleError]
        public ActionResult Index()
        {
            throw new Exception("Exception occurs");
        }

        public ActionResult Index3()
        {
            throw new Exception("Exception occurs");
        }
    }
}