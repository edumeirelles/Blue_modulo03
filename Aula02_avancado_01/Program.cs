using System;

Console.WriteLine("Digite o nome da turma:");
string x = Console.ReadLine();
Console.WriteLine("Digite o número de alunos da turma:");
int y = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"A turma {x}, que contém no máximo {y} alunos, foi criada com sucesso");

string[] alunos = new string[y];

for (int i = 0; i < y; i++)
{
    Console.WriteLine($"Digite o nome do {i + 1}º aluno:");
    alunos[i] = Console.ReadLine();
}