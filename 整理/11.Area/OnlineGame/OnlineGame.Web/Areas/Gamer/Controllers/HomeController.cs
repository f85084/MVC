using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineGame.Web.Areas.Gamer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Gamer/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}