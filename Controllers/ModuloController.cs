using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCurso.Data;
using AppCurso.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppCurso
{
    [Authorize]
    public class ModuloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModuloController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modulo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Modulos.Include(m => m.Curso);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Modulo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulos
                .Include(x => x.Curso)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        // GET: Modulo/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Titulo");
            return View();
        }

        // POST: Modulo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,OrdemExibicao,CursoId")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Titulo", modulo.CursoId);
            return View(modulo);
        }

        // GET: Modulo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Titulo", modulo.CursoId);
            return View(modulo);
        }

        // POST: Modulo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,OrdemExibicao,CursoId")] Modulo modulo)
        {
            if (id != modulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuloExists(modulo.Id))
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
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Titulo", modulo.CursoId);
            return View(modulo);
        }

        // GET: Modulo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulos
                .Include(m => m.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        // POST: Modulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modulos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Modulos'  is null.");
            }
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo != null)
            {
                _context.Modulos.Remove(modulo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuloExists(int id)
        {
            return (_context.Modulos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
