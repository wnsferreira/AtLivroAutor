using System;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
	public class AutorService : IAutorService
    {
        private readonly AtDbContext _atDbContext;
        public AutorService(AtDbContext atDbContext)
        {
            _atDbContext = atDbContext;
        }

        public IList<Autor> GetAll()
        {
            return _atDbContext.autores
                .Include(c => c.Livros)
                .ToList();
        }

        public void Create(Autor autor)
        {
            _atDbContext.autores.Add(autor);
            _atDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var autor = _atDbContext.autores.First(c => c.Id == Id);
            _atDbContext.autores.Remove(autor);
            _atDbContext.SaveChanges();
        }

        public Autor Get(int Id)
        {
            return _atDbContext.autores
                .Include(c => c.Livros)
                .First(c => c.Id == Id);
        }

        public void Update(Autor autor)
        {
            _atDbContext.autores.Update(autor);
            _atDbContext.SaveChanges();
        }

        public void Create(AutorViewModel autorViewModel)
        {
            var autor = new Autor()
            {
                Nome = autorViewModel.Nome,
                Sobrenome = autorViewModel.Sobrenome,
                Email = autorViewModel.Email,
                Nascimento = autorViewModel.Nascimento,
            };

            _atDbContext.autores.Add(autor);
            _atDbContext.SaveChanges();
        }

       
    }
}

