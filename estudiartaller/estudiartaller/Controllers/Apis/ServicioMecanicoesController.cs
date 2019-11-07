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
    public class ServicioMecanicoesController : ControllerBase
    {
        private readonly estudiartallerContext _context;

        public ServicioMecanicoesController(estudiartallerContext context)
        {
            _context = context;
        }

        // GET: api/ServicioMecanicoes
        [HttpGet]
        public IEnumerable<ServicioMecanico> GetServicioMecanico()
        {
            return _context.ServicioMecanico;
        }

        // GET: api/ServicioMecanicoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicioMecanico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var servicioMecanico = await _context.ServicioMecanico.FindAsync(id);

            if (servicioMecanico == null)
            {
                return NotFound();
            }

            return Ok(servicioMecanico);
        }

        // PUT: api/ServicioMecanicoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioMecanico([FromRoute] int id, [FromBody] ServicioMecanico servicioMecanico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicioMecanico.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicioMecanico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioMecanicoExists(id))
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

        // POST: api/ServicioMecanicoes
        [HttpPost]
        public async Task<IActionResult> PostServicioMecanico([FromBody] ServicioMecanico servicioMecanico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServicioMecanico.Add(servicioMecanico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioMecanico", new { id = servicioMecanico.Id }, servicioMecanico);
        }

        // DELETE: api/ServicioMecanicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicioMecanico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var servicioMecanico = await _context.ServicioMecanico.FindAsync(id);
            if (servicioMecanico == null)
            {
                return NotFound();
            }

            _context.ServicioMecanico.Remove(servicioMecanico);
            await _context.SaveChangesAsync();

            return Ok(servicioMecanico);
        }

        private bool ServicioMecanicoExists(int id)
        {
            return _context.ServicioMecanico.Any(e => e.Id == id);
        }
    }
}