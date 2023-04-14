using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Service;
using Domain.ViewModels;
using Web.TagHelpers;
using Microsoft.Build.Tasks.Deployment.ManifestUtilities;
using static Web.TagHelpers.MessageHelper;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    public class BaseAutor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }

    [Authorize]
    public class LivroController : Controller
    {
        private readonly AtDbContext _context;

        public LivroController(AtDbContext context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
            return _context.livros != null ?
                          View(await _context.livros.ToListAsync()) :
                          Problem("Entity set 'AtDbContext.livros'  is null.");
        }


        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.livros == null)
            {
                return NotFound();
            }

            var livro = await _context.livros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }
        
      
        // GET: Livro/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Isbn,Ano")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.Message = "Este formulário foi enviado com sucesso!";

                ViewBag.outputMessage = new FormOutputMessage()
                {
                    Valid = true,
                    Message = "Formulário enviado com sucesso!"
                };


                _context.Add(livro);
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
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.livros == null)
            {
                return NotFound();
            }

            var livro = await _context.livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Isbn,Ano")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            return View(livro);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.livros == null)
            {
                return NotFound();
            }

            var livro = await _context.livros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.livros == null)
            {
                return Problem("Entity set 'AtDbContext.livros'  is null.");
            }
            var livro = await _context.livros.FindAsync(id);
            if (livro != null)
            {
                _context.livros.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
          return (_context.livros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
