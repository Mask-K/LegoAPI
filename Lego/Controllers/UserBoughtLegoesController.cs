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
    public class UserBoughtLegoesController : ControllerBase
    {
        private readonly LegoAPIContext _context;

        public UserBoughtLegoesController(LegoAPIContext context)
        {
            _context = context;
        }

        // GET: api/UserBoughtLegoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBoughtLego>>> GetUBLs()
        {
          if (_context.UBLs == null)
          {
              return NotFound();
          }
            return await _context.UBLs.ToListAsync();
        }

        // GET: api/UserBoughtLegoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBoughtLego>> GetUserBoughtLego(int id)
        {
          if (_context.UBLs == null)
          {
              return NotFound();
          }
            var userBoughtLego = await _context.UBLs.FindAsync(id);

            if (userBoughtLego == null)
            {
                return NotFound();
            }

            return userBoughtLego;
        }

        // PUT: api/UserBoughtLegoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBoughtLego(int id, UserBoughtLego userBoughtLego)
        {
            if (id != userBoughtLego.Id)
            {
                return BadRequest();
            }

            _context.Entry(userBoughtLego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBoughtLegoExists(id))
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

        // POST: api/UserBoughtLegoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserBoughtLego>> PostUserBoughtLego(UserBoughtLego userBoughtLego)
        {
          if (_context.UBLs == null)
          {
              return Problem("Entity set 'LegoAPIContext.UBLs'  is null.");
          }
            _context.UBLs.Add(userBoughtLego);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBoughtLego", new { id = userBoughtLego.Id }, userBoughtLego);
        }

        // DELETE: api/UserBoughtLegoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserBoughtLego(int id)
        {
            if (_context.UBLs == null)
            {
                return NotFound();
            }
            var userBoughtLego = await _context.UBLs.FindAsync(id);
            if (userBoughtLego == null)
            {
                return NotFound();
            }

            _context.UBLs.Remove(userBoughtLego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserBoughtLegoExists(int id)
        {
            return (_context.UBLs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
