using System;
using System.Linq;
using System.Web.Mvc;
using CapaSevicio;


namespace Tp_Cines_.Controllers
{
    public class PeliculasController : Controller
    {
        //
        // GET: /Peliculas/
        Entities1 ctx = new Entities1();
        // public static List<Version> versiones= new List<Version>();


        //ViewBag.IdPeli = id;
        //var query = (from Pelicula in ctx.Peliculas
        //             join
        //                 Carteleras in ctx.Carteleras on
        //                 Pelicula.IdPelicula equals Carteleras.IdPelicula
        //             where
        //                 Pelicula.IdPelicula == id
        //             select Carteleras).ToList();
        //public ActionResult Reservas(int id)
        //{
        //    var lista = ctx.Carteleras.Include("Sedes")
        //                        .Include("Peliculas")
        //                        .Include("Versiones").ToList();
        //    //ViewBag.peliculas = ctx.Peliculas;



        //    return ViewBag(lista);


        //}

        public ActionResult Versiones(int id)
        {


            var cartelera = ctx.Carteleras.Include("Versiones").Where(x => x.IdPelicula == id).ToList();
            var versiones = cartelera.Select(x => x.Versiones).ToList();

            ViewBag.Versiones = versiones;

            TempData["Id_peli"] = id;
            ViewData["Version"] = new SelectList(versiones, "IdVersion", "Nombre");


            //Lo que sigue es para trer sedes

            int Peli = Convert.ToInt32(TempData["Id_peli"]);

            var carteleras = ctx.Carteleras.Include("Sedes").Where(x => x.IdPelicula == Peli).ToList();
            var Sedes = carteleras.Select(x => x.Sedes).ToList();

            ViewData["Sede"] = new SelectList(Sedes, "IdSede", "Nombre");


            return View();
        }

        //public ActionResult Sedes()
        //{
        //    int Peli = Convert.ToInt32(TempData["Id_peli"]);

        //    var cartelera = ctx.Carteleras.Include("Sedes").Where(x => x.IdPelicula == Peli).ToList();
        //    var Sedes = cartelera.Select(x => x.Sedes).ToList();
        //    ViewData["Sede"] = new SelectList(Sedes, "IdSede", "Nombre");

        //   // ViewData["Sedes"] = new SelectList(Sedes, "Id", "Name");

        //    //ViewBag.Sedes = Sedes;
        //    //TempData["Sedes"] = Sedes;

        //    return View("Versiones");

        //}



    }
}
