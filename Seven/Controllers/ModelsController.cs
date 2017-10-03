using Seven.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Seven.Controllers
{
    public class ModelsController : Controller
    {
        private SevenContext db = new SevenContext();

        // GET: Models
        public ActionResult Index()
        {
            return View(db.ModelPersons.ToList());
        }

        // GET: Models/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPerson modelPerson = db.ModelPersons.Find(id);
            if (modelPerson == null)
            {
                return HttpNotFound();
            }
            return View(modelPerson);
        }

        // GET: Models/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelID,IdentityCard,FirstName,LastName,Address,PhoneNumber,Email,Nick,BirthDate,ProfileType")] ModelPerson modelPerson)
        {
            if (ModelState.IsValid)
            {
                db.ModelPersons.Add(modelPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelPerson);
        }

        // GET: Models/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPerson modelPerson = db.ModelPersons.Find(id);
            if (modelPerson == null)
            {
                return HttpNotFound();
            }
            return View(modelPerson);
        }

        // POST: Models/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelID,IdentityCard,FirstName,LastName,Address,PhoneNumber,Email,Nick,BirthDate,ProfileType")] ModelPerson modelPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelPerson);
        }

        // GET: Models/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPerson modelPerson = db.ModelPersons.Find(id);
            if (modelPerson == null)
            {
                return HttpNotFound();
            }
            return View(modelPerson);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelPerson modelPerson = db.ModelPersons.Find(id);
            db.ModelPersons.Remove(modelPerson);
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
