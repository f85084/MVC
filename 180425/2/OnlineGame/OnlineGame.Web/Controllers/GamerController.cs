using System;
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
            IQueryable<Gamer> gamers = _db.Gamers.Include(g => g.Team);
            return View(await gamers.ToListAsync());
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

        // GET: Gamer/DetailsTwo
        [HttpGet]
        public ActionResult DetailsTwo()
        {
            BoardGame boardGame = new BoardGame();
            return View(boardGame);
        }

        //// GET: Gamer/DetailsThree/5
        [HttpGet]
        public async Task<ActionResult> DetailsThree(int? id)
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
            GamerA gamerA = GamerToGamerA(gamer);
            return View(gamerA);
        }

        [HttpGet]
        public async Task<ActionResult> DetailsFour(int? id)
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
            ViewData["GamerData"] = gamer;
            return View();
        }

        // GET: Gamer/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "Name");
            return View();
        }
        // POST: Gamer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,City,DateOfBirth,EmailAddress,Score,ProfileUrl,GameMoney,TeamId")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                _db.Gamers.Add(gamer);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "Name", gamer.TeamId);
            return View(gamer);
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
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }

        // GET: Gamer/Edit/5
        [HttpGet]
        public async Task<ActionResult> EditTwo(int? id)
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
            GamerA gamerA = GamerToGamerA(gamer);
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "Name", gamerA.TeamId);
            return View(gamerA);
        }
        //// GET: Gamer/Edit/5
        [HttpGet]
        public async Task<ActionResult> EditThree(int? id)
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
            ViewData["GamerData"] = gamer;
            return View();
            //ViewBag.TeamId = new SelectList(_db.Teams, "Id", "Name", gamer.TeamId);
            //return View(gamer);
        }

        //// POST: Gamer/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,City,DateOfBirth,EmailAddress,Score,ProfileUrl,GameMoney,TeamId")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(gamer).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }
        [HttpPost]
        public async Task<ActionResult> EditTwo(GamerA gamerA)
        {
            if (ModelState.IsValid)
            {
                Gamer gamer = GamerAToGamer(gamerA);
                //Retrive data from DB
                Gamer gamerFromDb = await _db.Gamers.SingleAsync(g => g.Id == gamerA.Id);
                //Update all properties except Email and Score
                gamerFromDb.Name = gamer.Name;
                gamerFromDb.Gender = gamer.Gender;
                gamerFromDb.City = gamer.City;
                gamerFromDb.DateOfBirth = gamer.DateOfBirth;
                //gamerFromDb.EmailAddress = gamer.EmailAddress;
                //gamerFromDb.Score = gamer.Score;
                gamerFromDb.ProfileUrl = gamer.ProfileUrl;
                gamerFromDb.GameMoney = gamer.GameMoney;
                gamerFromDb.TeamId = gamer.TeamId;
                _db.Entry(gamerFromDb).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                //return RedirectToAction("Index");
                return RedirectToAction("DetailsThree", new { id = gamerA.Id });
            }
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "Name", gamerA.TeamId);
            return View(gamerA);
        }

        [HttpPost]
        public async Task<ActionResult> EditThree(int id, string name, string gender, string city, DateTime? dateOfBirth, string emailAddress, int? score, string profileUrl, int? gameMoney, int? teamId)
        //public async Task<ActionResult> EditThree(Gamer gamer)
        {
            var gamerData = ViewData["GamerData"];
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
        private static GamerA GamerToGamerA(Gamer gamer)
        {
            GamerA gamerA = new GamerA
            {
                Id = gamer.Id,
                Name = gamer.Name,
                Gender = gamer.Gender,
                City = gamer.City,
                DateOfBirth = gamer.DateOfBirth,
                EmailAddress = gamer.EmailAddress,
                Score = gamer.Score,
                ProfileUrl = gamer.ProfileUrl,
                GameMoney = gamer.GameMoney,
                TeamId = gamer.TeamId
            };
            return gamerA;
        }
        private static Gamer GamerAToGamer(GamerA gamerA)
        {
            Gamer gamer = new Gamer
            {
                Id = gamerA.Id,
                Name = gamerA.Name,
                Gender = gamerA.Gender,
                City = gamerA.City,
                DateOfBirth = gamerA.DateOfBirth,
                EmailAddress = gamerA.EmailAddress,
                Score = gamerA.Score,
                ProfileUrl = gamerA.ProfileUrl,
                GameMoney = gamerA.GameMoney,
                TeamId = gamerA.TeamId
            };
            return gamer;
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
