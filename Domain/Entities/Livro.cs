
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Livro
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "O campo titulo deve ser preenchido")]
        [MaxLength(100, ErrorMessage = "O tamanho excede o permitido")]
		public string? Titulo { get; set; }


        [MaxLength(150)]
        [Required(ErrorMessage = "O campo Isbn deve ser preenchido")]
        public string? Isbn { get; set; }

		[Required]
        public int? Ano { get; set; }
        
        public ICollection<Autor>? Autores { get; set; }

    }
}

//    OBSERVAÇÕES

//Coloquei a validação direto na entidade porque ao utilizar a viewmodel estava apresentando erro.
//Em principio todas as validações estavam na ViewModel.

