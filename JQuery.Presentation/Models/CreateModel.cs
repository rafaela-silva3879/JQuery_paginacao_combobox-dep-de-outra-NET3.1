using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace JQuery.Presentation.Models
{
    public class CreateModel
    {
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use apenas letras.")]
        //[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        //[MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        //[Required(ErrorMessage = "Por favor, informe o nome do amigo.")]
        public string FriendName { get; set; }

   
        public string Phone { get; set; }

  
        public string IdState { get; set; }
    }
}