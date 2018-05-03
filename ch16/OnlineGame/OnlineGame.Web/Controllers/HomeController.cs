using MVCDemo.WebShared;
using System;
using System.Web.Mvc;
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
        [HttpPost]
        //[ValidateInput(false)]
        public string Index(string note)
        {
            return "Note : " + note;
        }
        // GET: Home
        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public string Index2(string note)
        {
            return "Note : " + note;
        }

        [LogExecutionTime]
        public string Index3()
        {
            return "Home Index3 action has been called.";
        }
        [LogExecutionTime]
        public string Index4()
        {
            throw new Exception("Something Bad happened.");
        }
    }
}
/*
//[HttpPost]
//[ValidateInput(false)]
//public string Index2(string note)
[ValidateInput(true)] is the default setting.
It means we don't take any HTML tag in the input.
When we use [ValidateInput(false)],
it means we allow to have HTML tag input.
This will open the back door for XSS attack.
Please see my previous tutorial for more details
https://ithandyguytutorial.blogspot.com.au/2018/02/t011textareacrosssitescriptingattackxss.html
*/

