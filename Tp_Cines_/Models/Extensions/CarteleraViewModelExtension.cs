using System.Web.UI.WebControls;
using CapaServicio;
using System.Collections.Generic;

namespace Tp_Cines_.Models.Extensions
{
    public static class CarteleraViewModelExtension
    {
        private static readonly PeliculaServicio _peliculaServicio = new PeliculaServicio();
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
                Viernes = value.Viernes,
                Horarios= _peliculaServicio.Horarios(value.HoraInicio,value.IdPelicula)
            };
        }
        //public static List<int> Horarios(int funcion, int idPelicula)
        //{
        //    var duracion = _peliculaServicio.GetById(idPelicula).Duracion;

        //    var horarios = new List<int> { funcion };
        //    var i = 1;
        //    for (i = 1; i <= 6; i++)
        //    {
        //        funcion = duracion + 30;
        //        horarios.Add(funcion);
        //    }

        //    return horarios;
        //}
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