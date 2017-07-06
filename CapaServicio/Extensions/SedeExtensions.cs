using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Extensions
{
    public class SedeExtensions
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100, ErrorMessage = "Ha sobrepasado el límite de caracteres permitidos")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(300, ErrorMessage = "Ha sobrepasado el límite de caracteres permitidos")]
        public string Direccion { get; set; }
        [DisplayName("Precio General")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0.05, 999999999999999999.99, ErrorMessage = "Ha sobrepasado el valor permitido o el mismo es menor a 0,05")]
        public decimal PrecioGeneral { get; set; }
    }
}
