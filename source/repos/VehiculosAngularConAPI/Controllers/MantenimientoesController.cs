﻿using System;
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
    public class MantenimientoesController : ControllerBase
    {
        private readonly mantvehContext _context;

        public MantenimientoesController(mantvehContext context)
        {
            _context = context;
        }

        // GET: api/Mantenimientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> GetMantenimientos()
        {
          if (_context.Mantenimientos == null)
          {
              return NotFound();
          }
            return await _context.Mantenimientos.ToListAsync();
        }

        // GET: api/Mantenimientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mantenimiento>> GetMantenimiento(int id)
        {
          if (_context.Mantenimientos == null)
          {
              return NotFound();
          }
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound();
            }

            return mantenimiento;
        }

        // PUT: api/Mantenimientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMantenimiento(int id, Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.IdMantenimiento)
            {
                return BadRequest();
            }

            _context.Entry(mantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MantenimientoExists(id))
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

        // POST: api/Mantenimientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mantenimiento>> PostMantenimiento(Mantenimiento mantenimiento)
        {
          if (_context.Mantenimientos == null)
          {
              return Problem("Entity set 'mantvehContext.Mantenimientos'  is null.");
          }
            _context.Mantenimientos.Add(mantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMantenimiento", new { id = mantenimiento.IdMantenimiento }, mantenimiento);
        }

        // DELETE: api/Mantenimientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento(int id)
        {
            if (_context.Mantenimientos == null)
            {
                return NotFound();
            }
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null)
            {
                return NotFound();
            }

            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MantenimientoExists(int id)
        {
            return (_context.Mantenimientos?.Any(e => e.IdMantenimiento == id)).GetValueOrDefault();
        }
    }
}
