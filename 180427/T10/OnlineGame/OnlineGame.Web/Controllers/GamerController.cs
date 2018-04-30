using System.Web.Mvc;
using OnlineGame.Web.Models;
namespace OnlineGame.Web.Controllers
{
    public class GamerController : Controller
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
        [HttpGet]
        public ActionResult Index4()
        {
            Gamer gamer = new Gamer
            {
                Id = 1,
                Name = "Name1",
                Gender = "Male",
                Score = 2000
            };
            return View(gamer);
        }
        public ActionResult Details()
        {
            Gamer gamer = new Gamer
            {
                Id = 1,
                Name = "Name1",
                Gender = "Male",
                Score = 2000
            };
            return View("_GamerDetails", gamer);
        }
        //In order to prevent layout view apply to partial view.
        //A. Return type is PartialViewResult.
        //B. return PartialView("_PartialViewName", ModelObject);
        public PartialViewResult Details2()
        {
            Gamer gamer = new Gamer
            {
                Id = 1,
                Name = "Name1",
                Gender = "Male",
                Score = 2000
            };
            return PartialView("_GamerDetails", gamer);
        }
    }
}

