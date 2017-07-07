using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
    public class PeliculaServicio
    {
        public Peliculas GetById(int id)
        {
            using (var db = new Entities())
            {

                var pelicula = db.Peliculas.SingleOrDefault(x => x.IdPelicula == id);
                return pelicula;
            }
        }

        public List<int> Horarios(int funcion, int idPelicula)
        {
            var duracion = GetById(idPelicula).Duracion;

            var horarios = new List<int> { funcion };
            var i = 1;
            for (i = 1; i <= 6; i++)
            {
                funcion = duracion + 30;
                horarios.Add(funcion);
            }

            return horarios;
        }


    }
}
