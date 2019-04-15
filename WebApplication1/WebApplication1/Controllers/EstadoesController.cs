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
    public class EstadoesController : Controller
    {
        private CadeMeuMedicoEntities db = new CadeMeuMedicoEntities();

        // GET: Estadoes
        public ActionResult Index()
        {
            var estado = db.Estado.Include(e => e.Pais);
            return View(estado.ToList());
        }

        [HttpPost]
        public ActionResult Editar(Estado estado)
        {

            if (ModelState.IsValid)
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            estado.id_estado = 2;

            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", estado.id_estado);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", estado.id_estado);


            return View(estado);

        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Estado estado = db.Estado.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Estado estado = db.Estado.Find(id);
            db.Estado.Remove(estado);
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


        // GET: Estadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // GET: Estadoes/Create
        public ActionResult Create()
        {
            ViewBag.id_pais = new SelectList(db.Pais, "id_pais", "pais1");
            return View();
        }

        // POST: Estadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado,id_pais,estado1,sigla")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Estado.Add(estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pais = new SelectList(db.Pais, "id_pais", "pais1", estado.id_pais);
            return View(estado);
        }

        // GET: Estadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pais = new SelectList(db.Pais, "id_pais", "pais1", estado.id_pais);
            return View(estado);
        }

        // POST: Estadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado,id_pais,estado1,sigla")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pais = new SelectList(db.Pais, "id_pais", "pais1", estado.id_pais);
            return View(estado);
        }

        // GET: Estadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado estado = db.Estado.Find(id);
            db.Estado.Remove(estado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
