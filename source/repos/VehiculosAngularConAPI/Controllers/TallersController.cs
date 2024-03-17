using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosAngularConAPI.Models;

namespace VehiculosAngularConAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallersController : ControllerBase
    {
        private readonly mantvehContext _context;

        public TallersController(mantvehContext context)
        {
            _context = context;
        }

        // GET: api/Tallers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taller>>> GetTallers()
        {
          if (_context.Tallers == null)
          {
              return NotFound();
          }
            return await _context.Tallers.ToListAsync();
        }

        // GET: api/Tallers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taller>> GetTaller(int id)
        {
          if (_context.Tallers == null)
          {
              return NotFound();
          }
            var taller = await _context.Tallers.FindAsync(id);

            if (taller == null)
            {
                return NotFound();
            }

            return taller;
        }

        // PUT: api/Tallers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaller(int id, Taller taller)
        {
            if (id != taller.IdTaller)
            {
                return BadRequest();
            }

            _context.Entry(taller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TallerExists(id))
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

        // POST: api/Tallers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taller>> PostTaller(Taller taller)
        {
          if (_context.Tallers == null)
          {
              return Problem("Entity set 'mantvehContext.Tallers'  is null.");
          }
            _context.Tallers.Add(taller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaller", new { id = taller.IdTaller }, taller);
        }

        // DELETE: api/Tallers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaller(int id)
        {
            if (_context.Tallers == null)
            {
                return NotFound();
            }
            var taller = await _context.Tallers.FindAsync(id);
            if (taller == null)
            {
                return NotFound();
            }

            _context.Tallers.Remove(taller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TallerExists(int id)
        {
            return (_context.Tallers?.Any(e => e.IdTaller == id)).GetValueOrDefault();
        }
    }
}
