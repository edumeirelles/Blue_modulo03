using Loja_de_Instrumentos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Data
{
    public class LojaDeInstrumentosContext : DbContext
    {
        public LojaDeInstrumentosContext(DbContextOptions<LojaDeInstrumentosContext> options) :base(options)
        {
                
        }
        public DbSet<Guitarra> Guitarra { get; set; }
        public DbSet<Violao> Violao { get; set; }
        public DbSet<Bateria> Bateria { get; set; }

    }
}
