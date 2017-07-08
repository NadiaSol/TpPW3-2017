using System.Linq;
using System.Web.Mvc;
using CapaServicio;
using System.Web.Security;
using System;
using Tp_Cines_.Models;

namespace Tp_Cines_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private Entities ctx = new Entities();
        private UsuarioServicio _usuarioServicio = new UsuarioServicio();
        public ActionResult Inicio()
        {
            IQueryable<Peliculas> p = from Peliculas in ctx.Peliculas select Peliculas;

            return View(p.ToList());
        }
        [HttpGet]
        public ActionResult Login(string returnUrl/*Usuarios usuario*/)
        {
            TempData["returnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel user)
        {
            if (ModelState.IsValid) //Verificar que el modelo de datos sea válido en cuanto a la definición de las propiedades
            {
                if (_usuarioServicio.Isvalid(user.NombreUsuario, user.Password))//Verificar que el email y clave exista utilizando el método privado
                {
                    Session["Nombre"] = user.NombreUsuario;
                    FormsAuthentication.SetAuthCookie(user.NombreUsuario, false); //crea variable de usuario con el correo del usuario
                    if (TempData["returnUrl"] != null)
                        return Redirect(TempData["returnUrl"].ToString());

                    return RedirectToAction("Inicio", "Administracion"); //dirigir al controlador home vista Index una vez se a autenticado en el sistema
                }
                else
                {
                    ModelState.AddModelError("", "Login Incorrecto"); //adicionar mensaje de error al model
                }
            }
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Inicio", "Home");
        }


        //private void AlmacenarEnSesion(Usuarios usuario)
        //{
        //    Session["Nombre"] = usuario.NombreUsuario;
        //    Session["IdUsuario"] = usuario.IdUsuario;
        //}
        [HttpGet]
        public ActionResult Reserva()
        {

            //IdSede, Idversion, Idpelicula

            //TempData["Sedes"] = ViewBag.IdSede;
            //TempData["Version"] = ViewBag.IdVersion;
            //TempData["Pelicula"] = ViewBag.IdPelicula;
            var reservaNueva = new ReservaViewModel();
            Initialize(reservaNueva);
            return View("Reserva", reservaNueva);
        }
        private void Initialize(ReservaViewModel model)
        {
            model.Peliculas = ctx.Peliculas.ToList();
            model.Sedes = ctx.Sedes.ToList();
            model.Versiones = ctx.Versiones.ToList();
            model.TiposDocumentos = ctx.TiposDocumentos.ToList();
        }
        [HttpPost]
        public ActionResult Reserva(Reservas reservas)
        {
            if (ModelState.IsValid)
            {

                reservas.FechaCarga = DateTime.Now;
                ctx.Reservas.Add(reservas);
                ctx.SaveChanges();
                return RedirectToAction("Inicio", "Home");
            }
            ViewBag.IdSede = new SelectList(ctx.Sedes, "IdSede", "Nombre", reservas.IdSede);
            ViewBag.IdVersion = new SelectList(ctx.Versiones, "IdVersion", "Nombre", reservas.IdVersion);
            ViewBag.IdPelicula = new SelectList(ctx.Peliculas, "IdPelicula", "Nombre", reservas.IdPelicula);
            ViewBag.IdTipoDocumento = new SelectList(ctx.TiposDocumentos, "IdTipoDocumento", "Descripcion", reservas.IdTipoDocumento);
            return View(reservas);
        }
    }
}
