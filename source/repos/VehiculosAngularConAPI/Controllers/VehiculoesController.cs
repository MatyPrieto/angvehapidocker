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
    public class VehiculoesController : ControllerBase
    {
        private readonly mantvehContext _context;

        public VehiculoesController(mantvehContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
          if (_context.Vehiculos == null)
          {
              return NotFound();
          }
            return await _context.Vehiculos.ToListAsync();
        }

        // GET: api/Vehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(string id)
        {
          if (_context.Vehiculos == null)
          {
              return NotFound();
          }
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // PUT: api/Vehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(string id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Patente)
            {
                return BadRequest();
            }

            _context.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
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

        // POST: api/Vehiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
          if (_context.Vehiculos == null)
          {
              return Problem("Entity set 'mantvehContext.Vehiculos'  is null.");
          }
            _context.Vehiculos.Add(vehiculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VehiculoExists(vehiculo.Patente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.Patente }, vehiculo);
        }

        // DELETE: api/Vehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(string id)
        {
            if (_context.Vehiculos == null)
            {
                return NotFound();
            }
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(string id)
        {
            return (_context.Vehiculos?.Any(e => e.Patente == id)).GetValueOrDefault();
        }
    }
}
