using System;
using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Interfaces
{
	public interface IAutorService
	{
		IList<Autor> GetAll();

        //ICollection<Autor> GetAll();

        Autor Get(int Id);

		void Create(Autor autor);

		void Update(Autor autor);

		void Delete(int Id);

		void Create(AutorViewModel autorViewModel);
	}
}

