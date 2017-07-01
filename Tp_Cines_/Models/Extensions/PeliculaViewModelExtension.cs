using CapaServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp_Cines_.Models.Extensions
{
    public static class PeliculaViewModelExtension
    {
        public static PeliculaViewModel Map(this Peliculas value)
        {
            return new PeliculaViewModel
            {
                Nombre = value.Nombre,
                Descripcion = value.Descripcion,
                Imagen = value.Imagen,
                IdCalificacion = value.IdCalificacion,
                IdGenero = value.IdGenero,
                IdPelicula = value.IdPelicula,
                Duracion = value.Duracion,
                FechaCarga = value.FechaCarga
            };
        }
    }
}