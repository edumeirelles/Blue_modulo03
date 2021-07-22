using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
