using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_SERVICIO_AGUA.Data;
using API_SERVICIO_AGUA.Models;

namespace API_SERVICIO_AGUA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidoresController : ControllerBase
    {
        private readonly OrdenContext _context;

        public MedidoresController(OrdenContext context)
        {
            _context = context;
        }

        // GET: api/Medidores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medidor>>> GetMedidor()
        {
            return await _context.Medidor.ToListAsync();
        }

        // GET: api/Medidores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medidor>> GetMedidor(int id)
        {
            var medidor = await _context.Medidor.FindAsync(id);

            if (medidor == null)
            {
                return NotFound();
            }

            return medidor;
        }

        // PUT: api/Medidores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedidor(int id, Medidor medidor)
        {
            if (id != medidor.IdMedidor)
            {
                return BadRequest();
            }

            _context.Entry(medidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedidorExists(id))
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

        // POST: api/Medidores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medidor>> PostMedidor(Medidor medidor)
        {
            _context.Medidor.Add(medidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedidor", new { id = medidor.IdMedidor }, medidor);
        }

        // DELETE: api/Medidores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medidor>> DeleteMedidor(int id)
        {
            var medidor = await _context.Medidor.FindAsync(id);
            if (medidor == null)
            {
                return NotFound();
            }

            _context.Medidor.Remove(medidor);
            await _context.SaveChangesAsync();

            return medidor;
        }

        private bool MedidorExists(int id)
        {
            return _context.Medidor.Any(e => e.IdMedidor == id);
        }
    }
}
