using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineGame.Web.Models;

namespace OnlineGame.Web.Controllers
{
    public class GamersController : Controller
    {
        private OnlineGameContext db = new OnlineGameContext();

        // GET: Gamers
        public ActionResult Index()
        {
            var gamer = db.Gamer.Include(g => g.Team);
            return View(gamer.ToList());
        }

        // GET: Gamers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = db.Gamer.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        // GET: Gamers/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Team, "Id", "Name");
            return View();
        }

        // POST: Gamers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,City,DateOfBirth,EmailAddress,Score,ProfileUrl,GameMoney,RolePhoto,RolePhotoAltText,TeamId")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Gamer.Add(gamer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Team, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }

        // GET: Gamers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = db.Gamer.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Team, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }

        // POST: Gamers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,City,DateOfBirth,EmailAddress,Score,ProfileUrl,GameMoney,RolePhoto,RolePhotoAltText,TeamId")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Team, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }

        // GET: Gamers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = db.Gamer.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        // POST: Gamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gamer gamer = db.Gamer.Find(id);
            db.Gamer.Remove(gamer);
            db.SaveChanges();
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
