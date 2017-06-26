using CapaServicio;
using System.Web.Mvc;

namespace Tp_Cines_.Controllers
{
    public class AdministracionController : Controller
    {

        Entities ctx = new Entities();

        private SedeServicio _sedeServicio = new SedeServicio();
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Peliculas()
        {
            return View();
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
