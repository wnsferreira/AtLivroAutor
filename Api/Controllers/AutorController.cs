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
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [Route("/autores")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_autorService.GetAll());
        }

        
        [Route("/autores/{id}")]
        [HttpGet]
        public IActionResult GetCurso(int id)
        {
            return Ok(_autorService.Get(id));
        }

        
        [HttpPost]
        [Route("/autores/create")]
        public IActionResult Create([FromBody] Autor autor)
        {
            _autorService.Create(autor);
            return NoContent();
        }

        [HttpPut]
        [Route("/autores/update")]
        public IActionResult Update([FromBody] Autor autor)
        {
            _autorService.Update(autor);
            return NoContent();
        }

        [HttpDelete]
        [Route("/autores/{id}")]
        public IActionResult Delete(int id)
        {
            _autorService.Delete(id);
            return NoContent();
        }
    }
}

