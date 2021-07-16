using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula04
{
    public class Hero
    {
        public int Xp { get; set; }
        public int Level { get; set; }
        public int Life { get; set; }
        public int BaseAtk { get; set; }
        public int Atk { get; set; }
        public string Name { get; set; }
        public Hero(string Name)
        {
            Random rand = new();
            this.Name = Name;
            this.Xp = 0;
            this.Level = 1;
            this.Life = 10;
            this.BaseAtk = rand.Next(1,11);
            this.Atk = this.BaseAtk + this.Level;
        }

        public void earnXP(int newXp)
        {
            Xp += newXp;
            int newLevel = (Xp / 10) + 1;
            if (newLevel > Level)
            {
                Console.WriteLine($"Você subiu de nível!\nSeu nível agora é {newLevel}");
                Life = newLevel * 10;
            }
            Level = newLevel;
            Atk = BaseAtk + Level;

        }

    }
}
