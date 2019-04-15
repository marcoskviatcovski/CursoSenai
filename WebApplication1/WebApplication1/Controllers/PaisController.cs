using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PaisController : Controller
    {
        private CadeMeuMedicoEntities db = new CadeMeuMedicoEntities();

        // GET: Pais
        public ActionResult Index()
        {
            return View(db.Pais.ToList());
        }
        [HttpPost]
        public ActionResult Adicionar(Pais pais)
        {

            if (ModelState.IsValid)
            {
                db.Pais.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            pais.id_pais = 2;

            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", pais.id_pais);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", pais.id_pais);


            return View(pais);

        }

        public ActionResult Editar(long id)
        {
            Pais pais = db.Pais.Find(id);
            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", pais.id_pais);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", pais.id_pais);
            return View(pais);
        }

        [HttpPost]
        public ActionResult Editar(Pais pais)
        {

            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            pais.id_pais = 2;

            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", pais.id_pais);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", pais.id_pais);


            return View(pais);

        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Pais pais = db.Pais.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Pais pais = db.Pais.Find(id);
            db.Pais.Remove(pais);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Pais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Pais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pais,pais1,sigla")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Pais.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Pais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pais,pais1,sigla")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Pais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pais pais = db.Pais.Find(id);
            db.Pais.Remove(pais);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
