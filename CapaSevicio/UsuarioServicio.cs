using System.Linq;

namespace CapaSevicio
{
    public class UsuarioServicio
    {
        private Entities1 db = new Entities1();
        public Usuarios Autenticar(Usuarios usuario)
        {
            var usuarioAutenticado = db.Usuarios.Select(x => x.NombreUsuario == usuario.NombreUsuario).Where(Password == usuario.Password);
            if (usuarioAutenticado!=null)
            {
                return new Usuarios { NombreUsuario = "Administrador", IdUsuario = usuarioAutenticado.IdUsuario};
            }

            return null;
        }
    }
}
