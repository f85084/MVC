using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineGame.Web.Models;

namespace OnlineGame.Web.Controllers
{
    public class GamerController : Controller
    {
        private OnlineGameContext db = new OnlineGameContext();

        // GET: Gamer
        public async Task<ActionResult> Index()
        {
            return View(await db.Gamers.ToListAsync());
        }

        // GET: Gamer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        // GET: Gamer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gamer/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,Score,GameMoney")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Gamers.Add(gamer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gamer);
        }

        // GET: Gamer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        // POST: Gamer/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,Score,GameMoney")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gamer);
        }

        // GET: Gamer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        // POST: Gamer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Gamer gamer = await db.Gamers.FindAsync(id);
            db.Gamers.Remove(gamer);
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
