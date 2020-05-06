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
    public class MotivosController : ControllerBase
    {
        private readonly OrdenContext _context;

        public MotivosController(OrdenContext context)
        {
            _context = context;
        }

        // GET: api/Motivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motivo>>> GetMotivo()
        {
            return await _context.Motivo.ToListAsync();
        }

        // GET: api/Motivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motivo>> GetMotivo(int id)
        {
            var motivo = await _context.Motivo.FindAsync(id);

            if (motivo == null)
            {
                return NotFound();
            }

            return motivo;
        }

        // PUT: api/Motivos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivo(int id, Motivo motivo)
        {
            if (id != motivo.IdMotivo)
            {
                return BadRequest();
            }

            _context.Entry(motivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivoExists(id))
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

        // POST: api/Motivos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Motivo>> PostMotivo(Motivo motivo)
        {
            _context.Motivo.Add(motivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivo", new { id = motivo.IdMotivo }, motivo);
        }

        // DELETE: api/Motivos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Motivo>> DeleteMotivo(int id)
        {
            var motivo = await _context.Motivo.FindAsync(id);
            if (motivo == null)
            {
                return NotFound();
            }

            _context.Motivo.Remove(motivo);
            await _context.SaveChangesAsync();

            return motivo;
        }

        private bool MotivoExists(int id)
        {
            return _context.Motivo.Any(e => e.IdMotivo == id);
        }
    }
}
