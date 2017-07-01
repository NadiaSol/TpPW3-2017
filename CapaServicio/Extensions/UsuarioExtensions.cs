using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Extensions
{
    public class UsuarioExtensions
    {
        [Required]
        [StringLength(50, ErrorMessage = "Ha sobrepasado el límite de caracteres permitidos")]
        public string NombreUsuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Ha sobrepasado el límite de caracteres permitidos")]
        public string Password { get; set; }
    }
}
