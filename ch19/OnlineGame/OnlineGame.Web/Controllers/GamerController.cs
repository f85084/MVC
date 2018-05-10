using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using OnlineGame.Web.Models;
namespace OnlineGame.Web.Controllers
{
    public class GamerController : Controller
    {
        private OnlineGameContext _db = new OnlineGameContext();
        // GET: Gamer
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _db.Gamers.ToListAsync());
        }
        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }
        // Return all
        [HttpGet]
        public async Task<PartialViewResult> All()
        {
            List<Gamer> model = await _db.Gamers.ToListAsync();
            return PartialView("_Gamer", model);
        }
        // Return all
        [HttpGet]
        public async Task<PartialViewResult> All_2Seconds()
        {
            System.Threading.Thread.Sleep(2000);
            List<Gamer> model = await _db.Gamers.ToListAsync();
            return PartialView("_Gamer", model);
        }
        // Return all
        [HttpGet]
        public async Task<PartialViewResult> All_ThrowException_2Seconds()
        {
            System.Threading.Thread.Sleep(2000);
            List<Gamer> model = await _db.Gamers.ToListAsync();
            throw new Exception("All_ThrowException_2Seconds, something bad happened.");
            return PartialView("_Gamer", model);
        }
        // Return Score Top Three
        [HttpGet]
        public async Task<PartialViewResult> ScoreTopThree()
        {
            List<Gamer> model = await _db.Gamers
                .OrderByDescending(g => g.Score)
                .Take(3)
                .ToListAsync();
            return PartialView("_Gamer", model);
        }
        // Return Score Top Three
        [HttpGet]
        public async Task<PartialViewResult> ScoreTopThree_2Seconds()
        {
            System.Threading.Thread.Sleep(2000);
            List<Gamer> model = await _db.Gamers
                .OrderByDescending(g => g.Score)
                .Take(3)
                .ToListAsync();
            return PartialView("_Gamer", model);
        }
        // Return Score Bottom Three
        [HttpGet]
        public async Task<PartialViewResult> ScoreBottomThree()
        {
            List<Gamer> model = await _db.Gamers
                .OrderBy(g => g.Score)
                .Take(3)
                .ToListAsync();
            return PartialView("_Gamer", model);
        }
        // Return Score Bottom Three
        [HttpGet]
        public async Task<PartialViewResult> ScoreBottomThree_2Seconds()
        {
            System.Threading.Thread.Sleep(2000);
            List<Gamer> model = await _db.Gamers
                .OrderBy(g => g.Score)
                .Take(3)
                .ToListAsync();
            return PartialView("_Gamer", model);
        }
        // GET: Gamer/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await _db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }
        // GET: Gamer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        // POST: Gamer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,Score,GameMoney")] Gamer gamer)
        {
            if (!ModelState.IsValid) return View(gamer);
            _db.Gamers.Add(gamer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: Gamer/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await _db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }
        // POST: Gamer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,Score,GameMoney")] Gamer gamer)
        {
            if (!ModelState.IsValid) return View(gamer);
            _db.Entry(gamer).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: Gamer/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await _db.Gamers.FindAsync(id);
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
            Gamer gamer = await _db.Gamers.FindAsync(id);
            _db.Gamers.Remove(gamer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

