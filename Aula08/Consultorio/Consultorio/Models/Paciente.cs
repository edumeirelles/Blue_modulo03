using System;
using System.ComponentModel.DataAnnotations;

namespace Consultorio.Models
{
    public class Paciente
    {
        [Display (Name = "#")]
        public int Id { get; set; }

        [Display (Name = "Nome")]
        public string Name { get; set; }

        [Display (Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        [Display (Name = "Descrição")]
        public string Descricao { get; set; }
    }
}