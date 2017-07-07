using CapaServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tp_Cines_.Models
{
    public class ReporteViewModel
    {
        public List<Reservas> ListadoReservas {get;set;}
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
    }
}