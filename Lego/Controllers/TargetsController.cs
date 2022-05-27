using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lego.Models;

namespace Lego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetsController : ControllerBase
    {
        private readonly LegoAPIContext _context;

        public TargetsController(LegoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Targets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Target>>> GetTargets()
        {
          if (_context.Targets == null)
          {
              return NotFound();
          }
            return await _context.Targets.ToListAsync();
        }

        // GET: api/Targets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Target>> GetTarget(int id)
        {
          if (_context.Targets == null)
          {
              return NotFound();
          }
            var target = await _context.Targets.FindAsync(id);

            if (target == null)
            {
                return NotFound();
            }

            return target;
        }

        // PUT: api/Targets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarget(int id, Target target)
        {
            if (id != target.Id)
            {
                return BadRequest();
            }

            _context.Entry(target).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TargetExists(id))
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

        // POST: api/Targets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Target>> PostTarget(Target target)
        {
          if (_context.Targets == null)
          {
              return Problem("Entity set 'LegoAPIContext.Targets'  is null.");
          }
            _context.Targets.Add(target);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarget", new { id = target.Id }, target);
        }

        // DELETE: api/Targets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarget(int id)
        {
            if (_context.Targets == null)
            {
                return NotFound();
            }
            var target = await _context.Targets.FindAsync(id);
            if (target == null)
            {
                return NotFound();
            }

            _context.Targets.Remove(target);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TargetExists(int id)
        {
            return (_context.Targets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
