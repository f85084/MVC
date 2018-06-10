using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineGame.Web.Controllers
{
    public class Home2Controller : Controller
    {
        // GET: Home2
        [HttpGet]   //Home2/Index
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        [HttpGet]   //Home2/GamersName
        public ActionResult GamersName(List<String> gamersName)
        {
            return View(gamersName);
        }
        [HttpGet]   //Home2/GamersName2
        public ActionResult GamersName2(List<String> gamersName)
        {
            return View(gamersName);
        }
    }
}
/*
1.
//[ChildActionOnly]
1.1.
Background:
In the Views/Home2/Index.cshtml
//@Html.Action("GamersName", new { gamersName = new List<string> { "Name2", "Name1", "Name3" } })
//@{ Html.RenderAction("GamersName", new { gamersName = new List<string> { "Name2", "Name1", "Name3" } }); }
//@Html.Action("GamersName2", new { gamersName = new List<string> { "Name2", "Name1", "Name3" } })
//@{Html.RenderAction("GamersName2", new { gamersName = new List<string> { "Name2", "Name1", "Name3" } });}
We call "GamersName" and "GamersName2" action in the index view.
By default of MVC convention,
users can use URL "Home2/GamersName" and "Home2/GamersName2"
to access the GamersName and GamersName2 actions.
We want to prevent the users to access directly to GamersName and GamersName2 actions.
[NoAction] attribute can do so.
But if the [NoAction] attribute applies to GamersName and GamersName2 actions,
then the Views/Home2/Index.cshtml view can not access these actions either.
Thus, we need [ChildActionOnly] attribute.
1.2.
[ChildActionOnly] make GamersName action to be accessible only by a child request.
That means Index.cshtml view can still access this action,
but the users can not use url "Home2/GamersName" to directly access the GamersName action.
[ChildActionOnly] is usually associated with partial views.
v*/