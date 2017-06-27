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
                foreach (var s in db.Sedes)
                {
                    if (s.IdSede != sede.IdSede) continue;
                    s.Direccion = sede.Direccion;
                    s.Nombre = sede.Nombre;
                    s.PrecioGeneral = sede.PrecioGeneral;
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
