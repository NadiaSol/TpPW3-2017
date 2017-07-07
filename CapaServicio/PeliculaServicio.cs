using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
    public class PeliculaServicio
    {
        private static readonly List<Peliculas> Peliculas = new List<Peliculas>();
        public Peliculas GetById(int id)
        {
            using (var db = new Entities())
            {

                var pelicula = db.Peliculas.SingleOrDefault(x => x.IdPelicula == id);
                return pelicula;
            }
        }

    
    }
}
