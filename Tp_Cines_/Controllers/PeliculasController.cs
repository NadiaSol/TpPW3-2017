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


        public ActionResult Crear()
        {

            ViewBag.IdGenero = new SelectList(ctx.Generos, "IdGenero", "Nombre");
            ViewBag.IdCalificacion = new SelectList(ctx.Calificaciones, "IdCalificacion", "Nombre");
            return View();
        }


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
         [HttpPost]
 
        public ActionResult Dias(CapaServicio.Sedes s)
        {
            int Peli = Convert.ToInt32(TempData["peli_id"]);
            TempData["peli_h"] = Peli;

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

            return View();
        }
  



        //public ActionResult Sedes()
        //{
        //    int Peli = Convert.ToInt32(TempData["Id_peli"]);


        public ActionResult Hora()
        {
            int pe =Convert.ToInt32(TempData["peli_h"]);

            //var h = (from Carteleras in ctx.Carteleras
            //         join Sedes in ctx.Sedes on Carteleras.IdSede
            //         equals Sedes.IdSede
            //         join Versiones in ctx.Versiones on Carteleras.IdVersion
            //         equals Versiones.IdVersion).Where(Carteleras.IdPelicula == pe).select(Carteleras.HoraInicio).ToList();

              var h = ctx.Carteleras.Include("Sedes").Where(x => x.IdPelicula == pe).ToList();
              var hora = h.Select(x => x.HoraInicio).ToList();

              


             ViewBag.horaInicio = hora;

            //ViewData["horaInicio"] = new SelectList(h, "IdPelicula",);

            return View();
        
        }



        // public int Pe { get; set; }

         public ActionResult Seleccionado()
         {

             return View();
         
         }


    }
}

            