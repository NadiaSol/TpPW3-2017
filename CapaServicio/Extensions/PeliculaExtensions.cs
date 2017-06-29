using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Extensions
{
    public class PeliculaExtensions
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(750)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Escriba enlace de la imagen")]
        [StringLength(300)]
        public string Imagen { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdCalificacion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, 90, ErrorMessage = "La película no puede superar los 90 minutos")]
        public int Duracion { get; set; }
        [Required]
        public System.DateTime FechaCarga { get; set; }

    }
}
