using System;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
	public class LivroService : ILivroService
    {
        private readonly AtDbContext _atDbContext;
        public LivroService(AtDbContext atDbContext)
        {
            _atDbContext = atDbContext;
        }

        public IList<Livro> GetAll()
        {
            return _atDbContext.livros
                .Include(c => c.Autores)
                .ToList();
        }

        public void Create(Livro livro)
        {
            _atDbContext.livros.Add(livro);
            _atDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var livro = _atDbContext.livros.First(c => c.Id == Id);
            _atDbContext.livros.Remove(livro);
            _atDbContext.SaveChanges();
        }

        public Livro Get(int Id)
        {
            return _atDbContext.livros
                .Include(c => c.Autores)
                .First(c => c.Id == Id);
        }

        public void Update(Livro livro)
        {
            _atDbContext.livros.Update(livro);
            _atDbContext.SaveChanges();
        }

        public void Create(LivroViewModel livroViewModel)
        {
            var livro = new Livro()
            {
                Titulo = livroViewModel.Titulo,
                Isbn = livroViewModel.Isbn,
                Ano = livroViewModel.Ano
            };

            _atDbContext.livros.Add(livro);
            _atDbContext.SaveChanges();
        }

       
    }
}

