using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaServicio;

namespace Tp_Cines_.Models.Extensions
{
    public static class ReservaViewModelExtension
    {
        public static ReservaViewModel Map(this Reservas value)
        {
            return new ReservaViewModel
            {
                IdSede = value.IdSede,
                IdPelicula = value.IdPelicula,
                IdVersion = value.IdVersion,
                IdReserva = value.IdReserva,
                FechaHoraInicio = value.FechaHoraInicio,
                FechaCarga = value.FechaCarga,
                Email = value.Email,
                CantidadEntradas = value.CantidadEntradas,
                NumeroDocumento = value.NumeroDocumento,
                TiposDocumentos = value.TiposDocumentos,

            };
        }
    }
}