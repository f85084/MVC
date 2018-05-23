using System.Linq;
using System.Web.Mvc;
using OnlineGame.Web.Data;
using OnlineGame.Web.Models;
namespace OnlineGame.Web.Controllers
{
    public class GamerController : Controller
    {
        // http://localhost/OnlineGame.Web/Gamer/Details
        //public ActionResult Details()
        //{
        //    var gamer = new Gamer
        //    {
        //        Id = 1,
        //        Name = "Name1",
        //        Gender = "Male",
        //        City = "City1"
        //    };
        //    return View(gamer);
        //}
        // http://localhost/OnlineGame.Web/Gamer/Details
        // http://localhost/OnlineGame.Web/Gamer/Details/1
        // http://localhost/OnlineGame.Web/Gamer/Details/2
        // http://localhost/OnlineGame.Web/Gamer/Details/3
        // http://localhost/OnlineGame.Web/Gamer/Details/4
        public ActionResult Details(int id = 0)
        {
            var onlineGameContext = new OnlineGameContext();
            Gamer gamer;
            if (id == 0)
            {
                gamer = new Gamer
                {
                    Id = 0,
                    Name = "Name0",
                    Gender = "NULL",
                    City = "NULL"
                };
                // or you may throw exception here.
                //寫預設值或是可以丟exception在這邊
            }
            else
            {
                gamer = onlineGameContext.Gamers.Single(p => p.Id == id);
                //Throws exception if can not find the single entity
                //如果沒有找到 就會丟出錯誤訊息
            }
            return View(gamer);
        }
    }
}
/*
//var onlineGameContext = new OnlineGameContext();
//Gamer gamer = onlineGameContext.Gamers.Single(p => p.Id == id);
When user request, EntityFramework will request the data from the database
and sotre its data into a temp place called DBSet.
onlineGameContext.Gamers is a DBSet which is kind of temp place to store the Gamer Table Data.
We use LINQ to map the Gamer Table Column id to Gamer Model property, id.
Thus, we can get the gamer entity from Gamer Table by its id.
Then store gamer entity data into Gamer Model object.
裡面的資料存在 Model object  Gamer 裡面
Thus, each Gamer Model object is a temp place to store each Gamer Table entity from the database.
Then we pass the Gamer Model object as the ViewModel,
Thus, the Details.cshtml view can use the values from Gamer Model object
which is actually the temp place to store Gamer Table entity data.
*/
