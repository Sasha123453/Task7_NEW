using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task7_NEW.Models;

namespace Task7_NEW.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationContext _context;

        public EnrollmentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
              return _context.KindergartenEnrollment != null ? 
                          View(await _context.KindergartenEnrollment.ToListAsync()) :
                          Problem("Entity set 'ApplicationContext.KindergartenEnrollment'  is null.");
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KindergartenEnrollment == null)
            {
                return NotFound();
            }

            var kindergartenEnrollment = await _context.KindergartenEnrollment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kindergartenEnrollment == null)
            {
                return NotFound();
            }

            return View(kindergartenEnrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SecondName,LastName,PhoneNumber,BirthDate")] KindergartenEnrollment kindergartenEnrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kindergartenEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kindergartenEnrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KindergartenEnrollment == null)
            {
                return NotFound();
            }

            var kindergartenEnrollment = await _context.KindergartenEnrollment.FindAsync(id);
            if (kindergartenEnrollment == null)
            {
                return NotFound();
            }
            return View(kindergartenEnrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SecondName,LastName,PhoneNumber,BirthDate")] KindergartenEnrollment kindergartenEnrollment)
        {
            if (id != kindergartenEnrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kindergartenEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindergartenEnrollmentExists(kindergartenEnrollment.Id))
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
            return View(kindergartenEnrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KindergartenEnrollment == null)
            {
                return NotFound();
            }

            var kindergartenEnrollment = await _context.KindergartenEnrollment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kindergartenEnrollment == null)
            {
                return NotFound();
            }

            return View(kindergartenEnrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KindergartenEnrollment == null)
            {
                return Problem("Entity set 'ApplicationContext.KindergartenEnrollment'  is null.");
            }
            var kindergartenEnrollment = await _context.KindergartenEnrollment.FindAsync(id);
            if (kindergartenEnrollment != null)
            {
                _context.KindergartenEnrollment.Remove(kindergartenEnrollment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindergartenEnrollmentExists(int id)
        {
          return (_context.KindergartenEnrollment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
