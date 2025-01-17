﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula04
{
    public class Game
    {
        Hero hero;
        public void Start()
        {
            Console.WriteLine("\n\n###### Game Aula04 ######\n\n");
            Console.WriteLine("Digite o nome do seu Heroi:");
            hero = new(Console.ReadLine());
            Disclaimer();
            Pause();
            EnemyChoice();
        }

        static void Pause()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        void Disclaimer()
        {
            
            Console.WriteLine($"\n\n*=*=*=*=*=*=*\nO nome do seu heroi é {hero.Name}!\n*=*=*=*=*=*=*");
            Console.WriteLine($"\n\nExperiência: {hero.Xp}\nNível: {hero.Level}\nVida: {hero.Life}\nAtaque: {hero.Atk}");
        }

        void EnemyChoice()
        {
            Monster monster;

            Console.WriteLine("Escolha o seu inimigo:\n");
            Console.WriteLine("1 - Orc");
            Console.WriteLine("2 - Troll");
            Console.WriteLine("3 - Goblin\n");
            Console.Write("Opção: ");

            string op_1 = Console.ReadLine();

            if (op_1 == "1")
            {
                monster = new("Orc", hero.Level * 2, hero.Level);
                Action();
            }

            else if (op_1 == "2")
            {
                monster = new("Troll", hero.Level * 5, hero.Level * 2);
                Action();
            }

            else if (op_1 == "3")
            {
                monster = new("Goblin", hero.Level * 10, hero.Level * 4);
                Action();
            }

            else
                Console.WriteLine("Opção Inválida");

            void Action()
            {
                Console.WriteLine($"\nVocê escolheu o {monster.Name} como inimigo!");
                Console.WriteLine($"\nSeus atributos são:\nVida: {monster.Life}\nAtaque: {monster.Atk}\nExperiência: {monster.Xp}");
                Pause();
                Console.WriteLine("O que você deseja fazer?");
                Console.WriteLine("1 - Enfrentar!!!");
                Console.WriteLine("2 - Fugir...\n");
                Console.Write("Opção: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Fight();
                        break;
                    case "2":
                        EnemyChoice();
                        break;
                }
            }
            void Fight()
            {
                hero.Life -= monster.Atk;
                monster.Life -= hero.Atk;

                if (hero.Life <= 0)
                {
                    Console.WriteLine("Você foi derrotado!!!\n\n\n\nGAME OVER.");
                    return;
                }
                    
                else
                {
                    if (monster.Life <= 0)
                    {
                        Console.WriteLine($"Você derrotou o {monster.Name}");
                        hero.earnXP(monster.Xp);
                        Disclaimer();
                        Pause();
                        EnemyChoice();
                    }
                    else
                        Fight();
                }
            }
        } 
        
    }
}
