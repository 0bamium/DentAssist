﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentAssist.Models.Data;
using DentAssist.Models.Data.Entities;

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

        // GET: PlanTratamientoes/Create
        public IActionResult Create()
        {
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Email");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Direccion");
            return View();
        }

        // POST: PlanTratamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaCreacion,Observaciones,PacienteId,OdontologoId")] PlanTratamiento planTratamiento)
        {
            if (ModelState.IsValid)
            {
                planTratamiento.Id = Guid.NewGuid();
                _context.Add(planTratamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Email", planTratamiento.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Direccion", planTratamiento.PacienteId);
            return View(planTratamiento);
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
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Email", planTratamiento.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Direccion", planTratamiento.PacienteId);
            return View(planTratamiento);
        }

        // POST: PlanTratamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FechaCreacion,Observaciones,PacienteId,OdontologoId")] PlanTratamiento planTratamiento)
        {
            if (id != planTratamiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planTratamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanTratamientoExists(planTratamiento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Email", planTratamiento.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Direccion", planTratamiento.PacienteId);
            return View(planTratamiento);
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
