using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DCViagens.Models;

namespace DCViagens.Controllers
{
    public class ParceirosController : Controller
    {
        private DCViagensContext db = new DCViagensContext();

        // GET: Parceiroes
        public ActionResult Index()
        {
            return View(db.Parceiroes.ToList());
        }

        // GET: Parceiroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parceiro parceiro = db.Parceiroes.Find(id);
            if (parceiro == null)
            {
                return HttpNotFound();
            }
            return View(parceiro);
        }

        // GET: Parceiroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parceiroes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Fone")] Parceiro parceiro)
        {
            if (ModelState.IsValid)
            {
                db.Parceiroes.Add(parceiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parceiro);
        }

        // GET: Parceiroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parceiro parceiro = db.Parceiroes.Find(id);
            if (parceiro == null)
            {
                return HttpNotFound();
            }
            return View(parceiro);
        }

        // POST: Parceiroes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Fone")] Parceiro parceiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parceiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parceiro);
        }

        // GET: Parceiroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parceiro parceiro = db.Parceiroes.Find(id);
            if (parceiro == null)
            {
                return HttpNotFound();
            }
            return View(parceiro);
        }

        // POST: Parceiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parceiro parceiro = db.Parceiroes.Find(id);
            db.Parceiroes.Remove(parceiro);
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
