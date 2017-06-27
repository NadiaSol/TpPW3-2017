using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
    public class CarteleraServicio
    {
        private Entities db = new Entities();
        public bool Create(Carteleras cartelera)
        {
            if (!db.Carteleras.Any(x => x.IdSede == cartelera.IdSede && x.IdPelicula == cartelera.IdPelicula && x.IdVersion == cartelera.IdVersion))
            {
                if (!db.Carteleras.Any(x => x.IdSede == cartelera.IdSede &&
                x.NumeroSala == cartelera.NumeroSala &&
                ((x.FechaInicio.CompareTo(cartelera.FechaInicio) >= 0 && x.FechaInicio.CompareTo(cartelera.FechaFin) <= 0)
                || (x.FechaFin.CompareTo(cartelera.FechaInicio) >= 0 && x.FechaFin.CompareTo(cartelera.FechaFin) <= 0)
                || (x.FechaInicio.CompareTo(cartelera.FechaInicio) <= 0 && x.FechaFin.CompareTo(cartelera.FechaFin) >= 0))))
                {
                    Carteleras carteleraNueva = new Carteleras();
                    carteleraNueva = cartelera;
                    carteleraNueva.FechaCarga = DateTime.Now;
                    db.Carteleras.Add(carteleraNueva);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
