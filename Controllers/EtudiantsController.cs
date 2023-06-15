using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminScol.Models;

namespace AdminScol.Controllers
{
    public class EtudiantsController : Controller
    {
        private readonly AdminScolDbContext _context;

        public EtudiantsController(AdminScolDbContext context)
        {
            _context = context;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index()
        {
            var adminScolDbContext = _context.Etudiants.Include(e => e.Classe);
            return View(await adminScolDbContext.ToListAsync());
        }

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants
                .Include(e => e.Classe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // GET: Etudiants/Create
        public IActionResult Create()
        {
            //ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Niveau");
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Sexe,DateNaissance,Adresse,Phone,Email,Occupation,StatutMatrimonial,Maladie,ClasseId")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Id", etudiant.ClasseId);
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            //ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Id", etudiant.ClasseId);
            ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Niveau");
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Sexe,DateNaissance,Adresse,Phone,Email,Occupation,StatutMatrimonial,Maladie,ClasseId")] Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.Id))
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
            ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Id", etudiant.ClasseId);
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants
                .Include(e => e.Classe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Etudiants == null)
            {
                return Problem("Entity set 'AdminScolDbContext.Etudiants'  is null.");
            }
            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant != null)
            {
                _context.Etudiants.Remove(etudiant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
          return (_context.Etudiants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
