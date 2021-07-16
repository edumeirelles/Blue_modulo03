namespace Aula04
{
    class Monster
    {
        public string Name { get; set; }
        public int Life { get; set; }
        public int Atk { get; set; }
        public int Xp { get; set; }
        
        public Monster(string Name, int Life, int Atk)
        {
            this.Name = Name;
            this.Life = Life;
            this.Atk = Atk;
            this.Xp = Life + Atk;
        }

       
    }
}
