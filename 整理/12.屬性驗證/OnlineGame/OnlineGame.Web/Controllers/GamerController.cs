using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using OnlineGame.Web.Models;
using OnlineGame.Web.WebShare;
namespace OnlineGame.Web.Controllers
{
    public class GamerController : Controller
    {
        private OnlineGameContext _db = new OnlineGameContext();
        public JsonResult IsEmailAvailable(string emailAddress)
        {
            JsonResult jsonResult = Json(!_db.Gamer.Any(g => g.EmailAddress == emailAddress),
                JsonRequestBehavior.AllowGet);
            //JSONResult to String
            //Reference: https://stackoverflow.com/questions/4571985/jsonresult-to-string
            string jsonResultString = new JavaScriptSerializer().Serialize(jsonResult.Data);
            return jsonResult;
        }
        // GET: Gamer
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IQueryable<Gamer> gamers = _db.Gamer.Include(g => g.Team);
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
            Gamer gamer = await _db.Gamer.FindAsync(id);
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
            ViewBag.TeamId = new SelectList(_db.Team, "Id", "Name");
            return View();
        }
        // POST: Gamer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,City,DateOfBirth,EmailAddress,ConfirmEmailAddress,Score,ProfileUrl,GameMoney,RolePhoto,RolePhotoAltText,TeamId")] Gamer gamer)
        {
            //Validation Logic
            //If the Email already exists, then add Model validation error
            if (_db.Gamer.Any(g => g.EmailAddress == gamer.EmailAddress))
            {
                //AddModelError(Key, ErrorMessage)
                ModelState.AddModelError("EmailAddress", WebShareConst.EmailHasBeenTaken);
            }
            //It is hard to read that validation logic is in controller.
            //Using validation attributes is always preferred method.
            //You may use two different model class for create and edit mode.
            if (!ModelState.IsValid)
            {
                ViewBag.TeamId = new SelectList(_db.Team, "Id", "Name", gamer.TeamId);
                return View(gamer);
            }
            _db.Gamer.Add(gamer);
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
            Gamer gamer = await _db.Gamer.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            gamer.ConfirmEmailAddress = gamer.EmailAddress;
            ViewBag.TeamId = new SelectList(_db.Team, "Id", "Name", gamer.TeamId);
            return View(gamer);
        }
        // POST: Gamer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,City,DateOfBirth,EmailAddress,ConfirmEmailAddress,Score,ProfileUrl,GameMoney,RolePhoto,RolePhotoAltText,TeamId")] Gamer gamer)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TeamId = new SelectList(_db.Team, "Id", "Name", gamer.TeamId);
                return View(gamer);
            }
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
            Gamer gamer = await _db.Gamer.FindAsync(id);
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
            Gamer gamer = await _db.Gamer.FindAsync(id);
            _db.Gamer.Remove(gamer);
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

