using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Categoria do Instrumento")]
        public string InstrumentoCategoria { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Instrumento")]
        public int InstrumentoId { get; set; }
        public Instrumento Instrumento { get; set; }

    }
}
