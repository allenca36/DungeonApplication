using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonMonstersLibrary
{
    public class Rabbit : Monster
    {
        //props
        public bool IsFluffy { get; set; }

        //ctor
        //FQ CTOR
        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFluffy) : base(name, life, maxLife, hitChance, block, maxDamage, description, minDamage)
        {
            IsFluffy = isFluffy;
        }

        //we will make a custom default ctor - it will accept NO parameters but 
        //it will set some default values in the body of the method
        public Rabbit()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby Rabbit";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It's just a cute little bunny...why would you hurt it....bully!!";
            IsFluffy = false;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "Fluffy" : "Not so fluffy...");
        }
        public override int CalcBlock()
        {
            //we will use IsFluffy to determin if the monster gets a boost to their block ability
            int calculatedBlock = Block;
            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2; //this gives the monster a 50% boost if they are fluffy
            }

            return calculatedBlock;
        }


    }
}
