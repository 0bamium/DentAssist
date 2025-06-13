using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DentAssist.Models.Data.Entities
{
    public class Tratamiento
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre debe ser obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion debe ser obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Precio debe ser obligatorio")]
        [Precision(10, 2)]
        public decimal PrecioEstimado { get; set; }

        // Navigation properties
        public ICollection<PasoTratamiento> PasosTratamiento { get; set; } = new List<PasoTratamiento>();

    }
}
