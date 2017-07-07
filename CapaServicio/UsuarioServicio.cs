using CapaServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{

    public class UsuarioServicio
    {

        public bool Isvalid(string Nombre, string Password)
        {
            bool Isvalid = false;
            using (var db = new Entities())
            {
                var user = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == Nombre); //consultar el primer registro con el email del usuario
                if (user != null)
                {
                    if (user.Password == Password) //Verificar password del usuario
                    {

                        Isvalid = true;
                    }
                }
            }
            return Isvalid;
        }
    }


}