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
    public class PacientesController : Controller
    {
        private readonly AppDbContext _context;

        public PacientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pacientes.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,Rut,Telefono,Email,Direccion")] Paciente paciente)
        {
            // — chequeo duplicados —
            if (_context.Pacientes.Any(p => p.Rut == paciente.Rut))
                ModelState.AddModelError("Rut", "Ya existe un paciente con ese RUT.");

            if (_context.Pacientes.Any(p => p.Email == paciente.Email))
                ModelState.AddModelError("Email", "Ya existe un paciente con ese correo.");

            if (!ModelState.IsValid)
            {
                // tus logs de consola quedan igual si quieres
                return View(paciente);
            }

            paciente.Id = Guid.NewGuid();
            _context.Add(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nombre,Apellidos,Rut,Telefono,Email,Direccion")] Paciente paciente)
        {
            if (id != paciente.Id)
                return NotFound();

            // — chequeo duplicados excluyendo este registro —
            if (_context.Pacientes.Any(p => p.Rut == paciente.Rut && p.Id != id))
                ModelState.AddModelError("Rut", "Ya existe otro paciente con ese RUT.");

            if (_context.Pacientes.Any(p => p.Email == paciente.Email && p.Id != id))
                ModelState.AddModelError("Email", "Ya existe otro paciente con ese correo.");

            if (!ModelState.IsValid)
                return View(paciente);

            try
            {
                _context.Update(paciente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(paciente.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(Guid id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }
    }
}
