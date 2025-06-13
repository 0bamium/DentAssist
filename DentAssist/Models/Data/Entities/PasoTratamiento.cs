using System.ComponentModel.DataAnnotations;

namespace DentAssist.Models.Data.Entities
{
    public class PasoTratamiento
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="La fecha estimada debe ser obligatoria")]
        public DateTime? FechaEstimada { get; set; }
        [Required(ErrorMessage ="El estado debe ser obligatorio")]
        public int? Estado { get; set; }
        public string Observaciones { get; set; }

        // Navigation properties
        public Guid PlanTratamientoId { get; set; }
        public PlanTratamiento PlanTratamiento { get; set; }
        public Guid TratamientoId { get; set; }
        public Tratamiento Tratamiento { get; set; }
    }
}
