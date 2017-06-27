using CapaServicio;
using System;
using System.Data;
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
                    _sedeServicio.Crear(sede);
                    return RedirectToAction("Sedes", "Administracion");
                }
            }
            ViewBag.Mensaje = "Valores incorrectos";
            return View();
        }

        [HttpGet]
        public ActionResult CrearSede(int? id)
        {
            if (id != null) {
                if (ctx.Sedes.Any(x => x.IdSede == id))
                {
                    var sedeEditar = ctx.Sedes.FirstOrDefault(x => x.IdSede == id);
                    return View(sedeEditar);
                }
               ModelState.AddModelError("Error", "No se encontró la sede elegida"); //adicionar mensaje de error al model

            }
            return View();
        }

        [HttpGet]
        public ActionResult Carteleras()
        {
            var carteleraActual = ctx.Carteleras.Include("Versiones").Include("Peliculas").Include("Sedes").ToList();
            return View(carteleraActual);
        }
        [HttpGet]
        public ActionResult CrearCartelera(int? id)
        {
            if (id != null)
            {
                if (ctx.Carteleras.Any(x => x.IdCartelera == id))
                {
                    var carteleraEditar = ctx.Carteleras.FirstOrDefault(x => x.IdCartelera == id);
                    return View("CrearCartelera", carteleraEditar);
                }
                ModelState.AddModelError("Error", "No se encontró la cartelera elegida");
            }
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
        //[HttpGet]
        //public ActionResult EditarCartelera(int IdCartelera)
        //{

        //        if (ctx.Sedes.Any(x => x.IdSede == IdCartelera))
        //        {
        //            var carteleraEditar = ctx.Carteleras.FirstOrDefault(x => x.IdCartelera == IdCartelera);
        //            return View("CrearCartelera", carteleraEditar);
        //        }
        //    ModelState.AddModelError("Error", "No se encontró la cartelera elegida"); //adicionar mensaje de error al model
        //    return RedirectToAction("Carteleras", "Administracion");

        //}
        public ActionResult Reportes()
        {
            return View();
        }

        public ActionResult EditarPelicula(int id = 0)
        {

            Peliculas peliculas = ctx.Peliculas.Single(p => p.IdPelicula == id);

            if (peliculas == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdGenero = new SelectList(ctx.Generos, "IdGenero", "Nombre", peliculas.IdGenero);
            ViewBag.IdCalificacion = new SelectList(ctx.Calificaciones, "IdCalificacion", "Nombre", peliculas.IdCalificacion);
            return View(peliculas);
        }

        [HttpPost]
        public ActionResult EditarPelicula(Peliculas peliculas)
        {

            if (ModelState.IsValid)
            {

                ctx.Peliculas.Attach(peliculas);
                peliculas.FechaCarga = DateTime.Now;
                ctx.Entry(peliculas).State = EntityState.Modified;
                ctx.SaveChanges();

                return RedirectToAction("Peliculas", "Administracion");
            }

            ViewBag.IdGenero = new SelectList(ctx.Generos, "IdGenero", "Nombre", peliculas.IdGenero);
            ViewBag.IdCalificacion = new SelectList(ctx.Calificaciones, "IdCalificacion", "Nombre", peliculas.IdCalificacion);
            return View(peliculas);
        }
    }
}
