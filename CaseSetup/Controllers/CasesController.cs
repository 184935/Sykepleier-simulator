using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaseSetup.Data;
using SharedLibrary.Models;

namespace CaseSetup.Controllers
{
    public class CasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Case.Include(@case => @case.MedicalHistory).Include(@case => @case.Patient).Include(@case => @case.Vitals);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case
                .Include(@case => @case.MedicalHistory)
                .Include(@case => @case.Patient)
                .Include(@case => @case.Vitals)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // GET: Cases/Create
        public IActionResult Create()
        {
            ViewData["MedicalHistoryId"] = new SelectList(_context.Set<MedicalHistory>(), "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Gender");
            ViewData["VitalsId"] = new SelectList(_context.Set<Vitals>(), "Id", "Id");
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,VitalsId,MedicalHistoryId,Editable,DifficultyInt,Difficulty")] Case @case)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicalHistoryId"] = new SelectList(_context.Set<MedicalHistory>(), "Id", "Id", @case.MedicalHistoryId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Gender", @case.PatientId);
            ViewData["VitalsId"] = new SelectList(_context.Set<Vitals>(), "Id", "Id", @case.VitalsId);
            return View(@case);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }
            ViewData["MedicalHistoryId"] = new SelectList(_context.Set<MedicalHistory>(), "Id", "Id", @case.MedicalHistoryId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Gender", @case.PatientId);
            ViewData["VitalsId"] = new SelectList(_context.Set<Vitals>(), "Id", "Id", @case.VitalsId);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,VitalsId,MedicalHistoryId,Editable,DifficultyInt,Difficulty")] Case @case)
        {
            if (id != @case.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(@case.Id))
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
            ViewData["MedicalHistoryId"] = new SelectList(_context.Set<MedicalHistory>(), "Id", "Id", @case.MedicalHistoryId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Gender", @case.PatientId);
            ViewData["VitalsId"] = new SelectList(_context.Set<Vitals>(), "Id", "Id", @case.VitalsId);
            return View(@case);
        }

        // GET: Cases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case
                .Include(@case => @case.MedicalHistory)
                .Include(@case => @case.Patient)
                .Include(@case => @case.Vitals)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @case = await _context.Case.FindAsync(id);
            if (@case != null)
            {
                _context.Case.Remove(@case);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseExists(int id)
        {
            return _context.Case.Any(e => e.Id == id);
        }
    }
}
