//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaServicio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Reservas
    {
        public int IdReserva { get; set; }
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
        [StringLength(250,ErrorMessage ="Ha sobrepasado el límite de caracteres permitidos")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdTipoDocumento { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, ErrorMessage = "Ha sobrepasado el límite de caracteres permitidos")]
        public string NumeroDocumento { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CantidadEntradas { get; set; }
        public System.DateTime FechaCarga { get; set; }
    
        public virtual Peliculas Peliculas { get; set; }
        public virtual Sedes Sedes { get; set; }
        public virtual TiposDocumentos TiposDocumentos { get; set; }
        public virtual Versiones Versiones { get; set; }
    }
}
