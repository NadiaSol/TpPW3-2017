using System.Linq;

namespace CapaServicio
{
    public class SedeServicio
    {
        public void CreateOrUpdate(Sedes sede)
        {
            using (var db = new Entities())
            {
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
                //return true;
            }
        }
        public bool Exist(Sedes sede)
        {
            using (var db = new Entities())
            {
                if (db.Sedes.Any(x => x.Nombre == sede.Nombre))
                    return true;
                return false;
            }

        }
    }
}
