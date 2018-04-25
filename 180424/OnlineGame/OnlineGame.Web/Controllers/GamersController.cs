﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using OnlineGame.Web.Models;
namespace OnlineGame.Web.Controllers
{
    public class GamersController : Controller
    {
       private OnlineGameEntities db = new OnlineGameEntities();
         public ActionResult GamersByTeam()
        {
            ////db.Gamers.Include("Team")
            //Retrive the Gamers with their Team data.
            List<TeamTotals> teamTotals =
                db.Gamers.Include("Team")
                .GroupBy(g => g.Team.Name)
                .Select(gamer => new TeamTotals
                {
                    Name = gamer.Key,
                    Total = gamer.Count()
                }).ToList();
            return View(teamTotals);
        }
        // GET: Gamers
        public async Task<ActionResult> Index()
        {
            IQueryable<Gamer> gamers = db.Gamers.Include(g => g.Team);
            return View(await gamers.ToListAsync());  //~/Views/Gamers/Index.cshtml
            //return View("Index", await gamers.ToListAsync());    //~/Views/Gamers/Index.cshtml
            //return View("Index.cshtml", await gamers.ToListAsync());    //  Error
            //return View(await gamers.ToListAsync());
        }
        // GET: Gamers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                //return BadRequest code.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                //return HttpNotFound code.
                return HttpNotFound();
            }
            return View(gamer);
        }
        // GET: Gamers/Create
        public ActionResult Create()
        {
            //Use the collection of teams as the parameter to create SelectList
            //which value is Team Id and the text is Team Name.
            //ViewBag.TeamId will bind this SelectList to View Model TeamId property.
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }
        // POST: Gamers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,City,DateOfBirth,TeamId")] Gamer gamer)
        {
            // We don't allow Fiddler to compose the Post body to change Name property,
            //so we don't use [Required] attribute on Name property.
            //However, in Create mode, we want to set Name is required property.
            //Thus, we have to dynamically add the ModelState.AddModelError in Create action
            if (string.IsNullOrEmpty(gamer.Name))
            {
                ModelState.AddModelError("Name", "Name is required.");
            }
            if (ModelState.IsValid)
            {
                db.Gamers.Add(gamer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //Use the collection of teams as the parameter to create SelectList
            //which value is Team Id and the text is Team Name.
            //ViewBag.TeamId will bind this SelectList to View Model TeamId property.
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }
        // GET: Gamers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                //return BadRequest code.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                //return HttpNotFound code.
                return HttpNotFound();
            }
            //Use the collection of teams as the parameter to create SelectList
            //which value is Team Id and the text is Team Name.
            //ViewBag.TeamId will bind this SelectList to View Model TeamId property.
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }
        //1.
        // POST: Gamers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //2.
        ////public async Task<ActionResult> Edit([Bind(Include = "Id,Gender,City,DateOfBirth,TeamId")] Gamer gamer)
        //Only update properties in the list, and ignore rest of properties.
        //In this case, update will exclude the Name property.
        //Thus, The post body generated by Fiddler can not update Name property.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Gender,City,DateOfBirth,TeamId")] Gamer gamer)
        {
            //Get the gamer
            Gamer gamerFromDb = db.Gamers.Single(g => g.Id == gamer.Id);
            //Update the gamerFromDb
            gamerFromDb.Id = gamer.Id;
            gamerFromDb.Gender = gamer.Gender;
            gamerFromDb.City = gamer.City;
            gamerFromDb.TeamId = gamer.TeamId;

            //In the beginning, gamer.Name is null.
            //In order to pass ModelState.IsValid,
            //we need to set value for gamer.Name
            gamer.Name = gamerFromDb.Name;

            if (ModelState.IsValid)
            {
                //Update the entity by gamerFromDb, and set state as EntityState.Modified
                db.Entry(gamerFromDb).State = EntityState.Modified;
                await db.SaveChangesAsync();    //Save changes.
                return RedirectToAction("Index");
            }

            //1.
            //if validation is failed, then stay in the same page.
            //2.
            //Use the collection of teams as the parameter to create SelectList
            //which value is Team Id and the text is Team Name.
            //ViewBag.TeamId will bind this SelectList to View Model TeamId property.
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }

        // GET: Gamers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                // bad request.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Get the gamers
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                //return HttpNotFound code.
                return HttpNotFound();
            }
            return View(gamer);
        }
        // POST: Gamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer != null) db.Gamers.Remove(gamer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}