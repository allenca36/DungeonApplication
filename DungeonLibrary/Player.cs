using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {    
        public Race CharacterRace { get; set; }        
        public Weapon EquippedWeapon { get; set; }
        
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {        
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

            switch (CharacterRace)
            {                
                case Race.Elf:
                    HitChance += 5;
                    break;                
                case Race.Human:
                    break;                
                case Race.Dwarf:
                    break;                
            }
        }        

        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)
            {
                case Race.Elf:
                    description = "Elf: a very agile creature.";
                    break;
                case Race.Human:
                    description = "Human";
                    break;
                case Race.Dwarf:
                    description = "Dwarf";
                    break;                
            }

            return string.Format($"----{Name}----\n" +
                $"Life: {Life} of {MaxLife}\n" +
                $"Hit Chance: {CalcHitChance()}%\n" +
                $"Weapon:\n{EquippedWeapon}\n" +
                $"Block: {Block}\n" +
                $"Description\n{description}");
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            //determine damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }


    }
}
