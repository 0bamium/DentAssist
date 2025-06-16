using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DentAssist.Models.Data.Entities
{

    public class PlanTratamiento
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public string? Observaciones { get; set; }

        [Required]
        public Guid PacienteId { get; set; }

        [ValidateNever]       // nunca valides esta propiedad
        public Paciente? Paciente { get; set; }

        [Required]
        public Guid OdontologoId { get; set; }

        [ValidateNever]
        public Odontologo? Odontologo { get; set; }
    }


}
