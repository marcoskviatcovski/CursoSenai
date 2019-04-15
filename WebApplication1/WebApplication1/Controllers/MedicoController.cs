using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Script.Serialization;

namespace WebApplication7.Controllers
{
    public class MedicoController : Controller
    {
        private CadeMeuMedicoEntities db = new CadeMeuMedicoEntities();


        // GET: Medicos
        public ActionResult Index()
        {
            var medico = db.Medico.Include(m => m.Cidade).Include(m => m.Especialidade);
            return View(medico.ToList());
        }

        [HttpPost]
        public ActionResult Adicionar(Medico medico)
        {

            if (ModelState.IsValid)
            {
                db.Medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            medico.id_especialidade = 2;

            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", medico.id_cidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", medico.id_especialidade);


            return View(medico);

        }

        public ActionResult Editar (long id)
        {
            Medico medico = db.Medico.Find(id);
            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", medico.id_cidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", medico.id_especialidade);
            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDcidade = new SelectList(db.Cidade, "IDcidade", "Cidade", medico.id_cidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidade, "IDespecialidade", "Especialidade", medico.id_especialidade);


            return View(medico);
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Medico medico = db.Medico.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Medico medico = db.Medico.Find(id);
            db.Medico.Remove(medico);
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

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.id_cidade = new SelectList(db.Cidade, "id_cidade", "cidade1");
            ViewBag.id_especialidade = new SelectList(db.Especialidade, "id_especialidade", "especialidade1");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_medico,id_especialidade,crm,nome,endereco,bairro,id_cidade,email,atende_por_convenio,tem_clinica,web_site_blog")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cidade = new SelectList(db.Cidade, "id_cidade", "cidade1", medico.id_cidade);
            ViewBag.id_especialidade = new SelectList(db.Especialidade, "id_especialidade", "especialidade1", medico.id_especialidade);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cidade = new SelectList(db.Cidade, "id_cidade", "cidade1", medico.id_cidade);
            ViewBag.id_especialidade = new SelectList(db.Especialidade, "id_especialidade", "especialidade1", medico.id_especialidade);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_medico,id_especialidade,crm,nome,endereco,bairro,id_cidade,email,atende_por_convenio,tem_clinica,web_site_blog")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cidade = new SelectList(db.Cidade, "id_cidade", "cidade1", medico.id_cidade);
            ViewBag.id_especialidade = new SelectList(db.Especialidade, "id_especialidade", "especialidade1", medico.id_especialidade);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medico.Find(id);
            db.Medico.Remove(medico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

    }
}
