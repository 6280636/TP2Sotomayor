using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuliePro.Data;
using JuliePro.Models;

namespace JuliePro.Controllers
{
    public class SpecialitiesController : Controller
    {
        private readonly JulieProDbContext _context;

        public SpecialitiesController(JulieProDbContext context)
        {
            _context = context;
        }

        // GET: Specialities
        public async Task<IActionResult> Index()
        {
              return _context.Speciality != null ? 
                          View(await _context.Speciality.ToListAsync()) :
                          Problem("Entity set 'JulieProDbContext.Speciality'  is null.");
        }

        // GET: Specialities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Speciality == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // GET: Specialities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Speciality speciality)
        {
            ModelState.Remove("Trainers");
            if (ModelState.IsValid)
            {
                _context.Add(speciality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speciality);
        }

        // GET: Specialities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Speciality == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }
            return View(speciality);
        }

        // POST: Specialities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Speciality speciality)
        {
            if (id != speciality.Id)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(speciality.Trainers));

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speciality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialityExists(speciality.Id))
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
            return View(speciality);
        }

        // GET: Specialities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Speciality == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // POST: Specialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Speciality == null)
            {
                return Problem("Entity set 'JulieProDbContext.Speciality'  is null.");
            }
            var speciality = await _context.Speciality.Include(s => s.Trainers).FirstOrDefaultAsync(s => s.Id == id);

            if (speciality != null)
            {
                if (speciality.Trainers.Count() > 0)
                {
                    ModelState.AddModelError("SpecialityInUse", "There's at least one Trainer with that speciality.");
                    return View(speciality);
                }
                else
                {
                    _context.Speciality.Remove(speciality);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SpecialityExists(int id)
        {
          return (_context.Speciality?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
