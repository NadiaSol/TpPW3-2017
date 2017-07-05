using System.Linq;

namespace CapaServicio
{
    public class SedeServicio
    {
        public void CreateOrUpdate(Sedes sede)
        {
            using (var db = new Entities())
            {
                if (sede.IdSede!=0)
                {
                    var sedeDb = db.Sedes.SingleOrDefault(x => x.IdSede == sede.IdSede);
                    db.Entry(sedeDb).CurrentValues.SetValues(sede);
                }
                else
                {
                    db.Sedes.Add(sede);
                }

                db.SaveChanges();
            }
        }
        public bool Exist(Sedes sede)
        {
            using (var db = new Entities())
            {
                return db.Sedes.Any(x => x.Nombre == sede.Nombre&& x.IdSede!=sede.IdSede);
            }
        }
    }
}
