using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
    public class CarteleraServicio
    {
        public void CreateOrUpdate(Carteleras cartelera)
        {
           
            using (var db = new Entities())
            {
                cartelera.FechaCarga = DateTime.Now;
                if (cartelera.IdCartelera ==0)
                {
                    db.Carteleras.Add(cartelera);
                }
                else
                {
                    var carteleraDb = db.Carteleras.SingleOrDefault(x => x.IdCartelera == cartelera.IdCartelera);
                    db.Entry(carteleraDb).CurrentValues.SetValues(cartelera);
                }

                db.SaveChanges();
            }
        }

        public bool Exist(Carteleras cartelera)
        {
            using (var db = new Entities())
            {
                var exist =
                    db.Carteleras.FirstOrDefault(
                        x =>
                            x.IdSede == cartelera.IdSede && 
                            x.IdPelicula == cartelera.IdPelicula &&
                            x.IdVersion == cartelera.IdVersion &&
                            x.IdCartelera != cartelera.IdCartelera);

                if (exist == null)
                {
                        return false;
                    
                }

                return true;
            }
        }

        public bool SalaOcupada(Carteleras cartelera)
        {
            using (var db = new Entities())
            {
                if (
                    !db.Carteleras.Any(
                        x => x.IdCartelera != cartelera.IdCartelera && x.IdSede == cartelera.IdSede &&
                             x.NumeroSala == cartelera.NumeroSala &&
                             ((x.FechaInicio.CompareTo(cartelera.FechaInicio) >= 0 &&
                               x.FechaInicio.CompareTo(cartelera.FechaFin) <= 0)
                              ||
                              (x.FechaFin.CompareTo(cartelera.FechaInicio) >= 0 &&
                               x.FechaFin.CompareTo(cartelera.FechaFin) <= 0)
                              ||
                              (x.FechaInicio.CompareTo(cartelera.FechaInicio) <= 0 &&
                               x.FechaFin.CompareTo(cartelera.FechaFin) >= 0))))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
