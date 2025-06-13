using System.ComponentModel.DataAnnotations;

namespace DentAssist.Models.Data.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre debe ser obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El rut debe ser obligatorio")]
        public string Rut { get; set; }
        [Required(ErrorMessage = "El telefono debe ser obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El email debe ser obligatorio")]
        [EmailAddress(ErrorMessage ="Formato de email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La direccion debe ser obligatorio")]
        public string Direccion { get; set; }

        // Navigation properties
        public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
        public ICollection<PlanTratamiento> PlanesTratamiento { get; set; } = new List<PlanTratamiento>();

    }
}
