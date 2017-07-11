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

        //public List<int> Horarios(int funcion, int idPelicula)
        //{
        //    var minutosFuncion = funcion * 60; //calculo minutos de la horaInicio
        //    var duracion = GetById(idPelicula).Duracion;

        //    var horarios = new List<int> { funcion };
        //    var i = 1;
        //    for (i = 1; i <= 6; i++)
        //    {
        //        minutosFuncion += duracion + 30;
        //        int horaFuncion = minutosFuncion / 60;
        //        if (horaFuncion > 24)
        //        {
        //            horaFuncion = horaFuncion - 24;
        //        }
        //        horarios.Add(horaFuncion);
        //    }
        //    return horarios;
        //}

        public List<string> Horarios(int funcion, int idPelicula)
        {
            string funcionInicial = funcion.ToString() + ":00";
            var tiempoSegundosFuncion = funcion * 3600; //calculo minutos de la horaInicio
            var duracionSegundos = GetById(idPelicula).Duracion * 60;
            int horaFuncion;
            int minutosFuncion;
            var horarios = new List<string> { funcionInicial };
            var i = 1;
            for (i = 1; i <= 6; i++)
            {
                //se calcula en segundos la próxima película dónde 1800"=30'
                tiempoSegundosFuncion += duracionSegundos + 1800;
                //calculo horas y minutos a partir de los segundos.
                horaFuncion = tiempoSegundosFuncion / 3600;
                minutosFuncion = (tiempoSegundosFuncion - horaFuncion*3600)/60;
                if (horaFuncion >= 24)
                {
                    horaFuncion = horaFuncion - 24;
                }
                horarios.Add((horaFuncion>9 ? horaFuncion.ToString() : "0"+ horaFuncion.ToString() )+
                    ":"+(minutosFuncion >9 ? minutosFuncion.ToString() : "0"+minutosFuncion.ToString()));
            }
            return horarios;
        }

    }
}
