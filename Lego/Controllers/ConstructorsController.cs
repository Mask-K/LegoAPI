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
    public class ConstructorsController : ControllerBase
    {
        private readonly LegoAPIContext _context;

        public ConstructorsController(LegoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Constructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Constructor>>> GetConstructor()
        {
          if (_context.Constructors == null)
          {
              return NotFound();
          }
            return await _context.Constructors.ToListAsync();
        }

        // GET: api/Constructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Constructor>> GetConstructor(int id)
        {
          if (_context.Constructors == null)
          {
              return NotFound();
          }
            var constructor = await _context.Constructors.FindAsync(id);

            if (constructor == null)
            {
                return NotFound();
            }

            return constructor;
        }

        // PUT: api/Constructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructor(int id, Constructor constructor)
        {
            if (id != constructor.Id)
            {
                return BadRequest();
            }

            _context.Entry(constructor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructorExists(id))
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

        // POST: api/Constructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Constructor>> PostConstructor(Constructor constructor)
        {
          if (_context.Constructors == null)
          {
              return Problem("Entity set 'LegoAPIContext.Constructor'  is null.");
          }
            _context.Constructors.Add(constructor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructor", new { id = constructor.Id }, constructor);
        }

        // DELETE: api/Constructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructor(int id)
        {
            if (_context.Constructors == null)
            {
                return NotFound();
            }
            var constructor = await _context.Constructors.FindAsync(id);
            if (constructor == null)
            {
                return NotFound();
            }

            _context.Constructors.Remove(constructor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructorExists(int id)
        {
            return (_context.Constructors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
