using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Service;
using Microsoft.AspNetCore.Authorization;
using Web.TagHelpers;

namespace Web.Controllers
{
    [Authorize]
    public class AutorController : Controller
    {
        private readonly AtDbContext _context;

        public AutorController(AtDbContext context)
        {
            _context = context;
        }

        // GET: Autor
        public async Task<IActionResult> Index()
        {
              return _context.autores != null ? 
                          View(await _context.autores.ToListAsync()) :
                          Problem("Entity set 'AtDbContext.autores'  is null.");
        }

        // GET: Autor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.autores == null)
            {
                return NotFound();
            }

            var autor = await _context.autores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,Nascimento")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                ViewBag.outputMessage = new FormOutputMessage()
                {
                    Valid = true,
                    Message = "Formulário enviado com sucesso!"
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                ViewBag.outputMessage = new FormOutputMessage()
                {
                    Message = "Formulário com problemas!",
                    Valid = false
                };
            }
            return View(autor);
        }

        // GET: Autor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.autores == null)
            {
                return NotFound();
            }

            var autor = await _context.autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Email,Nascimento")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Message = "Formulário atualizado com sucesso!";
                //return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.autores == null)
            {
                return NotFound();
            }

            var autor = await _context.autores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.autores == null)
            {
                return Problem("Entity set 'AtDbContext.autores'  is null.");
            }
            var autor = await _context.autores.FindAsync(id);
            if (autor != null)
            {
                _context.autores.Remove(autor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
          return (_context.autores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
