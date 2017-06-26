using CapaServicio;
using System.Linq;
using System.Web.Mvc;


namespace Tp_Cines_.Controllers
{
    [Authorize]
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/

        Entities ctx = new Entities();
        private SedeServicio _sedeServicio = new SedeServicio();

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
        [HttpPost]
        public ActionResult Sedes(Sedes sede)
        {
            if (sede != null)
            {
                if (ModelState.IsValid)
                {
                    _sedeServicio.Create(sede);
                    return View();
                }
            }
            ViewBag.Mensaje = "Valores incorrectos";
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
