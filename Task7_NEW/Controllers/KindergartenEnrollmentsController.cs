using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task7_NEW.Models;

namespace Task7_NEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindergartenEnrollmentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public KindergartenEnrollmentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/KindergartenEnrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KindergartenEnrollment>>> GetKindergartenEnrollment()
        {
          if (_context.KindergartenEnrollment == null)
          {
              return NotFound();
          }
            return await _context.KindergartenEnrollment.ToListAsync();
        }

        // GET: api/KindergartenEnrollments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KindergartenEnrollment>> GetKindergartenEnrollment(int id)
        {
          if (_context.KindergartenEnrollment == null)
          {
              return NotFound();
          }
            var kindergartenEnrollment = await _context.KindergartenEnrollment.FindAsync(id);

            if (kindergartenEnrollment == null)
            {
                return NotFound();
            }

            return kindergartenEnrollment;
        }

        // PUT: api/KindergartenEnrollments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKindergartenEnrollment(int id, KindergartenEnrollment kindergartenEnrollment)
        {
            if (id != kindergartenEnrollment.Id)
            {
                return BadRequest();
            }

            _context.Entry(kindergartenEnrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KindergartenEnrollmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/KindergartenEnrollments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KindergartenEnrollment>> PostKindergartenEnrollment(KindergartenEnrollment kindergartenEnrollment)
        {
          if (_context.KindergartenEnrollment == null)
          {
              return Problem("Entity set 'ApplicationContext.KindergartenEnrollment'  is null.");
          }
            _context.KindergartenEnrollment.Add(kindergartenEnrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKindergartenEnrollment", new { id = kindergartenEnrollment.Id }, kindergartenEnrollment);
        }

        // DELETE: api/KindergartenEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKindergartenEnrollment(int id)
        {
            if (_context.KindergartenEnrollment == null)
            {
                return NotFound();
            }
            var kindergartenEnrollment = await _context.KindergartenEnrollment.FindAsync(id);
            if (kindergartenEnrollment == null)
            {
                return NotFound();
            }

            _context.KindergartenEnrollment.Remove(kindergartenEnrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KindergartenEnrollmentExists(int id)
        {
            return (_context.KindergartenEnrollment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
