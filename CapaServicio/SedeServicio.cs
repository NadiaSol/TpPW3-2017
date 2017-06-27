using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
    public class SedeServicio
    {
        private Entities db = new Entities();
        public bool Crear(Sedes sede)
        {
            if (db.Sedes.Any(x => x.Nombre == sede.Nombre))
                return false;
            if (db.Sedes.Any(x => x.IdSede == sede.IdSede))
            {
                var sedeDb = db.Carteleras.SingleOrDefault(x => x.IdSede == sede.IdSede);
                db.Entry(sedeDb).CurrentValues.SetValues(sede);
            }
            else
            {
                db.Sedes.Add(sede);
            }

            db.SaveChanges();
            return true;
        }
    }
}
