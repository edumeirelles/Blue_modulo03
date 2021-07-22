using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalaDeAula.Models;

namespace SalaDeAula.Pages.Alunos
{
    public class IndexModel : PageModel
    {
        public List<Aluno> alunos = new();
        public void OnGet()
        {
            carregarAlunos();
        }

        void carregarAlunos()
        {
            alunos.Add(new Aluno(1,"Eduardo", new DateTime(1985, 01, 15)));         
            alunos.Add(new Aluno(2,"Zé", new DateTime(1990, 01, 01)));         
            alunos.Add(new Aluno(3,"Jão", new DateTime(1988, 06, 27)));         
            
        }
    }
}
