using System;
using System.Linq;
using System.Web.Mvc;
using CapaServicio;
using Tp_Cines_.Models;
using System.Collections.Generic;



namespace Tp_Cines_.Controllers
{
    public class PeliculasController : Controller
    {
        //
        // GET: /Peliculas/
        Entities ctx = new Entities();
       


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
            var Sedess = carteleras.Select(x => x.Sedes).ToList();

            ViewData["Sede"] = new SelectList(Sedess, "IdSede", "Nombre");


            // Para los dias:
            //List<dias> lisDias = new List<dias>();
          // dias Dias = new dias();

            var d =(from Carteleras in ctx.Carteleras
                    join Sedes in ctx.Sedes on Carteleras.IdSede equals Sedes.IdSede
                    where Carteleras.IdPelicula == Peli
                    select new dias
                    {
                        IdPelicula=Peli,
                        Lunes= Carteleras.Lunes,
                        Martes= Carteleras.Martes,
                        Miercoles =Carteleras.Miercoles,
                        Jueves= Carteleras.Jueves,
                        Viernes= Carteleras.Viernes,
                        Sabado=Carteleras.Sabado,
                        Domingo= Carteleras.Domingo,

                    }).ToList();


           // var d1 = d.ToList();
          
            ViewData["dias"] = new SelectList(d,"IdPelicula","Lunes");

            return View(); 
            
            }

       



    }






}







