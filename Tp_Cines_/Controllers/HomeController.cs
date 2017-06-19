using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaServicio;




namespace Tp_Cines_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Entities ctx = new Entities();


        public ActionResult Inicio()
        {
            //var p= (SELECT * from Peliculas);
            IQueryable<Peliculas> p = from Peliculas in ctx.Peliculas select Peliculas;

            return View(p.ToList());
        }

    }
}
