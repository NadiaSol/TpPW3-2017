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
        private CarteleraServicio _carteleraServicio = new CarteleraServicio();
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Peliculas()
        {
            var us = from p in ctx.Peliculas orderby p.Nombre ascending select p;
            return View(us.ToList());
        }
        [HttpGet]
        public ActionResult Sedes()
        {
            var sedesActuales = ctx.Sedes.OrderBy(x=>x.Nombre).ToList();
            return View(sedesActuales);
        }
        [HttpPost]
        public ActionResult CrearSede(Sedes sede)
        {
            if (sede != null)
            {
                if (ModelState.IsValid)
                {
                    _sedeServicio.Create(sede);
                    return RedirectToAction("Sedes", "Administracion");

                }
            }
            ViewBag.Mensaje = "Valores incorrectos";
            return View();
        }
        [HttpGet]
        public ActionResult EditarSede(int? IdSede)
        {
            if (IdSede != null)
            {
                if (ctx.Sedes.Any(x => x.IdSede == IdSede))
                {
                    var sedeEditar = ctx.Sedes.Where(x => x.IdSede == IdSede);
                    return View("CrearSede", sedeEditar);
                }
            }
            ModelState.AddModelError("Error", "No se encontró la sede elegida"); //adicionar mensaje de error al model
            return RedirectToAction("Sedes", "Administracion");

        }
        [HttpGet]
        public ActionResult CrearSede()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Carteleras()
        {
            var carteleraActual = ctx.Carteleras.Include("Versiones").Include("Peliculas").Include("Sedes").ToList();
            return View(carteleraActual);
        }
        [HttpGet]
        public ActionResult CrearCartelera()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearCartelera (Carteleras carteleraNueva)
        {
            if(carteleraNueva.HoraInicio<=15&& carteleraNueva.HoraInicio > 23)
                ModelState.AddModelError("Hora Inicio", "No puede ser anterior a las 15hs"); //adicionar mensaje de error al model
            if (ModelState.IsValid)
            {
                if (!_carteleraServicio.Create(carteleraNueva))
                    ModelState.AddModelError("Error", "No se pudo guardar la cartelera"); //adicionar mensaje de error al model

                }
            return RedirectToAction("Carteleras", "Administracion");
        }
        [HttpGet]
        public ActionResult EditarCartelera(int? IdCartelera)
        {
            if (IdCartelera != null)
            {
                if (ctx.Sedes.Any(x => x.IdSede == IdCartelera))
                {
                    var carteleraEditar = ctx.Carteleras.Where(x => x.IdCartelera == IdCartelera);
                    return View("CrearCartelera", carteleraEditar);
                }
            }
            ModelState.AddModelError("Error", "No se encontró la cartelera elegida"); //adicionar mensaje de error al model
            return RedirectToAction("Carteleras", "Administracion");

        }
        public ActionResult Reportes()
        {
            return View();
        }

    }
}
