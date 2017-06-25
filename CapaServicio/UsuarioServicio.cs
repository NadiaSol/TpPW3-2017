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

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        private Entities db = new Entities();
        //public Usuarios Autenticar(Usuarios usuario)
        //{

        //    if (db.Usuarios.Any(x=>x.Password== usuario.Password) && db.Usuarios.Any(x => x.NombreUsuario == usuario.NombreUsuario))
        //    {
        //        return new Usuarios { NombreUsuario = "Administrador"};
        //    }

        //    return null;
        //}
    }


}