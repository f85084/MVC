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
using PagedList;

namespace OnlineGame.Web.Controllers
{
    public class GamersController : Controller
    {
        private OnlineGameContext db = new OnlineGameContext();

        //GET: Gamers
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Gamer.ToListAsync());
        //}

        // GET: Gamer
        [HttpGet]
        public async Task<ActionResult> Index(string searchBy, string searchText, int? pageNumber, string sortBy)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.GenderSort = sortBy == "Gender" ? "Gender desc" : "Gender";

            List<Gamer> gamers = await db.Gamer.ToListAsync();
            if (searchBy == "Gender")
            {
                gamers = await db.Gamer
                    .Where(x => x.Gender == searchText || searchText == null)
                    .ToListAsync();
            }
            if (searchBy == "Name")
            {
                gamers = await db.Gamer
                    .Where(x => x.Name.Contains(searchText) || searchText == null)
                    .ToListAsync();
            }
            IOrderedEnumerable<Gamer> gamersOrderedEnumerable;
            switch (sortBy)
            {
                case "Name desc":
                    gamersOrderedEnumerable = gamers.OrderByDescending(x => x.Name);
                    break;
                case "Gender desc":
                    gamersOrderedEnumerable = gamers.OrderByDescending(x => x.Gender);
                    break;
                case "Gender":
                    gamersOrderedEnumerable = gamers.OrderBy(x => x.Gender);
                    break;
                default:
                    gamersOrderedEnumerable = gamers.OrderBy(x => x.Name);
                    break;
            }
            //1.
            //The first parameter is pagenumber
            //pageNumber ?? 1 means if the pageNumber==null, then pageNumber==1
            //2.
            //The 2nd parameter is page size.
            //We set page size is 5.
            //IPagedList<Gamer> gamerPagedList = gamers.ToPagedList(pageNumber ?? 1, 5);
            IPagedList<Gamer> gamerPagedList = gamersOrderedEnumerable.ToPagedList(pageNumber ?? 1, 5);
            return View(gamerPagedList);
        }

        // GET: Gamers/Details/5
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

        // GET: Gamers/Edit/5
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

        // POST: Gamers/Edit/5
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

        // GET: Gamers/Delete/5
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

        // POST: Gamers/Delete/5
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
