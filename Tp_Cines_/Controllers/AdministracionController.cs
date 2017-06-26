using CapaServicio;
using System.Linq;
using System.Web.Mvc;


namespace Tp_Cines_.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/

        Entities ctx = new Entities();

        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Peliculas()
        {
            var us = from p in ctx.Peliculas orderby p.Nombre ascending select p;
            return View(us);
        }
        public ActionResult Sedes()
        {
            return View();
        }
        public ActionResult Carteleras()
        {
            return View();
        }
        public ActionResult Reportes()
        {
            return View();
        }

    }
}
