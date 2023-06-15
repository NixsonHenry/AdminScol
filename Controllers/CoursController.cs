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
    public class CoursController : Controller
    {
        private readonly AdminScolDbContext _context;

        public CoursController(AdminScolDbContext context)
        {
            _context = context;
        }

        // GET: Cours
        public async Task<IActionResult> Index()
        {
            var adminScolDbContext = _context.Cours
                .Include(c => c.Classe)
                .Include(c => c.CourProfesseurs)
                .ThenInclude(cp => cp.Professeur);

            return View(await adminScolDbContext.ToListAsync());
        }

        // GET: Cours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cours
                .Include(c => c.Classe)
                .Include(c => c.CourProfesseurs)
                .ThenInclude(cp => cp.Professeur)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // GET: Cours/Create
        public IActionResult Create()
        {
            ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["SelectedProfesseurIds"] = new MultiSelectList(_context.Professeurs, "Id", "Nom");
            return View();
        }

        // POST: Cours/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomCours,Description,ClasseId,SelectedProfesseurIds")] Cour cour)
        {
            if (ModelState.IsValid)
            {
                cour.CourProfesseurs = new List<CourProfesseur>();

                if (cour.SelectedProfesseurIds != null)
                {
                    foreach (var professeurId in cour.SelectedProfesseurIds)
                    {
                        var courProfesseur = new CourProfesseur
                        {
                            CourId = cour.Id,
                            ProfesseurId = professeurId
                        };
                        cour.CourProfesseurs.Add(courProfesseur);
                    }
                }

                _context.Add(cour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Id", cour.ClasseId);
            ViewData["SelectedProfesseurIds"] = new MultiSelectList(_context.Professeurs, "Id", "Nom", cour.SelectedProfesseurIds);
            return View(cour);
        }

        // GET: Cours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cours
                .Include(c => c.Classe)
                .Include(c => c.CourProfesseurs)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cour == null)
            {
                return NotFound();
            }

            ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Id", cour.ClasseId);
            ViewData["SelectedProfesseurIds"] = new MultiSelectList(_context.Professeurs, "Id", "Nom", cour.CourProfesseurs.Select(cp => cp.ProfesseurId));
            return View(cour);
        }

        // POST: Cours/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomCours,Description,ClasseId,SelectedProfesseurIds")] Cour cour)
        {
            if (id != cour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingCour = await _context.Cours
                        .Include(c => c.CourProfesseurs)
                        .FirstOrDefaultAsync(c => c.Id == id);

                    if (existingCour == null)
                    {
                        return NotFound();
                    }

                    existingCour.NomCours = cour.NomCours;
                    existingCour.Description = cour.Description;
                    existingCour.ClasseId = cour.ClasseId;

                    // Remove existing CourProfesseur entries
                    _context.CourProfesseurs.RemoveRange(existingCour.CourProfesseurs);

                    // Add updated CourProfesseur entries
                    existingCour.CourProfesseurs = new List<CourProfesseur>();
                    if (cour.SelectedProfesseurIds != null)
                    {
                        foreach (var professeurId in cour.SelectedProfesseurIds)
                        {
                            var courProfesseur = new CourProfesseur
                            {
                                CourId = cour.Id,
                                ProfesseurId = professeurId
                            };
                            existingCour.CourProfesseurs.Add(courProfesseur);
                        }
                    }

                    _context.Update(existingCour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourExists(cour.Id))
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

            ViewData["ClasseId"] = new SelectList(_context.Classes, "Id", "Id", cour.ClasseId);
            ViewData["SelectedProfesseurIds"] = new MultiSelectList(_context.Professeurs, "Id", "Nom", cour.SelectedProfesseurIds);
            return View(cour);
        }

        // GET: Cours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cours
                .Include(c => c.Classe)
                .Include(c => c.CourProfesseurs)
                .ThenInclude(cp => cp.Professeur)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cour = await _context.Cours.FindAsync(id);
            if (cour == null)
            {
                return NotFound();
            }

            _context.Cours.Remove(cour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourExists(int id)
        {
            return _context.Cours.Any(e => e.Id == id);
        }
    }
}
