//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tp_Cines_
{
    using System;
    using System.Collections.Generic;
    
    public partial class TiposDocumentos
    {
        public TiposDocumentos()
        {
            this.Reservas = new HashSet<Reservas>();
        }
    
        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
