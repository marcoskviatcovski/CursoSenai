 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private CadeMeuMedicoEntities db = new CadeMeuMedicoEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Consulta()
        {
            ViewBag.Message = "Your consulta page.";
            var medicos = db.Medico.ToList();
            ViewBag.BdMedicos = medicos;
            return View();
        }

        public ActionResult List()
        {
            ViewBag.Message = "Your consulta list.";

            return View();
        }
    }
}