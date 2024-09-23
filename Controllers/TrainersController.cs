using JuliePro.Data;
using JuliePro.Models;
using JuliePro.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace JuliePro.Controllers
{
    public class TrainersController : Controller
    {
        private readonly JulieProDbContext _context;
        private readonly IStringLocalizer<TrainersController> _localizer;

        public TrainersController(JulieProDbContext context, IStringLocalizer<TrainersController> localizer)
        {
            _context = context;
            _localizer = localizer;

        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = _localizer["IndexTitle"];
            var trainers = _context.Trainer.Include(t => t.Speciality).OrderBy(t => t.FirstName).ThenBy(t => t.LastName);            
            return View(await trainers.ToListAsync());
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer
                .Include(t => t.Speciality)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // GET: Trainers/Upsert
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                ViewBag.Title = _localizer["CreateTitle"];
                return View(new Trainer());
            }
            else
            {
                ViewBag.Title = _localizer["EditTitle"];
                return View (_context.Trainer.Find(id));
            }

            //ViewData["SpecialityId"] = new SelectList(_context.Speciality, "Id", "Name");
            //return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                if (trainer.Id == 0)
                {
                    _context.Trainer.Add(trainer);
                    TempData["Success"] = $"{trainer.LastName} trainer added";
                }
                else
                {
                    _context.Trainer.Update(trainer);
                    TempData["Success"] = $"{trainer.LastName} trainer update";
                }

                await _context.SaveChangesAsync();
                return this.RedirectToAction(nameof(Index));
            }
            //ViewData["SpecialityId"] = new SelectList(_context.Speciality, "Id", "Name", trainer.SpecialityId);
            return View(trainer);
        }

        // GET: Trainers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var trainer = await _context.Trainer.FindAsync(id);
        //    if (trainer == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["SpecialityId"] = new SelectList(_context.Speciality, "Id", "Name", trainer.SpecialityId);
        //    return View(trainer);
        //}

        //// POST: Trainers/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Photo,SpecialityId")] Trainer trainer)
        //{
        //    if (id != trainer.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(trainer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TrainerExists(trainer.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["SpecialityId"] = new SelectList(_context.Speciality, "Id", "Name", trainer.SpecialityId);
        //    return View(trainer);
        //}

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer
                .Include(t => t.Speciality)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainer = await _context.Trainer.FindAsync(id);
            if (trainer != null)
            {
                _context.Trainer.Remove(trainer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(int id)
        {
          return (_context.Trainer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
