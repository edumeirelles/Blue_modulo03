using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaDeAula.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public int Idade { get => Convert.ToInt32(Math.Floor((DateTime.Now - DataNasc).TotalDays / 365)); }

        public Aluno(int Id, string Nome, DateTime DataNasc)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.DataNasc = DataNasc;
        }
    }
}
