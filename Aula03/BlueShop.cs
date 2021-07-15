using System;
using System.Collections.Generic;

namespace Aula03
{
    public class BlueShop
    {
        List<Product> produtos = new List<Product>();
        public void Iniciar()
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Cadastrar um produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("0 - Sair");
            string op = Console.ReadLine();
            switch(op)
            {
                case "1":
                    CadastroDeProdutos();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Iniciar();

            void CadastroDeProdutos()
            {
                Product produto = new Product();

                Console.WriteLine("Informe um nome para o novo produto");
                produto.Nome = Console.ReadLine();
                Console.WriteLine("Informe um preço para o novo produto");
                produto.Preco = Convert.ToDouble(Console.ReadLine());

                produtos.Add(produto);

                Console.WriteLine($"Produto {produto.Nome} adicionado com sucesso!");
            }

            void ListarProdutos()
            {
                foreach (Product p in produtos)
                {
                    Console.WriteLine("--");
                    Console.WriteLine($"Nome: {p.Descricao}");

                }
            }

        }

    }
}
