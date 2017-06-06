using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
   public class Reserva
    {
        public int IdReserva { get; set; }
        public DateTime FecharHsInicio { get; set; }
        public string email { get; set; }
        public int dni { get; set; }
        public int CantidadEntradas { get; set; }
        public DateTime FechaCarga { get; set; }

    }
}
