using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class Choices
    {






        public static void Choice1(Player player)
        {
            Game.Dialog($"\nAttendant:\"Would you be interested in a tour?\" \n");
            Console.Write("What is your response? \n1) Absolutely \n2) Maybe later \n3) I'm just looking for a new ship\nResponse: ");
            //Console.WriteLine("Please type 1, 2, or 3 and press enter");
            var input = Console.ReadLine();
            input = Convert.ToString(input);
            if (input == "1")
            {
                Console.Clear();
                Game.Dialog($"\nAttendant: \"Great, follow me {player.Name}!\"\n");
                Thread.Sleep(1000);
                Console.WriteLine("You follow down a long corridor, taking in the grand structure and strange symbols..\n");
                Thread.Sleep(1000);
                Game.Dialog("Attendant: \"This is the ship bazaar.  There are many traders buying and selling ships, as well as ship parts.\"\n" +
                    "\"Over there we have our most visited portion of the trade hub, the Casino.\"\n\"There you can test your luck at" +
                    " the slot machines or card tables.\"\n\"Sometimes the card tables are closed for upcoming tournaments.\" ");
                Thread.Sleep(2000);
                Game.Dialog("\nAttendant: \"If you need anything else, please dont hesitate to ask\"");
                Game.PressContinue();
                Game.MainArea(player);
            }
            else if (input == "2")
            {
                Game.Dialog($"\nAttendant: \"Ok {player.Name}, I will check back if you look lost.\" \n\"Most arrivals are looking to buy and sell ships. " +
                    "Or test their luck at the Casino.\"" +
                    "\n\"Have a great adventure!\"\n");
                Game.PressContinue();
                Game.MainArea(player);
            }
            else if (input == "3")
            {
                Game.Dialog($"\nAttendant: \"The ship bazaar is right down this corridor.  Please let me know if you need further assistance.\"" +
                    $"\n\"Have a great adventure {player.Name}!\"\n");
                Game.PressContinue();
                Game.ShipBazaar(player);
            }
            else { Console.WriteLine("Please press 1, 2, or 3 and press enter"); Choice1(player); }
        }



    }
}
