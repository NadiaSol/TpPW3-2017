using System;
using System.Linq;
using System.Web.Mvc;
using CapaServicio;
using System.Collections.Generic;



namespace Tp_Cines_.Controllers
{
    public class PeliculasController : Controller
    {
        //
        // GET: /Peliculas/
        private Entities ctx = new Entities();

        public ActionResult Versiones(int id)
        {
            var cartelera = ctx.Carteleras.Include("Versiones").Where(x => x.IdPelicula == id).ToList();
            var versiones = cartelera.Select(x => x.Versiones).ToList();


            ViewBag.Versiones = versiones;

            TempData["Id_peli"] = id;

            ViewData["Version"] = new SelectList(versiones, "IdVersion", "Nombre");



            return View();

        }

        [Authorize]
        public ActionResult Crear()
        {

            ViewBag.IdGenero = new SelectList(ctx.Generos, "IdGenero", "Nombre");
            ViewBag.IdCalificacion = new SelectList(ctx.Calificaciones, "IdCalificacion", "Nombre");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Crear(Peliculas peliculas)
        {
            if (ModelState.IsValid)
            {
                peliculas.FechaCarga = DateTime.Now;
                ctx.Peliculas.Add(peliculas);
                ctx.SaveChanges();
                return RedirectToAction("Peliculas", "Administracion");
            }
            ViewBag.IdGenero = new SelectList(ctx.Generos, "IdGenero", "Nombre", peliculas.IdGenero);
            ViewBag.IdCalificacion = new SelectList(ctx.Calificaciones, "IdCalificacion", "Nombre", peliculas.IdCalificacion);
            return View(peliculas);
        }


        [HttpPost]
        public ActionResult sedes(CapaServicio.Versiones v)
        {
            int Peli = Convert.ToInt32(TempData["Id_peli"]);
            TempData["peli_id"] = Peli;


            var carteleras = ctx.Carteleras.Include("Sedes").Where(x => x.IdPelicula == Peli).Where(x => x.IdVersion == v.IdVersion).ToList();
            var Sedess = carteleras.Select(x => x.Sedes).ToList();

            //ViewData["Sede"] = new SelectList(Sedess, "IdSede", "Nombre");
            ViewBag.Sede1 = Sedess;
            //ViewBag.Sede1 = new SelectList(Sedess,"IdSede","Nombre");


            TempData["id_version"] = v.IdVersion;


            return View();


        }

        public ActionResult Dias() { 
        
            return View();
        }

       [HttpPost]
        public ActionResult Dias(CapaServicio.Sedes s)
        {
            int Peli = Convert.ToInt32(TempData["peli_id"]);
            TempData["peli_h"] = Peli;
            int version1 = Convert.ToInt32(TempData["id_version"]);
            TempData["version_"] = version1;
            TempData["id_sede"] = s.IdSede;

            var d = (from Carteleras in ctx.Carteleras
                     join Sedes in ctx.Sedes on Carteleras.IdSede equals Sedes.IdSede
                     where Sedes.IdSede == s.IdSede && Carteleras.IdPelicula == Peli
                     select new
                     {
                         IdPelicula = Peli,
                         Lunes = Carteleras.Lunes,
                         Martes = Carteleras.Martes,
                         Miercoles = Carteleras.Miercoles,
                         Jueves = Carteleras.Jueves,
                         Viernes = Carteleras.Viernes,
                         Sabado = Carteleras.Sabado,
                         Domingo = Carteleras.Domingo,

                     }).ToList();

            List<SelectListItem> dias = new List<SelectListItem>();
            foreach (var item in d)
            {
                if (item.Lunes)
                {
                    dias.Add(new SelectListItem() { Text = "Lunes", Value = "1" });
                }
                if (item.Martes)
                {
                    dias.Add(new SelectListItem() { Text = "Martes", Value = "2" });
                }
                if (item.Miercoles)
                {
                    dias.Add(new SelectListItem() { Text = "Miercoles", Value = "3" });
                }
                if (item.Jueves)
                {
                    dias.Add(new SelectListItem() { Text = "Jueves", Value = "4" });
                }
                if (item.Viernes)
                {
                    dias.Add(new SelectListItem() { Text = "Viernes", Value = "5" });
                }
                if (item.Sabado)
                {
                    dias.Add(new SelectListItem() { Text = "Sabado", Value = "6" });

                }
                if (item.Domingo)
                {
                    dias.Add(new SelectListItem() { Text = "Domingo", Value = "7" });

                }

            }



            ViewBag.lis = dias;



            //buscar horarios

            //var h = (from Carteleras in ctx.Carteleras
            //        join Sedes in ctx.Sedes on Carteleras.IdSede
            //        equals Sedes.IdSede
            //        join Versiones in ctx.Versiones on Carteleras.IdVersion
            //        equals Versiones.IdVersion
            //        where Carteleras.IdPelicula == 1
            //        select Carteleras.HoraInicio).ToList();


            //ViewData["horaInicio"] = new SelectList(h, "IdPelicula");

            return View(dias);
        }




        //public ActionResult Sedes()
        //{
        //    int Peli = Convert.ToInt32(TempData["Id_peli"]);

            [HttpPost]
        public ActionResult Hora(FormCollection formu)
        {
            int pe = Convert.ToInt32(TempData["peli_h"]);
            int sede = Convert.ToInt32(TempData["id_sede"]);
            int version = Convert.ToInt32(TempData["version_"]);

            string fecha = formu["dia"];
            TempData["fecha"] = fecha;
            TempData["sedee"] = sede;
            TempData["id_Version"] = version;
            TempData["peli_id"] = pe;
            var h = ctx.Carteleras.Include("Sedes").Where(x => x.IdPelicula == pe).ToList();
            var hora = h.Select(x => x.HoraInicio).ToList();




            ViewBag.horaInicio = hora;

            //ViewData["horaInicio"] = new SelectList(h, "IdPelicula",);

            return View();

        }



        // public int Pe { get; set; }

        [HttpPost]

        public ActionResult Seleccionado(CapaServicio.Carteleras h)
        {


            ViewBag.sede = ctx.Sedes.Find(TempData["sedee"]).Nombre;
            ViewBag.version = ctx.Versiones.Find(TempData["id_Version"]).Nombre;
            ViewBag.hora = h.HoraInicio;
            ViewBag.pelicula = ctx.Peliculas.Find(TempData["peli_id"]).Nombre;
            ViewBag.fechaInicio= TempData["fecha"];


            return View();

        }


    }
}

            