using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class Choices
    {

        /* Comments, Ideas, and Bug List.
         * 
         * Ideas
         *  1. Put all conversations in a List or Dictionary then call the key or index depending on the user
         *  selection.  Would this make it easier?
         *     DONE! Did this -> a. or make a convo class with all the conversations.
         * 
         * BUGS!
         *  None yet.
         * 
         */



        public static void Choice1(Player player)
        {
            Game.Dialog($"Attendant:\"Would you be interested in a tour?\" \n");
            Console.Write("What is your response? \n1) Absolutely \n2) Maybe later \n3) I'm just looking for a new ship\nResponse: ");
            //Console.WriteLine("Please type 1, 2, or 3 and press enter");
            var input = Console.ReadLine();
            input = Convert.ToString(input);
            if (input == "1")
            {
                Game.Dialog($"Attendant: \"Great, follow me {player.Name}!\"");
                Console.WriteLine("You follow down a long corridor, taking in the grand structure and strange symbols..");
                Game.Dialog("Attendant: \"This is the ship bazaar.  It is the most visited portion of the trade hub.\" ");
                Game.ShipBazaar(player);
            }
            else if (input == "2")
            {
                Game.Dialog($"Attendant: \"Ok {player.Name}, I will check back if you look lost. \nMost arrivals are looking to buy and sell ships. " +
                    "\nOr test their luck at the Casino." +
                    "\nHave a great adventure!\"");
                Game.MainArea(player);
            }
            else if (input == "3")
            {
                Game.Dialog($"Attendant: \"The ship bazaar is right down this corridor.  Please let me know if you need further assistance." +
                    $"\nHave a great adventure {player.Name}!\"");
                Game.ShipBazaar(player);
            }
            else { Console.WriteLine("Please press 1, 2, or 3 and press enter"); Choice1(player); }
        }



    }
}
