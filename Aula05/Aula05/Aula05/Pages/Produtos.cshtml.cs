using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aula05.Pages
{
    public class ProdutosModel : PageModel
    {
        public List<string> produtos = new List<string>();
        public void OnGet()
        {
            carregarProdutos();
        }

        public void carregarProdutos()
        {
            produtos.Add("Produto 1");
            produtos.Add("Produto 2");
            produtos.Add("Produto 3");
        }
    }
}
