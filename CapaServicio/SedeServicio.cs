using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
    public class SedeServicio
    {
        private Entities db = new Entities();
        public bool Create(Sedes sede)
        {
            if (db.Sedes.Any(x => x.Nombre == sede.Nombre))
                return false;
            Sedes nuevaSede = new Sedes();
            nuevaSede = sede;
            db.Sedes.Add(nuevaSede);
            db.SaveChanges();
            return true;
        }
    }
}
