using CapaServicio;

namespace Tp_Cines_.Models.Extensions
{
    public static class CarteleraViewModelExtension
    {
        public static CarteleraViewModel Map(this Carteleras value)
        {
            return new CarteleraViewModel
            {
                IdCartelera = value.IdCartelera,
                IdSede = value.IdSede,
                IdPelicula = value.IdPelicula,
                IdVersion = value.IdVersion,
                FechaInicio = value.FechaInicio,
                Lunes = value.Lunes,
                Jueves = value.Jueves,
                Martes = value.Martes,
                FechaFin = value.FechaFin,
                NumeroSala = value.NumeroSala,
                FechaCarga = value.FechaCarga,
                Domingo = value.Domingo,
                HoraInicio = value.HoraInicio,
                Miercoles = value.Miercoles,
                Sabado = value.Sabado,
                Viernes = value.Viernes
            };
        }
    }
}