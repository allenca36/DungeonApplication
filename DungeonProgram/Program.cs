using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using DungeonMonstersLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon of DOOM!";
            Console.WriteLine("Your journey begins...\n");

            int score = 0;


            //1. Create a player
            
            //2. Create a weapon for the player

            Weapon sword = new Weapon(8, "Longsword", 10, false, 1);

            Player player = new Player("Leeroy Jenkins", 70, 5, 40, 40, Race.Elf, sword);

            //TODO 3. Add customization based on player race
            //Extra weapon or a special weapon

            //4. Create a loop for the room
            bool exit = false;

            do
            {

                // 5. Get a room description from a method that generates them
                Console.WriteLine(GetRoom());
                // 6. Create a monster in the room for the player to battle               
                Rabbit r1 = new Rabbit(); //default ctor that sets some values by default
                Rabbit r2 = new Rabbit("White rabbit", 25, 25, 50, 20, 2, 8, "Thats no ordinary rabbit..look at the bones!", true);

                Monster[] monsters = { r1, r2, r2, r1, r1 }; 
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                Console.WriteLine("\nIn this room: " + monster.Name);

                //7. Create a loop for the user choice menu
                bool reload = false;

                do
                {
                    // 8. Create a menu of options
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    // 9. Capture user Choice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();
                    // 10. Perform an action based on the user's input
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            // 11. Create attack/battle functionality
                            // 12. Handle if the user wins
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //it's dead
                                //Possible Customization: you could have logic for the player to collect items like loot
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true; // breaks out of loop to get a new room and monster
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            // 13. Handle the monster's free attack
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player); // free attack
                            Console.WriteLine();
                            reload = true; //load a new room                            
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player info");
                            // 14. Write out player info to screen
                            Console.WriteLine(player);

                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                            // 15. Write out Monster info to screen
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("No one likes a quitter.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Thou hast chosen an improper option. Triest though again...");
                            break;
                    }

                    // 16. Check the players life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude... you died!");
                        exit = true; // breaks out of both loops.
                    }


                } while (!exit && !reload);



            } while (!exit);
            // 17. Show player how many monsters they defeated
            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));


        }//end Main()

        private static string GetRoom()
        {
            string[] rooms = {
                "You round the corner to see a ghastly scene. A semitranslucent figure hangs in the air, studded with crossbow bolts and with blood pouring from every wound. It reaches toward you in a pleading gesture, points to the walls on either side of the room, and then vanishes. Once it has gone, you notice small holes in the walls, each just large enough for a bolt to pass through.",
                "You enter a small room and your steps echo. Looking about, you're uncertain why, but then a wall vanishes and reveals an enormous chamber. The wall was an illusion and whoever cast it must be nearby!",
                "The manacles set into the walls of this room give you the distinct impression that it was used as a prison and torture chamber, although you can see no evidence of torture devices. One particularly large set of manacles -- big enough for an ogre --have been broken open.",
                "This room holds six dry circular basins large enough to hold a man and a dry fountain at its center. All possess chipped carvings of merfolk and other sea creatures. It looks like this room once served some group of people as a bath.",
                "A crack in the ceiling above the middle of the north wall allows a trickle of water to flow down to the floor. The water pools near the base of the wall, and a rivulet runs along the wall an out into the hall. The water smells fresh."
            };

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;
        }
    }//end class
}//end namespace
