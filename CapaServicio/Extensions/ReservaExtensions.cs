using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Extensions
{
    public class ReservaExtensions
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdSede { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdVersion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Película")]
        public int IdPelicula { get; set; }
        [Required]
        public System.DateTime FechaHoraInicio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no válido")]
        [StringLength(250, ErrorMessage = "Ha sobrepasado el límite de caracteres permitidos")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdTipoDocumento { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, ErrorMessage = "Ha sobrepasado el límite de caracteres permitidos")]
        public string NumeroDocumento { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CantidadEntradas { get; set; }
        public System.DateTime FechaCarga { get; set; }
    }
}
