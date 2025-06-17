using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DentAssist.Models.Data.Entities
{

    public class PlanTratamiento
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public string? Observaciones { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un paciente.")]
        public Guid PacienteId { get; set; }

        [ValidateNever]       // nunca valides esta propiedad
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un odontólogo.")]
        public Guid OdontologoId { get; set; }

        [ValidateNever]
        public Odontologo? Odontologo { get; set; }
    }


}
