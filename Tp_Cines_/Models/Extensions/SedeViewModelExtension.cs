using CapaServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp_Cines_.Models.Extensions
{
    public static class SedeViewModelExtension
    {
        public static SedeViewModel Map(this Sedes value)
        {
            return new SedeViewModel
            {
                Nombre = value.Nombre,
                Direccion = value.Direccion,
                PrecioGeneral = value.PrecioGeneral
            };
        }

    }
}
