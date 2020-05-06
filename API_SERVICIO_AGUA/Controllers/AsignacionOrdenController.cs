
using API_SERVICIO_AGUA.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_SERVICIO_AGUA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_SERVICIO_AGUA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionOrdenController:ControllerBase
    {
        private readonly OrdenContext _context;

        public AsignacionOrdenController(OrdenContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes()
        {
            return await _context.Orden.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orden>> GetOrden(int id)
        {
            var orden = await _context.Orden.FindAsync(id);

            if (orden == null)
            {
                return NotFound();
            }

            return orden;
        }


        [HttpGet("historial/{id}")]
        public async Task<ActionResult<IEnumerable<Orden>>>  GetHistorial(int id)
        {
            var ordenes = await _context.Orden.
                Where(x=>x.IdUsuarioDespacha==id).ToListAsync();

            if (ordenes == null)
            {
                return NotFound();
            }

            return ordenes;
        }
        [HttpPost]
        public async Task<ActionResult<Orden>> PostAsignacion(Orden orden)
        {
            orden.Estado = 'A';
            _context.Orden.Add(orden);
            await _context.SaveChangesAsync();

             return CreatedAtAction("GetOrden", new { id = orden.IdOrden }, orden);
        }



    }
}
