using CapaServicio;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Tp_Cines_.Models;
using Tp_Cines_.Models.Extensions;


namespace Tp_Cines_.Controllers
{
    [Authorize]
    [HandleError]
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/

        Entities ctx = new Entities();
        private SedeServicio _sedeServicio = new SedeServicio();
        private CarteleraServicio _carteleraServicio = new CarteleraServicio();
        public ActionResult Inicio()
        {

            //int dato = Convert.ToInt32 ( TempData["Sedes"]);
            //ViewBag.dato = dato;

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
            var sedesActuales = ctx.Sedes.OrderBy(x => x.Nombre).ToList();
            return View(sedesActuales);
        }
        [HttpPost]
        public ActionResult CrearSede(Sedes sede)
        {
            if (sede != null)
            {
                if (ModelState.IsValid)
                {
                    _sedeServicio.CreateOrUpdate(sede);
                    return RedirectToAction("Sedes", "Administracion");
                }
            }
            ViewBag.Mensaje = "Valores incorrectos";
            return View();
        }
        [HttpGet]
        public ActionResult CrearSede()
        {
            var model = new SedeViewModel();
            return View("CrearSede", model);
        }
        
        [HttpGet]
        public ActionResult EditarSede(int id)
        {
                if (ctx.Sedes.Any(x => x.IdSede == id))
                {
                    var sedeEditar = ctx.Sedes.FirstOrDefault(x => x.IdSede == id);
                    return View("EditarSede",sedeEditar);
                }
                ModelState.AddModelError("Error", "No se encontró la sede elegida"); //adicionar mensaje de error al model

            return View("EditarSede");
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
            var model = new CarteleraViewModel();
            Initialize(model);
            return View("CrearCartelera", model);
        }

        [HttpPost]
        public ActionResult CrearCartelera(CarteleraViewModel carteleraNueva)
        {
            
            Validate(carteleraNueva);

            if (ModelState.IsValid)
            {
                SaveOrUpdate(carteleraNueva);

                return RedirectToAction("Carteleras", "Administracion");
            }

            Initialize(carteleraNueva);
            return View("CrearCartelera", carteleraNueva);
        }

        private void Validate(CarteleraViewModel model)
        {
            if (_carteleraServicio.Exist(model))
                ModelState.AddModelError("Error", "Ya existe esta pelicula en esta sede y versión"); //adicionar mensaje de error al model

            if (_carteleraServicio.SalaOcupada(model))
                ModelState.AddModelError("Error", "Esta sala esta ocupada en ese horario"); //adicionar mensaje de error al model
        }

        private void SaveOrUpdate(CarteleraViewModel model)
        {
            _carteleraServicio.CreateOrUpdate(model);
        }
        [HttpGet]
        public ActionResult EditarCartelera(int? id)
        {
            var cartelera = ctx.Carteleras.Find(id);

            if (cartelera == null)
                return View("NotFound");

            var carteleraViewModel = cartelera.Map();

            Initialize(carteleraViewModel);

            return View("EditCartelera",carteleraViewModel);
        }

        [HttpPost]
        public ActionResult EditarCartelera(CarteleraViewModel carteleraNueva)
        {

            Validate(carteleraNueva);

            if (ModelState.IsValid)
            {
                SaveOrUpdate(carteleraNueva);

                return RedirectToAction("Carteleras", "Administracion");
            }

            Initialize(carteleraNueva);
            return View("EditCartelera", carteleraNueva);
        }

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

        private void Initialize(CarteleraViewModel model)
        {
            model.Peliculas = ctx.Peliculas.ToList();
            model.Sedes = ctx.Sedes.ToList();
            model.Versiones = ctx.Versiones.ToList();
        }
    }
}
