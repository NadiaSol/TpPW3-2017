using System.Linq;
using System.Web.Mvc;
using CapaSevicio;

namespace Tp_Cines_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Entities1 ctx = new Entities1();

        private UsuarioServicio _usuariosServicio;
        public ActionResult Inicio()
        {
            //var p= (SELECT * from Peliculas);
            IQueryable<Peliculas> p = from Peliculas in ctx.Peliculas select Peliculas;

            return View(p.ToList());
        }
        [HttpPost]
        public ActionResult Login(Usuarios usuario)
        {
            var usuarioValido = _usuariosServicio.Autenticar(usuario);

            if (usuarioValido == null)
            {
                ViewBag.Mensaje = "Usuario o contraseña inválida.";
                return View();
            }

            AlmacenarEnSesion(usuarioValido);

            return RedirectToAction("Administracion", "Inicio");
        }

        private void AlmacenarEnSesion(Usuarios usuario)
        {
            Session["Nombre"] = usuario.NombreUsuario;
            Session["IdUsuario"] = usuario.IdUsuario;
        }

    }
}
