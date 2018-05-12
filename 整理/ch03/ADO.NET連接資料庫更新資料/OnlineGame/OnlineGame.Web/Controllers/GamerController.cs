﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;
using OnlineGame.Web.Data;
using Gamer = OnlineGame.Web.Models.Gamer;

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
            }
            else
            {
                gamer = onlineGameContext.Gamers.Single(p => p.Id == id);
                //Throws exception if can not find the single entity
            }
            return View(gamer);
        }


        //Entity Framework
        public ActionResult Index(int teamId)
        {
            //Entity Framework
            OnlineGameContext context = new OnlineGameContext();
            List<Gamer> gamers = context.Gamers.Where(gamer => gamer.TeamId == teamId).ToList();
            return View(gamers);
        }


        //Ado.Net
        public ActionResult Index2()
        {
            //Ado.Net
            GamerBusinessLayer gamerBusinessLayer = new GamerBusinessLayer();
            List<BusinessLayer.Gamer> gamers = gamerBusinessLayer.Gamers.ToList();
            return View(gamers);
        }


        //Ado.Net
        //[HttpGet] attribute means it only respond to the "GET" request. 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        //Ado.Net
        // 1. Retrieve form data using FormCollection
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            ////FormCollection implement C# indexer. 
            ////See each key and value of formCollection.
            //foreach (string key in formCollection.AllKeys)
            //{
            //    Response.Write($"key=={key}, {formCollection[key]}, <br/>");
            //}

            int teamId;
            BusinessLayer.Gamer gamer = new BusinessLayer.Gamer
            {
                Name = formCollection["Name"],
                Gender = formCollection["Gender"],
                City = formCollection["City"],
                DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]),
                TeamId = int.TryParse(formCollection["TeamId"], out teamId) ? teamId : 0
            };

            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();

            gamerBusinessLayer.AddGamer(gamer);
            return RedirectToAction("Index2");
        }


        //Ado.Net
        // 2. Retrieve form data using name attribute of input tag from cshtml
        [HttpPost]
        public ActionResult Create2(string name, string gender, string city, DateTime dateOfBirth, int teamId)
        {
            BusinessLayer.Gamer gamer = new BusinessLayer.Gamer
            {
                Name = name,
                Gender = gender,
                City = city,
                DateOfBirth = dateOfBirth,
                TeamId = teamId
            };

            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();

            gamerBusinessLayer.AddGamer(gamer);
            return RedirectToAction("Index2");
        }


        //Ado.Net
        // 3. Retrieve form data using model binding
        [HttpPost]
        public ActionResult Create3(BusinessLayer.Gamer gamer)
        {
            //if any of input is not valid.
            if (!ModelState.IsValid)
            {
                return View("Create");
                //Go to Create.cshtml, 
                //so users can correct their input value.
            }

            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();

            gamerBusinessLayer.AddGamer(gamer);
            return RedirectToAction("Index2");
        }


        //Ado.Net
        // 4. Retrieve form data using model binding by UpdateModel() or TryUpdateModel()
        [HttpPost]
        [ActionName("Create4")]
        public ActionResult Create_Post()
        {
            //if any of input is not valid.
            if (!ModelState.IsValid)
            {
                return View("Create");
                //Go to Create.cshtml, 
                //so users can correct their input value.
            }
            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();

            BusinessLayer.Gamer gamer = new BusinessLayer.Gamer();
            //UpdateModel<BusinessLayer.Gamer>(gamer);
            //UpdateModel(gamer);
            TryUpdateModel(gamer);
            //1.
            // UpdateModel() and TryUpdateModel() inspects all the HttpRequest inputs 
            // such as posted Form data, QueryString, 
            // Cookies and Server variables and populate the gamer object.

            gamerBusinessLayer.AddGamer(gamer);
            return RedirectToAction("Index2");
        }


        //Ado.Net
        //[HttpGet] attribute means it only respond to the "GET" request. 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            GamerBusinessLayer gamerBusinessLayer = new GamerBusinessLayer();
            BusinessLayer.Gamer gamer = gamerBusinessLayer.Gamers.Single(g => g.Id == id);
            return View(gamer);
        }


        //Ado.Net
        //1.
        //Edit by Model binding will open the back door for unintended update.
        [HttpPost]
        public ActionResult Edit(BusinessLayer.Gamer gamer)
        {
            if (!ModelState.IsValid)
            {
                return View(gamer);
            }

            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();
            gamerBusinessLayer.SaveGamer(gamer);

            return RedirectToAction("Index2");
        }


        //Ado.Net
        //2.
        //Solved the unintended update.
        //Edit by UpdateModel() and TryUpdateModel()
        [HttpPost]
        [ActionName("Edit2")]
        public ActionResult Edit_Post(int id)
        {
            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();
            BusinessLayer.Gamer gamer = gamerBusinessLayer.Gamers.Single(g => g.Id == id);

            //1.
            ////UpdateModel(gamer, new[] { "Id", "Gender", "City", "DateOfBirth", "TeamId" });
            //The second parameter of UpdateModel() and TeyUpdateModel() is included properties.
            //In this case, it will only update the following properties into model.
            //"Id", "Gender", "City", "DateOfBirth", "TeamId"
            //The Name property is not included so it will not be updated.
            //2.
            ////UpdateModel(gamer, null, null, new[] { "Name" });
            //update all properties except Name property
            UpdateModel(gamer, null, null, new[] { "Name" });

            if (!ModelState.IsValid)
            {
                return View("Edit", gamer);
            }

            gamerBusinessLayer.SaveGamer(gamer);
            return RedirectToAction("Index2");
        }


        //Ado.Net
        //3.
        //Solved the unintended update.
        //Edit by Model binding with Bind include attribute
        [HttpPost]
        public ActionResult Edit3([Bind(Include = "Id, Gender, City, DateOfBirth, TeamId")]BusinessLayer.Gamer gamer)
        {
            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();
            gamer.Name = gamerBusinessLayer.Gamers.Single(g => g.Id == gamer.Id).Name;

            if (!ModelState.IsValid)
            {
                return View("Edit", gamer);
            }

            gamerBusinessLayer.SaveGamer(gamer);

            return RedirectToAction("Index2");
        }


        //Ado.Net
        //4.
        //Solved the unintended update.
        //Edit by Model binding with Bind exclude attribute
        [HttpPost]
        public ActionResult Edit4([Bind(Exclude = "Name")]BusinessLayer.Gamer gamer)
        {
            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();
            gamer.Name = gamerBusinessLayer.Gamers.Single(g => g.Id == gamer.Id).Name;

            if (!ModelState.IsValid)
            {
                return View("Edit", gamer);
            }

            gamerBusinessLayer.SaveGamer(gamer);

            return RedirectToAction("Index2");
        }


        //Ado.Net
        //5.
        //Solved the unintended update.
        //Edit by UpdateModel() and TryUpdateModel() with Interface
        [HttpPost]
        public ActionResult Edit5(int id)
        {
            GamerBusinessLayer gamerBusinessLayer =
                new GamerBusinessLayer();
            BusinessLayer.Gamer gamer = gamerBusinessLayer.Gamers.Single(g => g.Id == id);

            //1.
            ////TryUpdateModel(gamer, new[] { "Id", "Gender", "City", "DateOfBirth", "TeamId" });
            ////UpdateModel(gamer, new[] { "Id", "Gender", "City", "DateOfBirth", "TeamId" });
            //The second parameter of UpdateModel() and TeyUpdateModel() is included properties.
            //In this case, it will only update the following properties into model.
            //"Id", "Gender", "City", "DateOfBirth", "TeamId"
            //The Name property is not included so it will not be updated.
            //2.
            ////TryUpdateModel(gamer, null, null, new[] { "Name" });
            ////UpdateModel(gamer, null, null, new[] { "Name" });
            //update all properties except Name property
            //3.
            ////TryUpdateModel<IGamer>(gamer);
            ////UpdateModel<IGamer>(gamer);
            //The UpdateModel() function will update only the properties 
            //that are present in the interface.
            UpdateModel<IGamer>(gamer);

            if (!ModelState.IsValid)
            {
                return View("Edit", gamer);
            }

            gamerBusinessLayer.SaveGamer(gamer);
            return RedirectToAction("Index2");
        }



    }
}

/*
1.
//var onlineGameContext = new OnlineGameContext();
//Gamer gamer = onlineGameContext.Gamers.Single(p => p.Id == id);
When user request, EntityFramework will request the data from the database
and sotre its data into a temp place called DBSet.
onlineGameContext.Gamers is a DBSet which is kind of temp place to store the Gamer Table Data.
We use LINQ to map the Gamer Table Column id to Gamer Model property, id.
Thus, we can get the gamer entity from Gamer Table by its id.
Then store gamer entity data into Gamer Model object.
Thus, each Gamer Model object is a temp place to store each Gamer Table entity from the database.
Then we pass the Gamer Model object as the ViewModel,
Thus, the Details.cshtml view can use the values from Gamer Model object
which is the temp place to store Gamer Table entity data.

-------------------------------
2.
//[HttpGet]
//public ActionResult Create()
The GET request will direct to Views/Gamer/Create.cshtml.

-------------------------------
3.
//[HttpPost]
//Create
-----------------
3.1.
//[HttpPost]
//public ActionResult Create(FormCollection formCollection)
Retrieve form data using FormCollection.
The key is the name attribute of input or select tag from cshtml.
-----------------
3.2.
//[HttpPost]
//public ActionResult Create2(string name, string gender, string city, DateTime dateOfBirth, int teamId)
Retrieve form data using name attribute of input tag from cshtml.
3.2.1.
string name is from
//<input class="form-control text-box single-line" id="Name" name="Name" type="text" value="">
3.2.2.
string gender is from
//<select id="Gender" name="Gender">...</select>
3.2.3.
string city is from
<input class="form-control text-box single-line" id="City" name="City" type="text" value="">
3.2.4.
DateTime dateOfBirth is from
//<input class="form-control text-box single-line" data-val="true" data-val-date="The field DateOfBirth must be a date." data-val-required="The DateOfBirth field is required." id="DateOfBirth" name="DateOfBirth" type="datetime" value="">
3.2.5.
int teamId is from
//<input class="form-control text-box single-line" data-val="true" data-val-number="The field TeamId must be a number." data-val-required="The TeamId field is required." id="TeamId" name="TeamId" type="number" value="">
-----------------
3.3.
//[HttpPost]
//public ActionResult Create3(BusinessLayer.Gamer gamer)
If the view has a lot of input, 
then the previous two ways is not a good idea.
It is always better to retrieve form data using model binding.
The model of the cshtml is BusinessLayer.Gamer, 
so we can pass the model object into HttpPost action.
The property value of model object will contain the value 
from input or select tag from cshtml based on name attribute.
-----------------
3.4.
//[HttpPost]
//[ActionName("Create4")]
//public ActionResult Create_Post()
Retrieve form data using model binding by UpdateModel() or TryUpdateModel()
...
//BusinessLayer.Gamer gamer = new BusinessLayer.Gamer();
//UpdateModel<BusinessLayer.Gamer>(gamer);
//UpdateModel(gamer);
//TryUpdateModel(gamer);
---------
3.4.1.
UpdateModel() and TryUpdateModel() inspects all the HttpRequest inputs 
such as posted Form data, QueryString, 
Cookies and Server variables and populate the gamer object.
---------
3.4.2.
UpdateModel() throws an exception if validation fails.
TryUpdateModel() will never throw an exception and 
return false if validation fails.
---------
3.4.3.
//UpdateModel(gamer, new[] { "Id", "Gender", "City", "DateOfBirth", "TeamId" });
//TryUpdateModel(gamer, new[] { "Id", "Gender", "City", "DateOfBirth", "TeamId" });
The second parameter of UpdateModel() and TeyUpdateModel() is included properties.
In this case, it will only update the following properties into the model.
"Id", "Gender", "City", "DateOfBirth", "TeamId"
The Name property is not included so it will not be updated.
---------
3.4.4.
//TryUpdateModel(gamer, null, null, new[] { "Name" });
//UpdateModel(gamer, null, null, new[] { "Name" });
update all properties except Name property
---------
3.4.5.
//TryUpdateModel<IGamer>(gamer);
//UpdateModel<IGamer>(gamer);
The UpdateModel() function will update only the properties 
that are present in the interface.


-------------------------------
4.
//[HttpPost]
//Edit
-----------------
4.1.
//[HttpPost]
//public ActionResult Edit(BusinessLayer.Gamer gamer)
Edit by Model binding will open the back door for unintended update.
-----------------
4.2.
//[HttpPost]
//[ActionName("Edit2")]
//public ActionResult Edit_Post(int id)
Solved the unintended update.
Edit by UpdateModel() and TryUpdateModel()
-----------------
4.3.
//[HttpPost]
//public ActionResult Edit3([Bind(Include = "Id, Gender, City, DateOfBirth, TeamId")]BusinessLayer.Gamer gamer)
Solved the unintended update.
Edit by Model binding with Bind include attribute
-----------------
4.4.
//[HttpPost]
//public ActionResult Edit4([Bind(Exclude = "Name")]BusinessLayer.Gamer gamer)
Solved the unintended update.
Edit by Model binding with Bind exclude attribute


*/
