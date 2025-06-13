using System.ComponentModel.DataAnnotations;

namespace DentAssist.Models.Data.Entities
{
    public class Odontologo
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="El nombre debe ser obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La matricula debe ser obligatoria")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "La especialidad debe ser obligatoria")]
        public string Especialidad { get; set; }
        [Required(ErrorMessage = "El Email debe ser obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email invalido")]
        public string Email { get; set; }

        // Navigation properties
        public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
        public ICollection<PlanTratamiento> PlanesTratamiento { get; set; } = new List<PlanTratamiento>();

    }
}
