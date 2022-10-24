using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Game
{
   
       
    static string PlayerName = "Bob";

    public static void StartGame()
    {
        Console.Title = "Space Adventure";
        string title = @"
            
                          _____                         ___      _                 _                  
                         /  ___|                       / _ \    | |               | |                 
                         \ `--. _ __   __ _  ___ ___  / /_\ \ __| |_   _____ _ __ | |_ _   _ _ __ ___ 
                          `--. \ '_ \ / _` |/ __/ _ \ |  _  |/ _` \ \ / / _ \ '_ \| __| | | | '__/ _ \
                         /\__/ / |_) | (_| | (_|  __/ | | | | (_| |\ V /  __/ | | | |_| |_| | | |  __/
                         \____/| .__/ \__,_|\___\___| \_| |_/\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|
                               | |                                                                    
                               |_|                                                                    

            ";
        
        Dialog(title, "darkmagenta");
 
                          
        Dialog("                                            Welcome to the Galaxy of Triangulum!", "green");
        Console.WriteLine("\n-----Press Enter to begin-----");
        Console.ReadKey();

    }

    public static void Starting()
    {
        Console.WriteLine("\nYou awoke to find your ship crashed on an unknown planet " +
            "and have little memory of what happened." +
            "\nSome traders offered you a ride to the nearest trade hub. You accepted.\n");

        Console.Write("As you walk into the entrance of the galactic trade hub.  The new arrival attendant welcomes you, \n");
        Game.Dialog($"\nAttendant:\"Hi-llo! and welcome to the Triangulum Galatic Trade Hub.\" " +
                $"\n\"What is your name?\"");
    }


    public static void NamePlayer(Player player)
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
            else
        {
        Console.WriteLine(" ");
        Dialog("Attendant:\"That is a really cool name " + PlayerName + "!\"");

        }
        player.Name = PlayerName;
        Console.WriteLine(" ");
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
            case "darkmagenta":
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine(message);
        Console.ResetColor();
    }







    //******************Working here!*********

    public static void MainArea(Player player)
    {
        Console.Clear();
        Console.WriteLine("You are currently in the main hub next to the information booth.\n");
        Console.Write("Where would you like to go?\n1) Ship Bazaar\n2) Casino\n3) Information Booth\nResponse: ");
        var x = Console.ReadLine();
        x = Convert.ToString(x);
        if (x == "1") { ShipBazaar(); }
        else if (x == "2") { CasinoOptions(player); }
        else if (x == "3") { InfoBooth(player); }  
        else
        {
            Console.WriteLine("Please enter either 1, 2, or 3.");
            MainArea(player);
        }
    
    }

    public static void InfoBooth(Player player)
    {
        Choices.Choice1(player);
    }

    public static void ShipBazaar()
    {

    }

    public static void Choice2Casino()
    {
        
    }

    public static void AfterChoice1()
    {
        Console.WriteLine("You walk into the ship bazaar and look around in awe at all of the ships");
        Console.WriteLine("Three ships grab your attention");

    }


    public static void CasinoOptions(Player player)
    {
        Console.WriteLine("\nWelcome to the Casino!\nCurrently our tables are down.");
        Console.Write("Would you like to test your luck at the slot machines? " +
            "\n\n1) Yep, I am feeling lucky! \n2) I think I will pass this time\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1") { Console.Clear(); Casino.CasinoSlots(player); }
        else if (input == "2")
        {
            Console.WriteLine("Ok, please come by later to test your luck. Have a great day!");
            MainArea(player);
        }
        else Console.WriteLine($"Please press either 1 or 2. {CasinoOptions}");
       
    }






}
