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
            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nombre");
            ViewBag.Odontologos = new SelectList(_context.Odontologos, "Id", "Nombre");
            return View();
        }

        // POST: Turnos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaHora,Duracion,Estado,PacienteId,OdontologoId")] Turno turno)
        {
            ModelState.Remove(nameof(turno.Paciente));
            ModelState.Remove(nameof(turno.Odontologo));

            if (!ModelState.IsValid)
            {
                ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nombre", turno.PacienteId);
                ViewBag.Odontologos = new SelectList(_context.Odontologos, "Id", "Nombre", turno.OdontologoId);
                return View(turno);
            }

            turno.Id = Guid.NewGuid();
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Turnos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var turno = await _context.Turnos.FindAsync(id.Value);
            if (turno == null) return NotFound();

            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nombre", turno.PacienteId);
            ViewBag.Odontologos = new SelectList(_context.Odontologos, "Id", "Nombre", turno.OdontologoId);

            return View(turno);
        }

        // POST: Turnos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
            [Bind("Id,FechaHora,Duracion,Estado,PacienteId,OdontologoId")] Turno turno)
        {
            if (id != turno.Id) return NotFound();

            ModelState.Remove(nameof(turno.Paciente));
            ModelState.Remove(nameof(turno.Odontologo));

            if (!ModelState.IsValid)
            {
                ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nombre", turno.PacienteId);
                ViewBag.Odontologos = new SelectList(_context.Odontologos, "Id", "Nombre", turno.OdontologoId);
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
