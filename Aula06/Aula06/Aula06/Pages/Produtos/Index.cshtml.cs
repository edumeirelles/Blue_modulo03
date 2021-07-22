using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aula06.Models;

namespace Aula06.Pages.Produtos
{
    public class IndexModel : PageModel
    {
        public List<Product> produtos = new List<Product>();
        public void OnGet()
        {
            carregarProdutos();
        }
        void carregarProdutos()
        {
            produtos.Add(new Product
            {
                Nome = "Camisa",
                Preco = 100,
                Descricao = "Camisa de verão"
            });
            
            produtos.Add(new Product
            {
                Nome = "Calça",
                Preco = 200,
                Descricao = "Calça Jeans"
            });
           

        }
    }
}
