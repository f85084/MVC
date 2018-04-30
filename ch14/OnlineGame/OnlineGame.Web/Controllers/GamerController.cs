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
using System.Globalization;
using OnlineGame.Web.WebShared;

namespace OnlineGame.Web.Controllers
{
    public class GamerController : Controller
    {
        private OnlineGameContext db = new OnlineGameContext();

        // GET: Gamer
        public async Task<ActionResult> Index()
        {
            return View(await db.Gamer.ToListAsync());
        }

        // GET: Gamer
        [HttpGet]
        [OutputCache(Duration = 10)]
        //[OutputCache(Duration = 10, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient)]
        //[OutputCache(Duration = 10, VaryByParam = "None", Location = OutputCacheLocation.Client)]
        public async Task<ActionResult> Index2()
        {
            System.Threading.Thread.Sleep(3000);
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(await db.Gamer.ToListAsync());
        }

        // GET: Gamer
        [HttpGet]
        public async Task<ActionResult> Index3()
        {
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(await db.Gamer.ToListAsync());
        }
        // GET: Gamer
        [HttpGet]
        public async Task<ActionResult> Index3V2()
        {
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(await db.Gamer.ToListAsync());
        }

        //[ChildActionOnly] make the action to be accessible only by a child request,
        //so no one can make a direct URL request to this action.
        [ChildActionOnly]
        [HttpGet]
        [OutputCache(Duration = 10)]
        public string GetGamerCount()
        {
            System.Threading.Thread.Sleep(3000);
            return $"Gamer Count = {db.Gamer.Count()} At {DateTime.Now}";
        }

        [HttpGet]
        //[OutputCache(Duration = 60)]
        [OutputCache(CacheProfile = "outputCacheProfile1")]
        public async Task<ActionResult> Index4()
        {
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(await db.Gamer.ToListAsync());
        }

        //[ChildActionOnly] make the action to be accessible only by a child request,
        //so no one can make a direct URL request to this action.
        [ChildActionOnly]
        [HttpGet]
        //[OutputCache(Duration = 60)]
        //[OutputCache(CacheProfile = "outputCacheProfile1")]   //This will thrwo exception
        [CustomizeCache("outputCacheProfile1")]
        public string GetGamerCount2()
        {
            System.Threading.Thread.Sleep(3000);
            return $"Gamer Count = {db.Gamer.Count()} At {DateTime.Now}";
        }

        // GET: Gamer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamer.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,EmailAddress")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Gamer.Add(gamer);
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
            Gamer gamer = await db.Gamer.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,EmailAddress")] Gamer gamer)
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
            Gamer gamer = await db.Gamer.FindAsync(id);
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
            Gamer gamer = await db.Gamer.FindAsync(id);
            db.Gamer.Remove(gamer);
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
