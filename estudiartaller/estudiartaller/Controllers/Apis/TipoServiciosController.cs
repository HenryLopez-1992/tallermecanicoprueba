using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using estudiartaller.Data.DDL;
using estudiartaller.Models;

namespace estudiartaller.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServiciosController : ControllerBase
    {
        private readonly estudiartallerContext _context;

        public TipoServiciosController(estudiartallerContext context)
        {
            _context = context;
        }

        // GET: api/TipoServicios
        [HttpGet]
        public IEnumerable<TipoServicio> GetTipoServicio()
        {
            return _context.TipoServicio;
        }

        // GET: api/TipoServicios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoServicio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoServicio = await _context.TipoServicio.FindAsync(id);

            if (tipoServicio == null)
            {
                return NotFound();
            }

            return Ok(tipoServicio);
        }

        // PUT: api/TipoServicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoServicio([FromRoute] int id, [FromBody] TipoServicio tipoServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoServicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoServicioExists(id))
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

        // POST: api/TipoServicios
        [HttpPost]
        public async Task<IActionResult> PostTipoServicio([FromBody] TipoServicio tipoServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoServicio.Add(tipoServicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoServicio", new { id = tipoServicio.Id }, tipoServicio);
        }

        // DELETE: api/TipoServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoServicio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoServicio = await _context.TipoServicio.FindAsync(id);
            if (tipoServicio == null)
            {
                return NotFound();
            }

            _context.TipoServicio.Remove(tipoServicio);
            await _context.SaveChangesAsync();

            return Ok(tipoServicio);
        }

        private bool TipoServicioExists(int id)
        {
            return _context.TipoServicio.Any(e => e.Id == id);
        }
    }
}