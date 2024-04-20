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
    public class pedido_encabezadoController : Controller
    {
        private readonly libreriaContext _context;

        public pedido_encabezadoController(libreriaContext context)
        {
            _context = context;
        }

        // GET: pedido_encabezado
        public async Task<IActionResult> Index()
        {
            return View(await _context.pedido_encabezado.ToListAsync());
        }

        // GET: pedido_encabezado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido_encabezado = await _context.pedido_encabezado
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedido_encabezado == null)
            {
                return NotFound();
            }

            return View(pedido_encabezado);
        }

        // GET: pedido_encabezado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pedido_encabezado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,id_cliente,cantidad_libros,total,estado")] pedido_encabezado pedido_encabezado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido_encabezado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido_encabezado);
        }

        // GET: pedido_encabezado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido_encabezado = await _context.pedido_encabezado.FindAsync(id);
            if (pedido_encabezado == null)
            {
                return NotFound();
            }
            return View(pedido_encabezado);
        }

        // POST: pedido_encabezado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,id_cliente,cantidad_libros,total,estado")] pedido_encabezado pedido_encabezado)
        {
            if (id != pedido_encabezado.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido_encabezado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pedido_encabezadoExists(pedido_encabezado.id))
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
            return View(pedido_encabezado);
        }

        // GET: pedido_encabezado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido_encabezado = await _context.pedido_encabezado
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedido_encabezado == null)
            {
                return NotFound();
            }

            return View(pedido_encabezado);
        }

        // POST: pedido_encabezado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido_encabezado = await _context.pedido_encabezado.FindAsync(id);
            if (pedido_encabezado != null)
            {
                _context.pedido_encabezado.Remove(pedido_encabezado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pedido_encabezadoExists(int id)
        {
            return _context.pedido_encabezado.Any(e => e.id == id);
        }
    }
}
