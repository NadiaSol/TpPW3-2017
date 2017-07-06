using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CapaServicio.Extensions
{
    public class CarteleraExtensions
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdSede { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdPelicula { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(15, 23, ErrorMessage = "Hora Inicio no puede ser anterior a las 15 hs")]
        public int HoraInicio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Debe ingresar ua fecha válida")]
        public System.DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Debe ingresar ua fecha válida")]
        public System.DateTime FechaFin { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Sala")]
        public int NumeroSala { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdVersion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Lunes { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Martes { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Miercoles { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Jueves { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Viernes { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Sabado { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Domingo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public System.DateTime FechaCarga { get; set; }
    }
}