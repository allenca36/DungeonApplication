using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        private int _minDamage;
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        
        public Weapon(int maxDamage, string name, int bonusHitChance, bool isTwoHanded, int minDamage)
        {
            MaxDamage = maxDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            MinDamage = minDamage;
        }

        public override string ToString()
        {
            return string.Format($"{Name}\t{MinDamage} to {MaxDamage}\nBonus Hit: {BonusHitChance}%\nIs Two Handed? {(IsTwoHanded ? "Yes" : "No")}");
        }
    }
}
