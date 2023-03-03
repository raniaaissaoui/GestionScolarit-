using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionScolarite;
using GestionScolarite.Models;

namespace GestionScolarite.Controllers
{
    public class AffectationsController : Controller
    {
        private ScolariteDbContext db = new ScolariteDbContext();

        // GET: Affectations
        public ActionResult Index()
        {
            ViewBag.mat = db.Matieres.Where(c => c.Assignation == "Not Assigned").ToList();
            ViewBag.ens = db.Enseignants.ToList();
            return View(db.Affectations.ToList());
        }

        // GET: Affectations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Affectation affectation = db.Affectations.Find(id);
            if (affectation == null)
            {
                return HttpNotFound();
            }
            return View(affectation);
        }

        // GET: Affectations/Create
        public ActionResult Create()
        {
            ViewBag.mat = db.Matieres.Where(c => c.Assignation == "Not Assigned").ToList();
            ViewBag.ens = db.Enseignants.ToList();
            
            return View();
        }

        // POST: Affectations/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MatiereId,EnseignantId")] Affectation affectation)
        {
            if (ModelState.IsValid)
            {
                db.Affectations.Add(affectation);
                db.SaveChanges();
                Matiere m = db.Matieres.Find(affectation.MatiereId);
                m.Assignation = "Assigned";
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mat = db.Matieres.Where(c => c.Assignation == "Not Assigned").ToList();
            ViewBag.ens = db.Enseignants.ToList();
            return View(affectation);
        }

        // GET: Affectations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Affectation affectation = db.Affectations.Find(id);
            if (affectation == null)
            {
                return HttpNotFound();
            }
            return View(affectation);
        }

        // POST: Affectations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MatiereId,EnseignantId")] Affectation affectation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(affectation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(affectation);
        }

        // GET: Affectations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Affectation affectation = db.Affectations.Find(id);
            if (affectation == null)
            {
                return HttpNotFound();
            }
            return View(affectation);
        }

        // POST: Affectations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Affectation affectation = db.Affectations.Find(id);
            db.Affectations.Remove(affectation);
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
