using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
      
    public class AutorViewModel
    {

        [Required(ErrorMessage = "O campo Nome deve ser preenchido")]
        [MaxLength(150)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome deve ser preenchido")]
        [MaxLength(50)]
        public string? Sobrenome { get; set; }

        [RegularExpression("\\S*@\\S.\\S*", ErrorMessage = "Verifique o preenchimento do e-mail, parece inválido.")]
        public string? Email { get; set; }

        public string? Nascimento { get; set; }

        public ICollection<Livro>? Livros { get; set; }

    }
}



   

