using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class Game
    {

        static string PlayerName = "Bob";

        public static void StartGame()
        {
            Dialog("          Space Adventure!", "green");
            Dialog("\nWelcome to the galaxy of Triangulum!\n", "green");
            
            Console.WriteLine("You awoke to find your ship crashed on an unknown planet " +
                "and have little memory of what happened." +
                "\nSome traders offered you a ride to the nearest trade hub. You accepted.\n");

            Console.Write("As you walk into the entrance of the galactic trade hub.  The new arrival attendant welcomes you, \n");
            Game.Dialog($"\nAttendant:\"Hi-llo! and welcome to the Triangulum Galatic Trade Hub.\" " +
                    $"\n\"What is your name?\"");
        }


        public static void NamePlayer()
        {

            Console.WriteLine("Please enter a player name and press enter ");
            PlayerName = Console.ReadLine()!;
            PlayerName = Convert.ToString(PlayerName)!;
            TextInfo myTi = new CultureInfo("en-US", false).TextInfo;
            PlayerName = myTi.ToTitleCase(PlayerName);


                if(string.IsNullOrEmpty(PlayerName))
                {
                    Dialog("Attendant:\"Hmm.. no name, I will call you.. Astrotron, ruler of worlds! " +
                                        "\nOk maybe just Astrotron.\"");
                    PlayerName = "Astrotron";
                }
            Console.WriteLine(" ");
            Dialog("Attendant:\"That is a really cool name " + PlayerName + "!\"");
            Console.WriteLine("---Press enter to continue---");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Dialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Dialog(string message, string color)
        {
            switch(color)
            {
                case "red":
                   Console.ForegroundColor = ConsoleColor.Red;
                   break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Choice1()
        {
            Dialog($"Attendant:\"Would you be interested in a tour?\" \n");
            Console.Write("What is your response? \n1) Absolutely \n2) Maybe later \n3) I'm just looking for a new ship\nResponse: ");
            //Console.WriteLine("Please type 1, 2, or 3 and press enter");
            var input = Console.ReadLine();
            input = Convert.ToString(input);
            if(input == "1")
            {
                Dialog($"Attendant: \"Great, follow me {PlayerName}!\"");
                Console.WriteLine("You follow down a long corridor, taking in the grand structure and strange symbols..");
                Dialog("Attendant: \"This is the ship bazaar.  It is the most visited portion of the trade hub.\" ");
            }
            else if(input == "2")
            {
                Dialog($"Attendant: \"Ok {PlayerName}, I will check back if you look lost. \nMost arrivals are looking to buy and sell ships. " +
                    "\nYou can find them right down that corridor." +
                    "\nHave a great adventure!\"");
            }
            else if(input == "3")
            {
                Dialog($"Attendant: \"The ship bazaar is right down this corridor.  Please let me know if you need further assistance." +
                    $"\nHave a great adventure {PlayerName}!\"");
            }
            else { Console.WriteLine("Please press 1, 2, or 3 and press enter"); Choice1(); }
        }
    }
}
