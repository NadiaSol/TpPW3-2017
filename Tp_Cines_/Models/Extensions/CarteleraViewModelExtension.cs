using System.Web.UI.WebControls;
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

        public static Carteleras Map(this CarteleraViewModel model, Carteleras entity = null)
        {
            var edit = entity != null;
            if (!edit)
            {
                entity = new Carteleras
                {
                    IdCartelera = model.IdCartelera
                };
            }
            entity.FechaInicio = model.FechaInicio;
            entity.FechaFin = model.FechaFin;
            entity.Domingo = model.Domingo;
            entity.Lunes = model.Lunes;
            entity.Martes = model.Martes;
            entity.Miercoles = model.Miercoles;
            entity.Jueves = model.Jueves;
            entity.Viernes = model.Viernes;
            entity.Sabado = model.Sabado;
            entity.IdSede = model.IdSede;
            entity.IdPelicula = model.IdPelicula;
            entity.IdVersion = model.IdVersion;
            entity.HoraInicio = model.HoraInicio;
            entity.NumeroSala = model.NumeroSala;

            return entity;

        }
    }
}