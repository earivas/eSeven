using Seven.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Seven.Controllers
{
    public class PageTypesController : Controller
    {
        private SevenContext db = new SevenContext();

        // GET: PageTypes
        public ActionResult Index()
        {
            return View(db.PageTypes.ToList());
        }

        // GET: PageTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageType pageType = db.PageTypes.Find(id);
            if (pageType == null)
            {
                return HttpNotFound();
            }
            return View(pageType);
        }

        // GET: PageTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PageTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageTypeID,PageTypeDescription")] PageType pageType)
        {
            if (ModelState.IsValid)
            {
                db.PageTypes.Add(pageType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pageType);
        }

        // GET: PageTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageType pageType = db.PageTypes.Find(id);
            if (pageType == null)
            {
                return HttpNotFound();
            }
            return View(pageType);
        }

        // POST: PageTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageTypeID,PageTypeDescription")] PageType pageType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pageType);
        }

        // GET: PageTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageType pageType = db.PageTypes.Find(id);
            if (pageType == null)
            {
                return HttpNotFound();
            }
            return View(pageType);
        }

        // POST: PageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageType pageType = db.PageTypes.Find(id);
            db.PageTypes.Remove(pageType);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

              //  throw;
            }
      
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
