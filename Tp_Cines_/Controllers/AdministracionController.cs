using CapaServicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Tp_Cines_.Models;
using Tp_Cines_.Models.Extensions;
using Tp_Cines_.Utilities;


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
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();
        private ReservaServicio _reservaServicio = new ReservaServicio();

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
            var sedesActuales = ctx.Sedes.OrderBy(x => x.Nombre).ToList();
            return View(sedesActuales);
        }
        [HttpPost]
        public ActionResult CrearSede(SedeViewModel sedeNueva)
        {
            ValidaSede(sedeNueva);
            if (ModelState.IsValid)
            {
                SaveOrUpdateSede(sedeNueva.Map());
                return RedirectToAction("Sedes", "Administracion");
            }

            return View("CrearSede");
        }

        [HttpPost]
        public ActionResult EditarSede(SedeViewModel sede)
        {
            ValidaSede(sede);
            if (ModelState.IsValid)
            {
                var sedeEditar = ctx.Sedes.Find(sede.IdSede);
                SaveOrUpdateSede(sede.Map(sedeEditar));
                return RedirectToAction("Sedes", "Administracion");
            }
            return View("EditarSede");
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
            var sede = ctx.Sedes.Find(id);
            if (sede == null)
                return View("NotFound");
            var sedeViewModel = sede.Map();
            return View("EditarSede", sedeViewModel);
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
                SaveOrUpdateCartelera(carteleraNueva.Map());

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

        private void ValidaSede(SedeViewModel model)
        {
            if (_sedeServicio.Exist(model))
                ModelState.AddModelError("SedeRepetida", "Ya existe una Sede con ese nombre");
        }
        private void SaveOrUpdateCartelera(Carteleras model)
        {
            _carteleraServicio.CreateOrUpdate(model);
        }
        private void SaveOrUpdateSede(Sedes model)
        {
            _sedeServicio.CreateOrUpdate(model);
        }
        [HttpGet]
        public ActionResult EditarCartelera(int id)
        {
            var cartelera = ctx.Carteleras.Find(id);
            if (cartelera == null)
                return View("NotFound");
            var carteleraViewModel = cartelera.Map();
            Initialize(carteleraViewModel);
            return View("EditCartelera", carteleraViewModel);
        }

        [HttpPost]
        public ActionResult EditarCartelera(CarteleraViewModel carteleraNueva)
        {

            Validate(carteleraNueva);

            if (ModelState.IsValid)
            {
                var cartelera = ctx.Carteleras.Find(carteleraNueva.IdCartelera);
                SaveOrUpdateCartelera(carteleraNueva.Map(cartelera));
                return RedirectToAction("Carteleras", "Administracion");
            }

            Initialize(carteleraNueva);
            return View("EditCartelera", carteleraNueva);
        }
        [HttpGet]
        public ActionResult Reportes()
        {
            var reporte = new ReporteViewModel();
            reporte.ListadoReservas = new List<Reservas>();
            reporte.FechaInicio = DateTime.Now;
            reporte.FechaFin = DateTime.Now;
            return View("Reportes", reporte);
        }

        //[HttpPost]
        //public ActionResult Reportes(DateTime fechaInicio, DateTime fechaFin)
        //{
        //    if (fechaInicio != null && fechaFin != null)
        //    {
        //        var dias = fechaFin - fechaInicio;
        //        //List<ReservaViewModel> listadoReservas = new List<ReservaViewModel>();
        //        if (dias.Days <= 30)
        //        {
        //            var reservas = (_reservaServicio.FiltrarFechas(fechaInicio, fechaFin));
        //            //foreach (var reserva in reservas)
        //            //{

        //            //    listadoReservas.Add(reserva.Map());
        //            //}
        //            //InitializeReserva(listadoReservas);

        //            return View("Reportes", reservas);
        //        }
        //        ModelState.AddModelError("CantidadDias", "El reporte no puede ser mayor a 30 días");

        //    }
        //    ModelState.AddModelError("Fechas", "Debe seleccionar Fechas de Inicio y Fin");

        //    return View();
        //}

        [HttpPost]
        public ActionResult Reportes(ReporteViewModel reporte)
        {
            if (reporte.FechaInicio == null && reporte.FechaFin == null)
            {
                ModelState.AddModelError("Fechas", "Debe seleccionar Fechas de Inicio y Fin");
            }
            var dias = reporte.FechaFin - reporte.FechaInicio;
            if (dias.Days > 30)
            {
                ModelState.AddModelError("CantidadDias", "El reporte no puede ser mayor a 30 días");
            }
            if (ModelState.IsValid)
            {
                reporte.ListadoReservas = (_reservaServicio.FiltrarFechas(reporte.FechaInicio, reporte.FechaFin));
            }
            if (reporte.ListadoReservas==null || reporte.ListadoReservas.Count ==0)
                ModelState.AddModelError("SinReservas", "No se encontraron Reservas en las fechas elegidas");
            return View("Reportes", reporte);
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

                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    //TODO: Agregar validacion para confirmar que el archivo es una imagen
                    if (!string.IsNullOrEmpty(peliculas.Imagen))
                    {
                        //recordar eliminar la foto anterior si tenia
                        if (!string.IsNullOrEmpty(peliculas.Imagen))
                        {
                            ImagenesUtility.Borrar(peliculas.Imagen);
                        }

                        //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                        string nombreSignificativo = peliculas.NombreSignificativoImagen;
                        //Guardar Imagen
                        string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                        peliculas.Imagen = pathRelativoImagen;
                    }
                }


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

        //public List<int> Horarios(int funcion, int idPelicula)
        //{
        //    var duracion = _peliculaServicio.GetById(idPelicula).Duracion;

        //    var horarios = new List<int> { funcion };
        //    var i = 1;
        //    for (i = 1; i <= 6; i++)
        //    {
        //        funcion = duracion + 30;
        //        horarios.Add(funcion);
        //    }

        //    return horarios;
        //}
        private void Initialize(CarteleraViewModel model)
        {
            model.Peliculas = ctx.Peliculas.ToList();
            model.Sedes = ctx.Sedes.ToList();
            model.Versiones = ctx.Versiones.ToList();
        }
        //private void InitializeReserva(List<ReservaViewModel> listado)
        //{
        //    foreach (var reserva in listado)
        //    {
        //        reserva.Peliculas = ctx.Peliculas.ToList();
        //        reserva.Sedes = ctx.Sedes.ToList();
        //        reserva.Versiones = ctx.Versiones.ToList();
        //    }

        //}
    }
}
