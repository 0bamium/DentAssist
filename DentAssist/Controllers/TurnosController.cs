using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DentAssist.Models.Data;
using DentAssist.Models.Data.Entities;

namespace DentAssist.Controllers
{
    public class TurnosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TurnosController> _logger;

        public TurnosController(AppDbContext context, ILogger<TurnosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Turnos
        public async Task<IActionResult> Index()
        {
            var turnos = await _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Odontologo)
                .ToListAsync();
            return View(turnos);
        }

        // GET: Turnos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var turno = await _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Odontologo)
                .FirstOrDefaultAsync(t => t.Id == id.Value);
            if (turno == null) return NotFound();

            return View(turno);
        }

        // GET: Turnos/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre");
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre");
            return View();
        }

        // POST: Turnos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaHora,Duracion,Estado,PacienteId,OdontologoId")] Turno turno)
        {
            // Limpia posibles errores de navegación
            ModelState.Remove(nameof(turno.Paciente));
            ModelState.Remove(nameof(turno.Odontologo));

            if (!ModelState.IsValid)
            {
                ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", turno.PacienteId);
                ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", turno.OdontologoId);
                return View(turno);
            }

            turno.Id = Guid.NewGuid();
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Turnos/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var turno = await _context.Turnos.FindAsync(id.Value);
            if (turno == null) return NotFound();

            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", turno.PacienteId);
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", turno.OdontologoId);
            ViewData["Estados"] = new SelectList(new[]
            {
        new { Value = 0, Text = "Pendiente" },
        new { Value = 1, Text = "Confirmado" },
        new { Value = 2, Text = "Cancelado" }
    }, "Value", "Text", turno.Estado);

            return View(turno);
        }

        // POST: Turnos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
            [Bind("Id,FechaHora,Duracion,Estado,PacienteId,OdontologoId")] Turno turno)
        {
            if (id != turno.Id) return NotFound();

            // limpia errores de navegación
            ModelState.Remove(nameof(turno.Paciente));
            ModelState.Remove(nameof(turno.Odontologo));

            if (!ModelState.IsValid)
            {
                ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", turno.PacienteId);
                ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", turno.OdontologoId);
                ViewData["Estados"] = new SelectList(new[]
                {
            new { Value = 0, Text = "Pendiente" },
            new { Value = 1, Text = "Confirmado" },
            new { Value = 2, Text = "Cancelado" }
        }, "Value", "Text", turno.Estado);

                return View(turno);
            }
            _context.Update(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Turnos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var turno = await _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Odontologo)
                .FirstOrDefaultAsync(t => t.Id == id.Value);
            if (turno == null) return NotFound();

            return View(turno);
        }

        // POST: Turnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
