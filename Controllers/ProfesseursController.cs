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
    public class ProfesseursController : Controller
    {
        private readonly AdminScolDbContext _context;

        public ProfesseursController(AdminScolDbContext context)
        {
            _context = context;
        }

        // GET: Professeurs
        public async Task<IActionResult> Index()
        {
              return _context.Professeur != null ? 
                          View(await _context.Professeur.ToListAsync()) :
                          Problem("Entity set 'AdminScolDbContext.Professeur'  is null.");
        }

        // GET: Professeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Professeur == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professeur == null)
            {
                return NotFound();
            }

            return View(professeur);
        }

        // GET: Professeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Adresse,Phone,Sexe,Email")] Professeur professeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professeur);
        }

        // GET: Professeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Professeur == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeur.FindAsync(id);
            if (professeur == null)
            {
                return NotFound();
            }
            return View(professeur);
        }

        // POST: Professeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Adresse,Phone,Sexe,Email")] Professeur professeur)
        {
            if (id != professeur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesseurExists(professeur.Id))
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
            return View(professeur);
        }

        // GET: Professeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Professeur == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professeur == null)
            {
                return NotFound();
            }

            return View(professeur);
        }

        // POST: Professeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Professeur == null)
            {
                return Problem("Entity set 'AdminScolDbContext.Professeur'  is null.");
            }
            var professeur = await _context.Professeur.FindAsync(id);
            if (professeur != null)
            {
                _context.Professeur.Remove(professeur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesseurExists(int id)
        {
          return (_context.Professeur?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
