using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L02P2_2021GB650_2021CZ601.Models;

namespace L02P2_2021GB650_2021CZ601.Controllers
{
    public class pedido_detalleController : Controller
    {
        private readonly libreriaContext _context;

        public pedido_detalleController(libreriaContext context)
        {
            _context = context;
        }

        // GET: pedido_detalle
        public async Task<IActionResult> Index()
        {
            return View(await _context.pedido_detalle.ToListAsync());
        }

        // GET: pedido_detalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido_detalle = await _context.pedido_detalle
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedido_detalle == null)
            {
                return NotFound();
            }

            return View(pedido_detalle);
        }

        // GET: pedido_detalle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pedido_detalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,id_pedido,id_libro,created_at")] pedido_detalle pedido_detalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido_detalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido_detalle);
        }

        // GET: pedido_detalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido_detalle = await _context.pedido_detalle.FindAsync(id);
            if (pedido_detalle == null)
            {
                return NotFound();
            }
            return View(pedido_detalle);
        }

        // POST: pedido_detalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,id_pedido,id_libro,created_at")] pedido_detalle pedido_detalle)
        {
            if (id != pedido_detalle.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido_detalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pedido_detalleExists(pedido_detalle.id))
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
            return View(pedido_detalle);
        }

        // GET: pedido_detalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido_detalle = await _context.pedido_detalle
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedido_detalle == null)
            {
                return NotFound();
            }

            return View(pedido_detalle);
        }

        // POST: pedido_detalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido_detalle = await _context.pedido_detalle.FindAsync(id);
            if (pedido_detalle != null)
            {
                _context.pedido_detalle.Remove(pedido_detalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pedido_detalleExists(int id)
        {
            return _context.pedido_detalle.Any(e => e.id == id);
        }
    }
}
