using DentAssist.Models.Data;
using DentAssist.Models.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DentAssist.Controllers
{
    public class PlanTratamientosController : Controller
    {
        private readonly AppDbContext _context;

        public PlanTratamientosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PlanTratamientoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PlanesTratamiento.Include(p => p.Odontologo).Include(p => p.Paciente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PlanTratamientoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planTratamiento = await _context.PlanesTratamiento
                .Include(p => p.Odontologo)
                .Include(p => p.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planTratamiento == null)
            {
                return NotFound();
            }

            return View(planTratamiento);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.PacienteId = new SelectList(_context.Pacientes, "Id", "Nombre");
            ViewBag.OdontologoId = new SelectList(_context.Odontologos, "Id", "Nombre");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("FechaCreacion,Observaciones,PacienteId,OdontologoId")]
            PlanTratamiento plan)
        {
            // Validación: fecha no futura
            if (plan.FechaCreacion.Date > DateTime.Today)
                ModelState.AddModelError("FechaCreacion", "La fecha no puede ser posterior al día de hoy.");

            // Validación: mismo paciente y fecha duplicada
            if (_context.PlanesTratamiento.Any(p =>
                p.PacienteId == plan.PacienteId &&
                p.FechaCreacion.Date == plan.FechaCreacion.Date))
            {
                ModelState.AddModelError(string.Empty, "Ya existe un plan de tratamiento para este paciente en esa fecha.");
            }

            if (!ModelState.IsValid)
            {
                // Recarga dropdowns en caso de error
                ViewBag.PacienteId = new SelectList(_context.Pacientes, "Id", "Nombre", plan.PacienteId);
                ViewBag.OdontologoId = new SelectList(_context.Odontologos, "Id", "Nombre", plan.OdontologoId);
                return View(plan);
            }

            plan.Id = Guid.NewGuid();
            _context.Add(plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PlanTratamientoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planTratamiento = await _context.PlanesTratamiento.FindAsync(id);
            if (planTratamiento == null)
            {
                return NotFound();
            }
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", planTratamiento.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", planTratamiento.PacienteId);
            return View(planTratamiento);
        }

        // POST: PlanTratamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
            [Bind("Id,FechaCreacion,Observaciones,PacienteId,OdontologoId")]
            PlanTratamiento planTratamiento)
        {
            if (id != planTratamiento.Id)
                return NotFound();

            // Validación: fecha no futura
            if (planTratamiento.FechaCreacion.Date > DateTime.Today)
                ModelState.AddModelError("FechaCreacion", "La fecha no puede ser posterior al día de hoy.");

            // Validación: duplicado excluyendo este registro
            if (_context.PlanesTratamiento.Any(p =>
                p.PacienteId == planTratamiento.PacienteId &&
                p.FechaCreacion.Date == planTratamiento.FechaCreacion.Date &&
                p.Id != id))
            {
                ModelState.AddModelError(string.Empty, "Ya existe otro plan para este paciente en esa fecha.");
            }

            if (!ModelState.IsValid)
            {
                ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", planTratamiento.OdontologoId);
                ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", planTratamiento.PacienteId);
                return View(planTratamiento);
            }

            try
            {
                _context.Update(planTratamiento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PlanesTratamiento.Any(e => e.Id == planTratamiento.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PlanTratamientoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planTratamiento = await _context.PlanesTratamiento
                .Include(p => p.Odontologo)
                .Include(p => p.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planTratamiento == null)
            {
                return NotFound();
            }

            return View(planTratamiento);
        }

        // POST: PlanTratamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var planTratamiento = await _context.PlanesTratamiento.FindAsync(id);
            if (planTratamiento != null)
            {
                _context.PlanesTratamiento.Remove(planTratamiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanTratamientoExists(Guid id)
        {
            return _context.PlanesTratamiento.Any(e => e.Id == id);
        }
    }
}
