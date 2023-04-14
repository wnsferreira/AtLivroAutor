using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Autor
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome deve ser preenchido")]
        [MaxLength(150)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome deve ser preenchido")]
        [MaxLength(50)]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo Email deve ser preenchido")]
        public string? Email { get; set; }

        public string? Nascimento { get; set; }

        public ICollection<Livro>? Livros { get; set; }
	}
}


//          OBSERVAÇÃO

//  Coloquei a validação direto na entidade porque ao utilizar a viewmodel estava apresentando erro.
//  Em principio todas as validações estavam na ViewModel.