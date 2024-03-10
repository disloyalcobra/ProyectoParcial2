using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoParcial2.Data;
using ProyectoParcial2.Data.Entities;

namespace ProyectoParcial2.Controllers
{
    public class PatientDiseasesController : Controller
    {
        private readonly DataContext _context;

        public PatientDiseasesController(DataContext context)
        {
            _context = context;
        }

        // GET: PatientDiseases
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.PatientDiseases.Include(p => p.Disease).Include(p => p.Patient);
            return View(await dataContext.ToListAsync());
        }

        // GET: PatientDiseases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDisease = await _context.PatientDiseases
                .Include(p => p.Disease)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientDisease == null)
            {
                return NotFound();
            }

            return View(patientDisease);
        }

        // GET: PatientDiseases/Create
        public IActionResult Create()
        {
            ViewData["DiseaseId"] = new SelectList(_context.Diseases, "Id", "DiseaseDescription");
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "Adress");
            return View();
        }

        // POST: PatientDiseases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,DiseaseId")] PatientDisease patientDisease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientDisease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiseaseId"] = new SelectList(_context.Diseases, "Id", "DiseaseDescription", patientDisease.DiseaseId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "Adress", patientDisease.PatientId);
            return View(patientDisease);
        }

        // GET: PatientDiseases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDisease = await _context.PatientDiseases.FindAsync(id);
            if (patientDisease == null)
            {
                return NotFound();
            }
            ViewData["DiseaseId"] = new SelectList(_context.Diseases, "Id", "DiseaseDescription", patientDisease.DiseaseId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "Adress", patientDisease.PatientId);
            return View(patientDisease);
        }

        // POST: PatientDiseases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,DiseaseId")] PatientDisease patientDisease)
        {
            if (id != patientDisease.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientDisease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDiseaseExists(patientDisease.Id))
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
            ViewData["DiseaseId"] = new SelectList(_context.Diseases, "Id", "DiseaseDescription", patientDisease.DiseaseId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "Adress", patientDisease.PatientId);
            return View(patientDisease);
        }

        // GET: PatientDiseases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDisease = await _context.PatientDiseases
                .Include(p => p.Disease)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientDisease == null)
            {
                return NotFound();
            }

            return View(patientDisease);
        }

        // POST: PatientDiseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientDisease = await _context.PatientDiseases.FindAsync(id);
            if (patientDisease != null)
            {
                _context.PatientDiseases.Remove(patientDisease);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientDiseaseExists(int id)
        {
            return _context.PatientDiseases.Any(e => e.Id == id);
        }
    }
}
