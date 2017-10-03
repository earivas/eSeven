using Seven.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Seven.Controllers
{
    public class ProfitCentersController : Controller
    {
        private SevenContext db = new SevenContext();

        // GET: ProfitCenters
        public ActionResult Index()
        {
            return View(db.ProfitCenters.ToList());
        }

        // GET: ProfitCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfitCenter profitCenter = db.ProfitCenters.Find(id);
            if (profitCenter == null)
            {
                return HttpNotFound();
            }
            return View(profitCenter);
        }

        // GET: ProfitCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfitCenters/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfitCenterID,ProfitCenterDescription")] ProfitCenter profitCenter)
        {
            if (ModelState.IsValid)
            {
                db.ProfitCenters.Add(profitCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profitCenter);
        }

        // GET: ProfitCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfitCenter profitCenter = db.ProfitCenters.Find(id);
            if (profitCenter == null)
            {
                return HttpNotFound();
            }
            return View(profitCenter);
        }

        // POST: ProfitCenters/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfitCenterID,ProfitCenterDescription")] ProfitCenter profitCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profitCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profitCenter);
        }

        // GET: ProfitCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfitCenter profitCenter = db.ProfitCenters.Find(id);
            if (profitCenter == null)
            {
                return HttpNotFound();
            }
            return View(profitCenter);
        }

        // POST: ProfitCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfitCenter profitCenter = db.ProfitCenters.Find(id);
            db.ProfitCenters.Remove(profitCenter);
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
