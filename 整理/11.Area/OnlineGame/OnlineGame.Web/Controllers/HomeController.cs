﻿using System.Web.Mvc;

namespace OnlineGame.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}