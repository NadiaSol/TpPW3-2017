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
                IdSede = value.IdSede,
                Nombre = value.Nombre,
                Direccion = value.Direccion,
                PrecioGeneral = value.PrecioGeneral
            };
        }
        public static Sedes Map(this SedeViewModel model, Sedes entity = null)
        {
            var edit = entity != null;
            if (!edit)
            {
                entity = new Sedes
                {
                    IdSede = model.IdSede
                };
            }
            entity.Direccion = model.Direccion;
            entity.Nombre = model.Nombre;
            entity.PrecioGeneral = model.PrecioGeneral;
            return entity;

        }

    }
}
