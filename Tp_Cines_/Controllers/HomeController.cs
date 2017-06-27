using System.Linq;
using System.Web.Mvc;
using CapaServicio;
using System.Web.Security;
using System;


namespace Tp_Cines_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Entities ctx = new Entities();

        //private UsuarioServicio _usuariosServicio;
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
        public ActionResult login(CapaServicio.UsuarioServicio user)
        {
            if (ModelState.IsValid) //Verificar que el modelo de datos sea válido en cuanto a la definición de las propiedades
            {
                if (Isvalid(user.Nombre, user.Password))//Verificar que el email y clave exista utilizando el método privado
                {

                    FormsAuthentication.SetAuthCookie(user.Nombre, false); //crea variable de usuario con el correo del usuario
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

        private bool Isvalid(string Nombre, string Password)
        {
            bool Isvalid = false;
            using (var db = new Entities())
            {
                var user = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == Nombre); //consultar el primer registro con el email del usuario
                if (user != null)
                {
                    if (user.Password == Password) //Verificar password del usuario
                    {
                        Session["Nombre"] = user.NombreUsuario;
                        Isvalid = true;
                    }
                }
            }
            return Isvalid;
        }
        //private void AlmacenarEnSesion(Usuarios usuario)
        //{
        //    Session["Nombre"] = usuario.NombreUsuario;
        //    Session["IdUsuario"] = usuario.IdUsuario;
        //}
        public ActionResult Reserva()
        {

            //IdSede, Idversion, Idpelicula

            ViewBag.IdSede = new SelectList(ctx.Sedes, "IdSede", "Nombre");
            ViewBag.IdVersion = new SelectList(ctx.Versiones, "IdVersion", "Nombre");
            ViewBag.IdPelicula = new SelectList(ctx.Peliculas, "IdPelicula", "Nombre");
            ViewBag.IdTipoDocumento = new SelectList(ctx.TiposDocumentos, "IdTipoDocumento", "Descripcion");
            return View();
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
