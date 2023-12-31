﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminScol.Models;
using System.Threading.Channels;


namespace AdminScol.Controllers
{
    public class ClassesController : Controller
    {
        private readonly AdminScolDbContext _context;

        public ClassesController(AdminScolDbContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var adminScolDbContext = _context.Classes.Include(c => c.AnneeAcademique);
            return View(await adminScolDbContext.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes
                .Include(c => c.AnneeAcademique)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            //ViewData["AnneeAcademiqueId"] = new SelectList(_context.AnneeAcademiques, "Id", "Id");
             //Changel AnneeScolaire
            ViewData["AnneeAcademiqueId"] = new SelectList(_context.AnneeAcademiques, "Id", "AnneeScolaire");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Niveau,Section,AnneeAcademiqueId")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnneeAcademiqueId"] = new SelectList(_context.AnneeAcademiques, "Id", "Id", classe.AnneeAcademiqueId);
            return View(classe);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes.FindAsync(id);
            if (classe == null)
            {
                return NotFound();
            }
            ViewData["AnneeAcademiqueId"] = new SelectList(_context.AnneeAcademiques, "Id", "AnneeScolaire");
            //ViewData["AnneeAcademiqueId"] = new SelectList(_context.AnneeAcademiques, "Id", "Id", classe.AnneeAcademiqueId);
            return View(classe);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Niveau,Section,AnneeAcademiqueId")] Classe classe)
        {
            if (id != classe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseExists(classe.Id))
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
            ViewData["AnneeAcademiqueId"] = new SelectList(_context.AnneeAcademiques, "Id", "AnneeScolaire");
            //ViewData["AnneeAcademiqueId"] = new SelectList(_context.AnneeAcademiques, "Id", "Id", classe.AnneeAcademiqueId);
            return View(classe);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes
                .Include(c => c.AnneeAcademique)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'AdminScolDbContext.Classes'  is null.");
            }
            var classe = await _context.Classes.FindAsync(id);
            if (classe != null)
            {
                _context.Classes.Remove(classe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseExists(int id)
        {
          return (_context.Classes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
