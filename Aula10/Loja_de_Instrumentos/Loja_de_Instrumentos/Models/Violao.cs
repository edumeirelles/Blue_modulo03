using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Models
{
    public class Violao : Instrumento
    {
        public Violao(string Brand, string Model) : base(Brand, Model)
        {

        }
        public override string Type { get => "Violão"; }

    }
}
