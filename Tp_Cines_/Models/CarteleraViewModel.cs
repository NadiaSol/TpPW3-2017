using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CapaServicio;
using CapaServicio.Extensions;

namespace Tp_Cines_.Models
{
    [MetadataType(typeof(CarteleraExtensions))]
    public class CarteleraViewModel : Carteleras,IValidatableObject
    {
        public List<Peliculas> Peliculas { get; set; }
        public List<Versiones> Versiones { get; set; }
        public List<Sedes> Sedes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HoraInicio <= 15 && HoraInicio > 23)
                yield return new ValidationResult("No puede ser anterior a las 15hs",new []{ "HoraInicio" } ); //adicionar mensaje de error al model
        }
    }
}