using Seven.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Seven.Controllers
{
    public class OrganitationsController : Controller
    {
        private SevenContext db = new SevenContext();

        // GET: Organitations
        public ActionResult Index()
        {
            return View(db.Organitations.ToList());
        }

        // GET: Organitations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organitation organitation = db.Organitations.Find(id);
            if (organitation == null)
            {
                return HttpNotFound();
            }
            return View(organitation);
        }

        // GET: Organitations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organitations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganitationID,Nit,OrganitationName,Address")] Organitation organitation)
        {
            if (ModelState.IsValid)
            {
                db.Organitations.Add(organitation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organitation);
        }

        // GET: Organitations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organitation organitation = db.Organitations.Find(id);
            if (organitation == null)
            {
                return HttpNotFound();
            }
            return View(organitation);
        }

        // POST: Organitations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganitationID,Nit,OrganitationName,Address")] Organitation organitation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organitation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organitation);
        }

        // GET: Organitations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organitation organitation = db.Organitations.Find(id);
            if (organitation == null)
            {
                return HttpNotFound();
            }
            return View(organitation);
        }

        // POST: Organitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organitation organitation = db.Organitations.Find(id);
            db.Organitations.Remove(organitation);
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
