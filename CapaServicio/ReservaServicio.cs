using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
    public class ReservaServicio
    {
        public List<Reservas> FiltrarFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var db = new Entities())
            {
                var reservasFiltradas = db.Reservas.Include("Peliculas").Include("Sedes").Include("Versiones").Where(x => x.FechaHoraInicio >= fechaInicio
                && x.FechaHoraInicio <= fechaFin).ToList();
                return reservasFiltradas;
            }

        }
    }
}
