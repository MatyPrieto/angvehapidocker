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
    public class VehiculoCarroceriumsController : ControllerBase
    {
        private readonly mantvehContext _context;

        public VehiculoCarroceriumsController(mantvehContext context)
        {
            _context = context;
        }

        // GET: api/VehiculoCarroceriums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoCarrocerium>>> GetVehiculoCarroceria()
        {
          if (_context.VehiculoCarroceria == null)
          {
              return NotFound();
          }
            return await _context.VehiculoCarroceria.ToListAsync();
        }

        // GET: api/VehiculoCarroceriums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoCarrocerium>> GetVehiculoCarrocerium(int id)
        {
          if (_context.VehiculoCarroceria == null)
          {
              return NotFound();
          }
            var vehiculoCarrocerium = await _context.VehiculoCarroceria.FindAsync(id);

            if (vehiculoCarrocerium == null)
            {
                return NotFound();
            }

            return vehiculoCarrocerium;
        }

        // PUT: api/VehiculoCarroceriums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculoCarrocerium(int id, VehiculoCarrocerium vehiculoCarrocerium)
        {
            if (id != vehiculoCarrocerium.IdCarroceria)
            {
                return BadRequest();
            }

            _context.Entry(vehiculoCarrocerium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoCarroceriumExists(id))
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

        // POST: api/VehiculoCarroceriums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehiculoCarrocerium>> PostVehiculoCarrocerium(VehiculoCarrocerium vehiculoCarrocerium)
        {
          if (_context.VehiculoCarroceria == null)
          {
              return Problem("Entity set 'mantvehContext.VehiculoCarroceria'  is null.");
          }
            _context.VehiculoCarroceria.Add(vehiculoCarrocerium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculoCarrocerium", new { id = vehiculoCarrocerium.IdCarroceria }, vehiculoCarrocerium);
        }

        // DELETE: api/VehiculoCarroceriums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculoCarrocerium(int id)
        {
            if (_context.VehiculoCarroceria == null)
            {
                return NotFound();
            }
            var vehiculoCarrocerium = await _context.VehiculoCarroceria.FindAsync(id);
            if (vehiculoCarrocerium == null)
            {
                return NotFound();
            }

            _context.VehiculoCarroceria.Remove(vehiculoCarrocerium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoCarroceriumExists(int id)
        {
            return (_context.VehiculoCarroceria?.Any(e => e.IdCarroceria == id)).GetValueOrDefault();
        }
    }
}
