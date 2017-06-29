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
    }
}