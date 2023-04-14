using System;
using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Interfaces
{
	public interface ILivroService
	{
		IList<Livro> GetAll();

        //ICollection<Livro> GetAll();

        Livro Get(int Id);

		void Create(Livro livro);

		void Update(Livro livro);

		void Delete(int Id);

		void Create(LivroViewModel livroViewModel);
	}
}

