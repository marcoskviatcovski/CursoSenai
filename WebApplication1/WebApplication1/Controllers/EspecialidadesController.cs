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
    public class EspecialidadesController : Controller
    {
        private CadeMeuMedicoEntities db = new CadeMeuMedicoEntities();

        // GET: Especialidades
        public ActionResult Index()
        {
            return View(db.Especialidade.ToList());
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidade especialidade)
        {

            if (ModelState.IsValid)
            {
                db.Especialidade.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            especialidade.id_especialidade = 2;

            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", especialidade.id_especialidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", especialidade.id_especialidade);


            return View(especialidade);

        }

        public ActionResult Editar(long id)
        {
            Especialidade especialidade = db.Especialidade.Find(id);
            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", especialidade.id_especialidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", especialidade.id_especialidade);
            return View(especialidade);
        }

        [HttpPost]
        public ActionResult Editar(Especialidade especialidade)
        {

            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
               
                return RedirectToAction("Index");
            }

            especialidade.id_especialidade = 2;

            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", especialidade.id_especialidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", especialidade.id_especialidade);


            return View(especialidade);

        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Especialidade especialidade = db.Especialidade.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(especialidade);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Especialidade especialidade = db.Especialidade.Find(id);
            db.Especialidade.Remove(especialidade);
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

        // GET: Especialidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidade especialidade = db.Especialidade.Find(id);
            if (especialidade == null)
            {
                return HttpNotFound();
            }
            return View(especialidade);
        }

        // GET: Especialidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_especialidade,especialidade1")] Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Especialidade.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        // GET: Especialidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidade especialidade = db.Especialidade.Find(id);
            if (especialidade == null)
            {
                return HttpNotFound();
            }
            return View(especialidade);
        }

        // POST: Especialidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_especialidade,especialidade1")] Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidade);
        }

        // GET: Especialidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidade especialidade = db.Especialidade.Find(id);
            if (especialidade == null)
            {
                return HttpNotFound();
            }
            return View(especialidade);
        }

        // POST: Especialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especialidade especialidade = db.Especialidade.Find(id);
            db.Especialidade.Remove(especialidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
