using System;
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
            Console.WriteLine($"O nome do seu heroi é {hero.Name}!");
            Console.WriteLine($"Experiência: {hero.Xp}\nNível: {hero.Level}\nVida: {hero.Life}\nAtaque: {hero.Atk}");
        }

        void EnemyChoice()
        {
            Monster monster;

            Console.WriteLine("Escolha o seu inimigo:");
            Console.WriteLine("1 - Orc");
            Console.WriteLine("2 - Troll");
            Console.WriteLine("3 - Goblin");

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
                Console.WriteLine($"Você escolheu o {monster.Name} como inimigo!");
                Console.WriteLine($"Seus atributos são:\nVida: {monster.Life}\nAtaque: {monster.Atk}\nExperiência: {monster.Xp}");
                Pause();
                Console.WriteLine("O que você deseja fazer?");
                Console.WriteLine("1 - Enfrentar!!!");
                Console.WriteLine("2 - Fugir...");

                string op_2 = Console.ReadLine();
                switch (op_2)
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

                Console.WriteLine(hero.Life);
                Console.WriteLine(monster.Life);

                if (hero.Life <= 0)
                    return;
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
