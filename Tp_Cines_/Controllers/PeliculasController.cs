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
        [HttpGet]
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

            // DateTime date = DateTime.ParseExact(fecha, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            // dd/MM/YYYY
            //   DateTime dia = DateTime.Parse(fecha, System.Globalization.CultureInfo.GetCultureInfo("es"));
            var h = ctx.Carteleras.Include("Sedes").Where(x => x.IdPelicula == pe).ToList();
            var hora = h.Select(x => x.HoraInicio).ToList();

            ViewBag.horaInicio = hora;
            return View();

        }



        // public int Pe { get; set; }

        //[HttpPost]

        //public ActionResult Seleccionado(CapaServicio.Carteleras h)
        //{
        //    ViewBag.sede = ctx.Sedes.Find(TempData["sedee"]).Nombre;
        //    ViewBag.version = ctx.Versiones.Find(TempData["id_Version"]).Nombre;
        //    ViewBag.hora = h.HoraInicio;
        //    ViewBag.pelicula = ctx.Peliculas.Find(TempData["peli_id"]).Nombre;
        //    ViewBag.fechaInicio= TempData["fecha"];

        //    return View();

        //}


        public ActionResult Reserva()
            {
                
                    ModelState.AddModelError("Error", "Debe seleccionar una Pelicula");
                   
                


                //ViewBag.sede = ctx.Sedes.Find(TempData["sedee"]).Nombre;
                //ViewBag.version = ctx.Versiones.Find(TempData["id_Version"]).Nombre;
                //ViewBag.hora = h.HoraInicio;
                //ViewBag.pelicula = ctx.Peliculas.Find(TempData["peli_id"]).Nombre;
                //ViewBag.fechaInicio = TempData["fecha"];
                //ViewBag.IdTipoDocumento = new SelectList(ctx.TiposDocumentos, "IdTipoDocumento", "Descripcion");

                    return RedirectToAction("Inicio", "Home"); ;

            }

        [HttpPost]

        public ActionResult Reserva(CapaServicio.Carteleras h)
        {
            ViewBag.sede = ctx.Sedes.Find(TempData["sedee"]).Nombre;
            ViewBag.version = ctx.Versiones.Find(TempData["id_Version"]).Nombre;
            ViewBag.hora = h.HoraInicio;
            ViewBag.pelicula = ctx.Peliculas.Find(TempData["peli_id"]).Nombre;
            ViewBag.fechaInicio= TempData["fecha"];
            ViewBag.IdTipoDocumento = new SelectList(ctx.TiposDocumentos, "IdTipoDocumento", "Descripcion");

            TempData["Idsede"] = TempData["sedee"];
            TempData["IdVersion"] = TempData["id_Version"];
            TempData["idPeli"] = TempData["peli_id"];
            TempData["hInicio"] = ViewBag.hora;
            TempData["fechaInicio"] = ViewBag.fechaInicio;
         //   DateTime fechaIni = DateTime.Parse(fechaInicio, new CultureInfo("en-CA"));

            return View();

        }

        [HttpPost]

        public ActionResult ValidarReserva(FormCollection f)
        { 
            /* Aca intento guardar los datos en el contexto,
            pero tira una excepcion */

            var lis = new List<Reservas>();
            var r = new Reservas();
  
            var email = f["Email"];
            var CantEntradas = f["CantidadEntradas"];
            var docum = f["NumeroDocumento"];
            var sede = TempData["sedee"];
            var IdSede=TempData["Idsede"]; 
            var Idversion= TempData["IdVersion"]; 
            var idPeli=TempData["idPeli"]; 
            string hInicio = Convert.ToString(TempData["hInicio"]);
            string fechaInicio = Convert.ToString(TempData["fechaInicio"]);
            var IdTipoDocumento= f["IdTipoDocumento"];

            string FechaReserva = fechaInicio + " " + hInicio; 
            
           

       //     DateTime DiaReserva = Convert.ToDateTime(FechaReserva); // Aca tira la excepcion

            //Aca intento guardar los datos: 
            r.Email = email;
            r.CantidadEntradas = Convert.ToInt32(CantEntradas);
            r.IdPelicula =  Convert.ToInt32(idPeli);
            r.IdSede = Convert.ToInt32(sede);
            r.IdTipoDocumento = Convert.ToInt32(IdTipoDocumento);
            r.IdVersion = Convert.ToInt32(Idversion);
            r.NumeroDocumento = docum;
            r.FechaCarga = DateTime.Now;
            r.FechaHoraInicio = DateTime.Now;
            r.FechaHoraInicio= DateTime.Now;
         
            ctx.Reservas.Add(r); 
          //  ctx.SaveChanges();// Otra excepcion

            return View();
        
        
        }


    }
}

            




    


            