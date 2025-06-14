using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DentAssist.Models.Data.Entities
{
    public class Turno
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "La fecha y hora debe ser obligatoria")]
        public DateTime? FechaHora { get; set; }
        [Required(ErrorMessage = "La duracion debe ser obligatoria")]
        public int? Duracion { get; set; }
        [Required(ErrorMessage = "El estado debe ser obligatorio")]
        public int? Estado { get; set; }

        // relationships
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public Guid OdontologoId { get; set; }
        public Odontologo Odontologo { get; set; }

    }
}