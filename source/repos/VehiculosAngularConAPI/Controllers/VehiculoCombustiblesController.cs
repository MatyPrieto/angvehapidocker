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
    public class VehiculoCombustiblesController : ControllerBase
    {
        private readonly mantvehContext _context;

        public VehiculoCombustiblesController(mantvehContext context)
        {
            _context = context;
        }

        // GET: api/VehiculoCombustibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoCombustible>>> GetVehiculoCombustibles()
        {
          if (_context.VehiculoCombustibles == null)
          {
              return NotFound();
          }
            return await _context.VehiculoCombustibles.ToListAsync();
        }

        // GET: api/VehiculoCombustibles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoCombustible>> GetVehiculoCombustible(int id)
        {
          if (_context.VehiculoCombustibles == null)
          {
              return NotFound();
          }
            var vehiculoCombustible = await _context.VehiculoCombustibles.FindAsync(id);

            if (vehiculoCombustible == null)
            {
                return NotFound();
            }

            return vehiculoCombustible;
        }

        // PUT: api/VehiculoCombustibles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculoCombustible(int id, VehiculoCombustible vehiculoCombustible)
        {
            if (id != vehiculoCombustible.IdCombustible)
            {
                return BadRequest();
            }

            _context.Entry(vehiculoCombustible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoCombustibleExists(id))
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

        // POST: api/VehiculoCombustibles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehiculoCombustible>> PostVehiculoCombustible(VehiculoCombustible vehiculoCombustible)
        {
          if (_context.VehiculoCombustibles == null)
          {
              return Problem("Entity set 'mantvehContext.VehiculoCombustibles'  is null.");
          }
            _context.VehiculoCombustibles.Add(vehiculoCombustible);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculoCombustible", new { id = vehiculoCombustible.IdCombustible }, vehiculoCombustible);
        }

        // DELETE: api/VehiculoCombustibles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculoCombustible(int id)
        {
            if (_context.VehiculoCombustibles == null)
            {
                return NotFound();
            }
            var vehiculoCombustible = await _context.VehiculoCombustibles.FindAsync(id);
            if (vehiculoCombustible == null)
            {
                return NotFound();
            }

            _context.VehiculoCombustibles.Remove(vehiculoCombustible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoCombustibleExists(int id)
        {
            return (_context.VehiculoCombustibles?.Any(e => e.IdCombustible == id)).GetValueOrDefault();
        }
    }
}
