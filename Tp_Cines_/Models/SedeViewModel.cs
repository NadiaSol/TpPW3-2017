using CapaServicio;
using CapaServicio.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Tp_Cines_.Models
{
    [MetadataType(typeof(SedeExtensions))]
    public class SedeViewModel : Sedes
    {
    }
}