using CapaServicio;
using CapaServicio.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Tp_Cines_.Models
{
    [MetadataType(typeof(PeliculaExtensions))]
    public class PeliculaViewModel : Peliculas
    {
    }
}