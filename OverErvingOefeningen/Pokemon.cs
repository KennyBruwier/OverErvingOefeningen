using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverErvingOefeningen
{
    class Pokemon
    {
        public int HP_Base { get; set; }
        public int Attack_Base { get; set; }
        public int Defense_Base { get; set; }
        public int Speed_Base { get; set; }
        public int SpecialAttack_Base { get; set; }
        public int SpecialDefense_Base { get; set; }

        public string Naam { get; set; }
        public string Type { get; set; }
        public int Nummer { get; set; }
        private int level;
        public int Level
        {
            get { return level; }
            private set { level = value; }
        }
        public double Average 
        { 
            get
            { return Total/6; }
                
        }
        public double Total 
        { 
            get
            {
                return HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base;
            }
        }
        public double HP_Full { get 
            { 
                return (((HP_Base + 50)*level)/50)+10; 
            } }
        public double Attack_Full { get { return Attack_Base * level / 50 + 5; } }
        public double Defense_Full { get { return Defense_Base * level / 50 + 5; } }
        public double Speed_Full { get { return Speed_Base * level / 50 + 5; } }
        public double SpecialAttack_Full { get { return SpecialAttack_Base * level / 50 + 5; } }
        public double SpecialDefense_Full { get { return SpecialDefense_Base * level / 50 + 5; } }

        public void VerhoogLevel()
        {
            level++;
        }
        public string ShowFullStats(bool showOnScreen = false)
        {
            string fullStats = string.Format(   "Health Points: {0,4:0} " +
                                                "Attack: {1,4:0} " +
                                                "Defense: {2,4:0} " +
                                                "Speed: {3,4:0} " +
                                                "Special Attack: {4,4:0} " +
                                                "Special Defense: {5,4:0} ",
                                                HP_Full, Attack_Full, Defense_Full, Speed_Full, SpecialAttack_Full, SpecialDefense_Full);
            if (showOnScreen) Console.WriteLine(fullStats);
            return fullStats;
        }

        public override string ToString()
        {
            return ShowFullStats();
        }
    }
}
