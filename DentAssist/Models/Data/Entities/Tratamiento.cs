using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioEstimado { get; set; }

        // Navigation properties
        public ICollection<PasoTratamiento> PasosTratamiento { get; set; } = new List<PasoTratamiento>();

    }
}
