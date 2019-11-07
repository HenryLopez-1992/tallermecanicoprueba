using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using estudiartaller.Data.DDL;
using estudiartaller.Models;

namespace estudiartaller.Controllers
{
    public class ServicioMecanicoController : Controller
    {
        private readonly estudiartallerContext _context;

        public ServicioMecanicoController(estudiartallerContext context)
        {
            _context = context;
        }

        // GET: ServicioMecanico
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServicioMecanico.ToListAsync());
        }

        // GET: ServicioMecanico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioMecanico = await _context.ServicioMecanico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioMecanico == null)
            {
                return NotFound();
            }

            return View(servicioMecanico);
        }

        // GET: ServicioMecanico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicioMecanico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaIngresoVehiculo,FechaEntregaVehiculo,DescripcionServicio,TipoServicioId,VehiculoId")] ServicioMecanico servicioMecanico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioMecanico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioMecanico);
        }

        // GET: ServicioMecanico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioMecanico = await _context.ServicioMecanico.FindAsync(id);
            if (servicioMecanico == null)
            {
                return NotFound();
            }
            return View(servicioMecanico);
        }

        // POST: ServicioMecanico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaIngresoVehiculo,FechaEntregaVehiculo,DescripcionServicio")] ServicioMecanico servicioMecanico)
        {
            if (id != servicioMecanico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioMecanico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioMecanicoExists(servicioMecanico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(servicioMecanico);
        }

        // GET: ServicioMecanico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioMecanico = await _context.ServicioMecanico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioMecanico == null)
            {
                return NotFound();
            }

            return View(servicioMecanico);
        }

        // POST: ServicioMecanico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioMecanico = await _context.ServicioMecanico.FindAsync(id);
            _context.ServicioMecanico.Remove(servicioMecanico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioMecanicoExists(int id)
        {
            return _context.ServicioMecanico.Any(e => e.Id == id);
        }
    }
}
