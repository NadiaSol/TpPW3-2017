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
            //var p= (SELECT * from Peliculas);
            IQueryable<Peliculas> p = from Peliculas in ctx.Peliculas select Peliculas;

            return View(p.ToList());
        }
        [HttpGet]
        public ActionResult Login(/*Usuarios usuario*/)
        {
            //var usuarioValido = _usuariosServicio.Autenticar(usuario);

            //if (usuarioValido == null)
            //{
            //    ViewBag.Mensaje = "Usuario o contraseña inválida.";
            //    return View();
            //}

            //AlmacenarEnSesion(usuarioValido);

            //return RedirectToAction("Administracion", "Inicio");
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

    }
}
