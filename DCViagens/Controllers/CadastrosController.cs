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
    public class CadastrosController : Controller
    {
        private DCViagensContext db = new DCViagensContext();

        // GET: Cadastroes
        public ActionResult Index()
        {
            var cadastroes = db.Cadastroes.Include(c => c.Beneficiario).Include(c => c.Colaborador).Include(c => c.Parceiro).Include(c => c.Vendedor);
            return View(cadastroes.ToList());
        }

        // GET: Cadastroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastroes.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // GET: Cadastroes/Create
        public ActionResult Create()
        {
            ViewBag.BeneficiarioId = new SelectList(db.Beneficiarios, "Id", "EstadoCivil");
            ViewBag.ColaboradorId = new SelectList(db.Colaboradors, "Id", "Senha");
            ViewBag.ParceiroId = new SelectList(db.Parceiroes, "Id", "Nome");
            ViewBag.VendedorId = new SelectList(db.Vendedors, "Id", "Nome");
            return View();
        }

        // POST: Cadastroes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CIF,Senha,DataCadastro,BeneficiarioId,VendedorId,ColaboradorId,ParceiroId")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Cadastroes.Add(cadastro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BeneficiarioId = new SelectList(db.Beneficiarios, "Id", "EstadoCivil", cadastro.BeneficiarioId);
            ViewBag.ColaboradorId = new SelectList(db.Colaboradors, "Id", "Senha", cadastro.ColaboradorId);
            ViewBag.ParceiroId = new SelectList(db.Parceiroes, "Id", "Nome", cadastro.ParceiroId);
            ViewBag.VendedorId = new SelectList(db.Vendedors, "Id", "Nome", cadastro.VendedorId);
            return View(cadastro);
        }

        // GET: Cadastroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastroes.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            ViewBag.BeneficiarioId = new SelectList(db.Beneficiarios, "Id", "EstadoCivil", cadastro.BeneficiarioId);
            ViewBag.ColaboradorId = new SelectList(db.Colaboradors, "Id", "Senha", cadastro.ColaboradorId);
            ViewBag.ParceiroId = new SelectList(db.Parceiroes, "Id", "Nome", cadastro.ParceiroId);
            ViewBag.VendedorId = new SelectList(db.Vendedors, "Id", "Nome", cadastro.VendedorId);
            return View(cadastro);
        }

        // POST: Cadastroes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CIF,Senha,DataCadastro,BeneficiarioId,VendedorId,ColaboradorId,ParceiroId")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BeneficiarioId = new SelectList(db.Beneficiarios, "Id", "EstadoCivil", cadastro.BeneficiarioId);
            ViewBag.ColaboradorId = new SelectList(db.Colaboradors, "Id", "Senha", cadastro.ColaboradorId);
            ViewBag.ParceiroId = new SelectList(db.Parceiroes, "Id", "Nome", cadastro.ParceiroId);
            ViewBag.VendedorId = new SelectList(db.Vendedors, "Id", "Nome", cadastro.VendedorId);
            return View(cadastro);
        }

        // GET: Cadastroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastroes.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cadastro cadastro = db.Cadastroes.Find(id);
            db.Cadastroes.Remove(cadastro);
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
