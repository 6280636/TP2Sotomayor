﻿using JuliePro.Data;
using JuliePro.Models;
using JuliePro.Models.ViewModels;
using JuliePro.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace JuliePro.Controllers
{
    public class TrainersController : Controller
    {
        private ITrainerServices _serviceT { get; set; }
        private readonly JulieProDbContext _context;
        private readonly IStringLocalizer<TrainersController> _localizer;

        public TrainersController(JulieProDbContext context, IStringLocalizer<TrainersController> localizer,ITrainerServices servicesT)
        {
            _context = context;
            _localizer = localizer;
            _serviceT = servicesT;

        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = _localizer["IndexTitle"];
            
            var trainers = await _serviceT.GetAllAsync();
            return View(trainers);
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trainer = await _serviceT.GetByIdAsync((int)id);
           
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // GET: Trainers/Upsert
        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                ViewBag.Title = _localizer["CreateTitle"];
                ViewData["SpecialityId"] = new SelectList(_context.Speciality, "Id", "Name");

                return View(new Trainer());
            }
            else
            {
                ViewBag.Title = _localizer["EditTitle"];

                var trainer = await _serviceT.GetByIdAsync((int)id);

                if (trainer == null)
                {
                    return NotFound();
                }
                ViewData["SpecialityId"] = new SelectList(_context.Speciality, "Id", "Name", trainer.SpecialityId);
                return View(trainer);
            }

           
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([Bind("Id,FirstName,LastName,Email,Photo,Description,SpecialityId")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                if (trainer.Id == 0)
                {
                    
                    await _serviceT.CreateAsync(trainer);
                    TempData["Success"] = $"{trainer.LastName} trainer added";
                }
                else
                {                   

                    try
                    {
                        await _serviceT.EditAsync(trainer);

                        TempData["Success"] = $"{trainer.LastName} trainer update";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TrainerExists(trainer.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }                
                return this.RedirectToAction(nameof(Index));
            }
            ViewData["SpecialityId"] = new SelectList(_context.Speciality, "Id", "Name", trainer.SpecialityId);
            return View(trainer);
        }      

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _serviceT.GetByIdAsync((int)id);

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

            var trainer = await _serviceT.GetByIdAsync(id);

            if (trainer != null)
            {              

                await _serviceT.DeleteAsync(id);
            }
            
            
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(int id)
        {
          return (_context.Trainer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
