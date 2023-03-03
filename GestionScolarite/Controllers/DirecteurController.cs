using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionScolarite.Models;

namespace GestionScolarite.Controllers
{
    public class DirecteurController : Controller
    {
        private ScolariteDbContext db = new ScolariteDbContext();

        // GET: Directeur
        public ActionResult Index()
        {
            return View(db.Etudiants);
        }

        // GET: Directeur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

         // GET: Directeur/Create Enseignant
        public ActionResult CreateEnseignant()
        {
            //ViewBag.mat = db.Matieres.Where(c => c.Assignation != "Assigned").Distinct().ToList();
             return View();
        }

        // POST: Directeur/Create
        [HttpPost]
       public ActionResult CreateEnseignant(Enseignant enseignant)
        {           
            
            if (ModelState.IsValid)
            {
                db.Enseignants.Add(enseignant);
                db.SaveChanges();
              //  Matiere m = db.Matieres.Find(enseignant.matid);
                //m.Assignation = "Assigned";
                //db.Entry(m).State = EntityState.Modified;
                //db.SaveChanges();
                //ViewBag.mat = db.Matieres.Where(c => c.Assignation != "Assigned").Distinct().ToList();

                return RedirectToAction(nameof(Index));
            }
          //  ViewBag.mat = db.Matieres.Where(c=>c.Assignation != "Assigned").Distinct().ToList();
            return View(enseignant);
        }
        public ActionResult IndexEnseignant()
        {
            return View(db.Enseignants);
        }
        // GET: Directeur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Directeur/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,AccoutId,Name,Section")] Etudiant etudiant)
        {
            Etudiant e = db.Etudiants.Find(etudiant.Id);
            e.Section = etudiant.Section;
            if (ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etudiant);
        }

        // GET: Directeur/Delete/5
        // GET: Administratif/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Administratif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            Etudiant e = db.Etudiants.FirstOrDefault(c => c.Account == account.Id);
            db.Etudiants.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
