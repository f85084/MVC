using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineGame.Web.Models
{
    public class GamersController : Controller
    {
        private OnlineGameContext db = new OnlineGameContext();

        // GET: Gamers
        public ActionResult Index()
        {
            return View(db.ContactComment.ToList());
        }

        // GET: Gamers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactComment contactComment = db.ContactComment.Find(id);
            if (contactComment == null)
            {
                return HttpNotFound();
            }
            return View(contactComment);
        }

        // GET: Gamers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gamers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CommentText")] ContactComment contactComment)
        {
            if (ModelState.IsValid)
            {
                db.ContactComment.Add(contactComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactComment);
        }

        // GET: Gamers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactComment contactComment = db.ContactComment.Find(id);
            if (contactComment == null)
            {
                return HttpNotFound();
            }
            return View(contactComment);
        }

        // POST: Gamers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CommentText")] ContactComment contactComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactComment);
        }

        // GET: Gamers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactComment contactComment = db.ContactComment.Find(id);
            if (contactComment == null)
            {
                return HttpNotFound();
            }
            return View(contactComment);
        }

        // POST: Gamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactComment contactComment = db.ContactComment.Find(id);
            db.ContactComment.Remove(contactComment);
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
