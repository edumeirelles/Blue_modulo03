using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Models
{
    public class Instrumento
    {
        [Display(Name = "#")]
        public int Id { get; set; }
        [Display(Name = "Tipo")]
        public string Type { get; set; }
        [Display(Name = "Marca")]
        public string Brand { get; set; }
        [Display(Name = "Modelo")]
        public string Model { get; set; }
        [Display(Name = "Preço")]
        public double Price { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Link da imagem")]
        public string Link { get; set; }
    }
}
