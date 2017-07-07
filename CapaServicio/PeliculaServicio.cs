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
            var minutosFuncion=funcion * 60; //calculo minutos
            var duracion = GetById(idPelicula).Duracion;

            var horarios = new List<int> { funcion };
            var i = 1;
            for (i = 1; i <= 6; i++)
            {
                minutosFuncion += duracion + 30;
                int horaFuncion = minutosFuncion / 60;
                if(horaFuncion>24)
                {
                    horaFuncion = horaFuncion - 24;
                }
                horarios.Add(horaFuncion);
            }

            return horarios;
        }

        
    }
}
