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
    public class AulaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AulaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aula
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Aulas.Include(a => a.Modulo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Aula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .Include(a => a.Modulo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            aula.Modulo = GetModulo(aula.ModuloId);

            return View(aula);
        }

        // Pega o módulo que pertence a aula
        public Modulo GetModulo(int id)
        {
            var modulo = _context.Modulos
                .FirstOrDefault(x => x.Id == id);

            modulo.Curso = _context.Cursos
                .FirstOrDefault(x => x.Id == modulo.CursoId);

            return modulo;
        }



        // GET: Aula/Create
        public IActionResult Create()
        {
            ViewData["ModuloId"] = new SelectList(_context.Modulos, "Id", "Descricao");
            return View();
        }

        // POST: Aula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,UrlVideoAula,ModuloId")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuloId"] = new SelectList(_context.Modulos, "Id", "Descricao", aula.ModuloId);
            return View(aula);
        }

        // GET: Aula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }
            ViewData["ModuloId"] = new SelectList(_context.Modulos, "Id", "Descricao", aula.ModuloId);
            return View(aula);
        }

        // POST: Aula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,UrlVideoAula,ModuloId")] Aula aula)
        {
            if (id != aula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaExists(aula.Id))
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
            ViewData["ModuloId"] = new SelectList(_context.Modulos, "Id", "Descricao", aula.ModuloId);
            return View(aula);
        }

        // GET: Aula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .Include(a => a.Modulo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // POST: Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aulas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Aulas'  is null.");
            }
            var aula = await _context.Aulas.FindAsync(id);
            if (aula != null)
            {
                _context.Aulas.Remove(aula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulaExists(int id)
        {
            return (_context.Aulas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
