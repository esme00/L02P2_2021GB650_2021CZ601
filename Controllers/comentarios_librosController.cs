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
    public class comentarios_librosController : Controller
    {
        private readonly libreriaContext _context;

        public comentarios_librosController(libreriaContext context)
        {
            _context = context;
        }

        // GET: comentarios_libros
        public async Task<IActionResult> Index()
        {
            return View(await _context.comentarios_libros.ToListAsync());
        }

        // GET: comentarios_libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios_libros = await _context.comentarios_libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (comentarios_libros == null)
            {
                return NotFound();
            }

            return View(comentarios_libros);
        }

        // GET: comentarios_libros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: comentarios_libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,id_libro,comentarios,usuario,created_ad")] comentarios_libros comentarios_libros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentarios_libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comentarios_libros);
        }

        // GET: comentarios_libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios_libros = await _context.comentarios_libros.FindAsync(id);
            if (comentarios_libros == null)
            {
                return NotFound();
            }
            return View(comentarios_libros);
        }

        // POST: comentarios_libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,id_libro,comentarios,usuario,created_ad")] comentarios_libros comentarios_libros)
        {
            if (id != comentarios_libros.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentarios_libros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!comentarios_librosExists(comentarios_libros.id))
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
            return View(comentarios_libros);
        }

        // GET: comentarios_libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios_libros = await _context.comentarios_libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (comentarios_libros == null)
            {
                return NotFound();
            }

            return View(comentarios_libros);
        }

        // POST: comentarios_libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentarios_libros = await _context.comentarios_libros.FindAsync(id);
            if (comentarios_libros != null)
            {
                _context.comentarios_libros.Remove(comentarios_libros);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool comentarios_librosExists(int id)
        {
            return _context.comentarios_libros.Any(e => e.id == id);
        }
    }
}
