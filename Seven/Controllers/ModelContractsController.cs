
using Seven.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Seven.Controllers
{
    public class ModelContractsController : Controller
    {
        private SevenContext db = new SevenContext();

        // GET: ModelContracts
        public ActionResult Index()
        {
            var modelContracts = db.ModelContracts.Include(m => m.Afp).Include(m => m.Arl).Include(m => m.Compensation).Include(m => m.Eps).Include(m => m.ModelType).Include(m => m.Organitation).Include(m => m.ProfitCenter).Include(m => m.Supervisor);
            return View(modelContracts.ToList());
        }

        // GET: ModelContracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelContract modelContract =  db.ModelContracts.Find(id);
            if (modelContract == null)
            {
                return HttpNotFound();
            }
            return View(modelContract);
        }

        // GET: ModelContracts/Create
        public ActionResult Create()

        {
            // Para crear una lista ordenada y adicionar un la opcion "Seleccionar...." 
            // falta validar que el tipo de documento nosea 0 "  ***** listAfp.Add(new Afp { AfpID = 0, AfpDescription ="[Select AFP...]" });
            var listAfp = db.Afps.ToList();
            listAfp.Add(new Afp { AfpID = 0, AfpDescription ="[Select AFP...]" });
            listAfp = listAfp.OrderBy (s => s.AfpDescription).ToList();

            ViewBag.AfpID = new SelectList(listAfp, "AfpID", "AfpDescription");
            ViewBag.ArlID = new SelectList(db.Arls.OrderBy(s => s.ArlDescription), "ArlID", "ArlDescription");
            ViewBag.CompensationID = new SelectList(db.Compensations.OrderBy(s => s.CompensationDescription), "CompensationID", "CompensationDescription");
            ViewBag.EpsID = new SelectList(db.Eps.OrderBy(s => s.EpsDescription), "EpsID", "EpsDescription");
            ViewBag.ModelTypeID = new SelectList(db.ModelTypes.OrderBy(s => s.ModelTypeDescription), "ModelTypeID", "ModelTypeDescription");
            ViewBag.OrganitationID = new SelectList(db.Organitations.OrderBy(s => s.OrganitationName), "OrganitationID", "OrganitationName");
            ViewBag.ProfitCenterID = new SelectList(db.ProfitCenters.OrderBy(s => s.ProfitCenterDescription), "ProfitCenterID", "ProfitCenterDescription");
            ViewBag.SupervisorID = new SelectList(db.Supervisors.OrderBy(s => s.LastName ), "SupervisorID", "IdentityCard");
            return View();
        }

        // POST: ModelContracts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelContractID,Salary,DateAdmision,Percent,OrganitationID,SupervisorID,ModelTypeID,ProfitCenterID,EpsID,AfpID,ArlID,CompensationID")] ModelContract modelContract)
        {
            if (ModelState.IsValid)
            {
                db.ModelContracts.Add(modelContract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AfpID = new SelectList(db.Afps, "AfpID", "AfpDescription", modelContract.AfpID);
            ViewBag.ArlID = new SelectList(db.Arls, "ArlID", "ArlDescription", modelContract.ArlID);
            ViewBag.CompensationID = new SelectList(db.Compensations, "CompensationID", "CompensationDescription", modelContract.CompensationID);
            ViewBag.EpsID = new SelectList(db.Eps, "EpsID", "EpsDescription", modelContract.EpsID);
            ViewBag.ModelTypeID = new SelectList(db.ModelTypes, "ModelTypeID", "ModelTypeDescription", modelContract.ModelTypeID);
            ViewBag.OrganitationID = new SelectList(db.Organitations, "OrganitationID", "OrganitationName", modelContract.OrganitationID);
            ViewBag.ProfitCenterID = new SelectList(db.ProfitCenters, "ProfitCenterID", "ProfitCenterDescription", modelContract.ProfitCenterID);
            ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "IdentityCard", modelContract.SupervisorID);
            return View(modelContract);
        }

        // GET: ModelContracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelContract modelContract = db.ModelContracts.Find(id);
            if (modelContract == null)
            {
                return HttpNotFound();
            }
            ViewBag.AfpID = new SelectList(db.Afps, "AfpID", "AfpDescription", modelContract.AfpID);
            ViewBag.ArlID = new SelectList(db.Arls, "ArlID", "ArlDescription", modelContract.ArlID);
            ViewBag.CompensationID = new SelectList(db.Compensations, "CompensationID", "CompensationDescription", modelContract.CompensationID);
            ViewBag.EpsID = new SelectList(db.Eps, "EpsID", "EpsDescription", modelContract.EpsID);
            ViewBag.ModelTypeID = new SelectList(db.ModelTypes, "ModelTypeID", "ModelTypeDescription", modelContract.ModelTypeID);
            ViewBag.OrganitationID = new SelectList(db.Organitations, "OrganitationID", "OrganitationName", modelContract.OrganitationID);
            ViewBag.ProfitCenterID = new SelectList(db.ProfitCenters, "ProfitCenterID", "ProfitCenterDescription", modelContract.ProfitCenterID);
            ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "IdentityCard", modelContract.SupervisorID);
            return View(modelContract);
        }

        // POST: ModelContracts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelContractID,Salary,DateAdmision,Percent,OrganitationID,SupervisorID,ModelTypeID,ProfitCenterID,EpsID,AfpID,ArlID,CompensationID")] ModelContract modelContract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelContract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AfpID = new SelectList(db.Afps, "AfpID", "AfpDescription", modelContract.AfpID);
            ViewBag.ArlID = new SelectList(db.Arls, "ArlID", "ArlDescription", modelContract.ArlID);
            ViewBag.CompensationID = new SelectList(db.Compensations, "CompensationID", "CompensationDescription", modelContract.CompensationID);
            ViewBag.EpsID = new SelectList(db.Eps, "EpsID", "EpsDescription", modelContract.EpsID);
            ViewBag.ModelTypeID = new SelectList(db.ModelTypes, "ModelTypeID", "ModelTypeDescription", modelContract.ModelTypeID);
            ViewBag.OrganitationID = new SelectList(db.Organitations, "OrganitationID", "OrganitationName", modelContract.OrganitationID);
            ViewBag.ProfitCenterID = new SelectList(db.ProfitCenters, "ProfitCenterID", "ProfitCenterDescription", modelContract.ProfitCenterID);
            ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "IdentityCard", modelContract.SupervisorID);
            return View(modelContract);
        }

        // GET: ModelContracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelContract modelContract = db.ModelContracts.Find(id);
            if (modelContract == null)
            {
                return HttpNotFound();
            }
            return View(modelContract);
        }

        // POST: ModelContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelContract modelContract = db.ModelContracts.Find(id);
            db.ModelContracts.Remove(modelContract);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
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
