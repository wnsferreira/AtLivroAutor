using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Entities;

namespace Api.Controllers
{
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [Route("/livros")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_livroService.GetAll());
        }

        
        [Route("/livros/{id}")]
        [HttpGet]
        public IActionResult GetCurso(int id)
        {
            return Ok(_livroService.Get(id));
        }

        
        [HttpPost]
        [Route("/livros/create")]
        public IActionResult Create([FromBody] Livro livro)
        {
            _livroService.Create(livro);
            return NoContent();
        }

        [HttpPut]
        [Route("/livros/update")]
        public IActionResult Update([FromBody] Livro livro)
        {
            _livroService.Update(livro);
            return NoContent();
        }

        [HttpDelete]
        [Route("/livros/{id}")]
        public IActionResult Delete(int id)
        {
            _livroService.Delete(id);
            return NoContent();
        }
    }
}

