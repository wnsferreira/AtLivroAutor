using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
      
    public class LivroViewModel
    {

        [Required(ErrorMessage = "O campo titulo deve ser preenchido")]
        [MaxLength(100, ErrorMessage = "O tamanho excede o permitido")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo Isbn deve ser preenchido")]
        public string? Isbn { get; set; }

        [Required(ErrorMessage = "O campo Ano deve ser preenchido")]
        public int? Ano { get; set; }

        public ICollection<Autor>? Autores { get; set; }


    }
}



   

