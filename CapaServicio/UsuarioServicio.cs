using CapaServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{

        public class UsuarioServicio
        {
        private Entities db = new Entities();
        public Usuarios Autenticar(Usuarios usuario)
        {

            if (db.Usuarios.Any(x=>x.Password== usuario.Password) && db.Usuarios.Any(x => x.NombreUsuario == usuario.NombreUsuario))
            {
                return new Usuarios { NombreUsuario = "Administrador"};
            }

            return null;
        }
    }

    
}
