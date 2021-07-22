using Consultorio.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    public class MonstrosController : Controller
    {
        public IActionResult Index()
        {
            List<Monstro> listaMonstros = new();

            listaMonstros.Add(new Monstro { Id = 1, Name = "Orc", Descricao = "Orc, ork ou orco (termo vindo do latim Orcus, um dos títulos de Plutão, o senhor do mundo dos mortos), aparece nas línguas germânicas e nos contos de fantasia medieval como uma criatura deformada e forte, que combate contra as 'forças do bem'."});
            listaMonstros.Add(new Monstro { Id = 2, Name = "Goblin", Descricao = "Goblins são criaturas geralmente verdes que se assemelham a duendes. Fazem parte do folclore nórdico, nas lendas eles vivem fazendo brincadeiras de mau gosto." });
            listaMonstros.Add(new Monstro { Id = 3, Name = "Troll", Descricao = "Enquanto na mitologia nórdica, o troll era uma criatura mágica, com habilidades especiais, nos escritos de Tolkien eles são retratados como maus, estúpidos, com hábitos brutos, embora ainda suficientemente inteligentes para se comunicar em linguagem conhecida." });

            ViewBag.listaMonstros = listaMonstros;

            return View();
        }
    }
}
