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
    public class CidadesController : Controller
    {
        private CadeMeuMedicoEntities db = new CadeMeuMedicoEntities();

        // GET: Cidades
        public ActionResult Index()
        {
            var cidade = db.Cidade.Include(c => c.Estado);
            return View(cidade.ToList());
        }
        [HttpPost]
        public ActionResult Adicionar(Cidade cidade)
        {

            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            cidade.id_estado = 2;

            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", cidade.id_cidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", cidade.id_estado);


            return View(cidade);

        }

        public ActionResult Editar(long id)
        {
            Cidade cidade = db.Cidade.Find(id);
            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", cidade.id_cidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", cidade.id_estado);
            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(Cidade cidade)
        {

            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            cidade.id_estado = 2;

            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", cidade.id_cidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", cidade.id_estado);


            return View(cidade);

        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Cidade cidade = db.Cidade.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Cidade cidade = db.Cidade.Find(id);
            db.Cidade.Remove(cidade);
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

        // GET: Cidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            ViewBag.id_estado = new SelectList(db.Estado, "id_estado", "estado1");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cidade,id_estado,cidade1")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estado = new SelectList(db.Estado, "id_estado", "estado1", cidade.id_estado);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estado = new SelectList(db.Estado, "id_estado", "estado1", cidade.id_estado);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cidade,id_estado,cidade1")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_estado = new SelectList(db.Estado, "id_estado", "estado1", cidade.id_estado);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            db.Cidade.Remove(cidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     
    }
}
