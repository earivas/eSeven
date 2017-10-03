using Seven.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Seven.Controllers
{
    public class ModelTypesController : Controller
    {
        private SevenContext db = new SevenContext();

        // GET: ModelTypes
        public ActionResult Index()
        {
            return View(db.ModelTypes.ToList());
        }

        // GET: ModelTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelType modelType = db.ModelTypes.Find(id);
            if (modelType == null)
            {
                return HttpNotFound();
            }
            return View(modelType);
        }

        // GET: ModelTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelTypeID,ModelTypeDescription")] ModelType modelType)
        {
            if (ModelState.IsValid)
            {
                db.ModelTypes.Add(modelType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelType);
        }

        // GET: ModelTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelType modelType = db.ModelTypes.Find(id);
            if (modelType == null)
            {
                return HttpNotFound();
            }
            return View(modelType);
        }

        // POST: ModelTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelTypeID,ModelTypeDescription")] ModelType modelType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelType);
        }

        // GET: ModelTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelType modelType = db.ModelTypes.Find(id);
            if (modelType == null)
            {
                return HttpNotFound();
            }
            return View(modelType);
        }

        // POST: ModelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelType modelType = db.ModelTypes.Find(id);
            db.ModelTypes.Remove(modelType);
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
