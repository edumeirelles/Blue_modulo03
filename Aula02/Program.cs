using System;
using System.Collections.Generic;
using System.Linq;

// 1. Algoritmo para calcular fatorial de um número informado pelo usuário.

int resultado = 1;

Console.WriteLine("Digite um número:");
int n = Convert.ToInt32(Console.ReadLine());

for (int i = n ; i > 0; i--)
{
    resultado *= i;
}

Console.WriteLine($"o fatorial de {n} é {resultado}");


//2. Algoritmo para encontrar o maior valor de uma lista de números com tamanho e valores definidos por usuário.

List<int> lista = new List<int>();

Console.WriteLine("Digite o tamanho da lista:");
int x = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= x; i++)
{
    Console.WriteLine($"Digite o {i}º número");
    lista.Add(Convert.ToInt32(Console.ReadLine()));
}

int max = lista.Max();

Console.WriteLine($"O maior número da lista é {max}");

//3. Algoritmo para definir um array de números com tamanho e valores definidos pelo usuário e apresentá-lo em tela ordenado de forma crescente.

Console.WriteLine("Digite o tamanho do array:");
int y = Convert.ToInt32(Console.ReadLine());

int[] array = new int[y];

for (int i = 0; i < y; i++)
{
    Console.WriteLine($"Digite o {i + 1}º número");
    array[i] = Convert.ToInt32(Console.ReadLine());
}

Array.Sort(array);

Console.WriteLine("[{0}]", string.Join(", ", array));

//4. Altere o algoritmo anterior para que os números sejam inseridos no array aleatoriamente: utilizar o objeto Random().
//A aplicação também deve apresentar o número que tem a maior frequência.


Console.WriteLine("Digite o tamanho do array:");
int z = Convert.ToInt32(Console.ReadLine());

int[] array2 = new int[z];

var random = new Random();

for (int i = 0; i < z; i++)
{
    array2[i] = random.Next(1, 100);
}

Array.Sort(array2);

Console.WriteLine("[{0}]", string.Join(", ", array2));