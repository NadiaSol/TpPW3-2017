using CapaServicio;
using CapaServicio.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tp_Cines_.Models
{
    [MetadataType(typeof(ReservaExtensions))]
    public class ReservaViewModel : Reservas
    {
        public List<Peliculas> Peliculas { get; set; }
        public List<Versiones> Versiones { get; set; }
        public List<Sedes> Sedes { get; set; }
        public List<TiposDocumentos> TiposDocumentos {get; set;}
    }
}