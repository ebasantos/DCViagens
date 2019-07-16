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
    public class BeneficiariosController : Controller
    {
        private DCViagensContext db = new DCViagensContext();

        // GET: Beneficiarios
        public ActionResult Index()
        {
            return View(db.Beneficiarios.ToList());
        }

        // GET: Beneficiarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficiario beneficiario = db.Beneficiarios.Find(id);
            if (beneficiario == null)
            {
                return HttpNotFound();
            }
            return View(beneficiario);
        }

        // GET: Beneficiarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beneficiarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataNascimento,EstadoCivil,NomeMae,CPF,Endereco,Email,ColaboradorId,Nome,Fone")] Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                db.Beneficiarios.Add(beneficiario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beneficiario);
        }

        // GET: Beneficiarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficiario beneficiario = db.Beneficiarios.Find(id);
            if (beneficiario == null)
            {
                return HttpNotFound();
            }
            return View(beneficiario);
        }

        // POST: Beneficiarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataNascimento,EstadoCivil,NomeMae,CPF,Endereco,Email,ColaboradorId,Nome,Fone")] Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beneficiario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beneficiario);
        }

        // GET: Beneficiarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficiario beneficiario = db.Beneficiarios.Find(id);
            if (beneficiario == null)
            {
                return HttpNotFound();
            }
            return View(beneficiario);
        }

        // POST: Beneficiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beneficiario beneficiario = db.Beneficiarios.Find(id);
            db.Beneficiarios.Remove(beneficiario);
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
