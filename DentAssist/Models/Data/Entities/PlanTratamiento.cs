using System.ComponentModel.DataAnnotations;

namespace DentAssist.Models.Data.Entities
{
    public class PlanTratamiento
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "La fecha de la creacion debe ser obligatoria")]
        public DateTime? FechaCreacion { get; set; }
        public string Observaciones { get; set; }

        // relationships
        public Paciente Paciente { get; set; }
        public Guid PacienteId { get; set; }
        public Odontologo Odontologo { get; set; }
        public Guid OdontologoId { get; set; }

        //  Navigation properties
        public ICollection<PasoTratamiento> Pasos { get; set; } = new List<PasoTratamiento>();

    }
}
