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

    /* Comments, Ideas, and Bug List.
     * 
     * Keep it simple to start!
     * 
     * Ideas
     *  1. Move Title to its own class and call the method for it.  Maybe have other Titles down the road.
     *  
     *  2. ASCII draw a few ships, just 3 to start? In the items class?
     *      a. with differing stats and credit cost
     *      
     *  3. Casino used to obtain more credits for now.
     *  
     *  4. Can I create a small mini shooting game with the ship?
     * 
     *  See more Ideas in invidual classes.
     * 
     * 
     * BUGS!
     *  TBD -will be listed here.
     *  
     * 
     */





       
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

        Console.Write("As you walk into the entrance of the galactic trade hub.  The new arrival attendant welcomes you... \n");
        Game.Dialog($"\nAttendant:\"Hi-llo! and welcome to the Triangulum Galatic Trade Hub.\" " +
                $"\n\"What is your name?\"\n");
    }


    public static void NamePlayer(Player player)
    {

        Console.Write("Please enter a player name and press enter\nResponse:  ");
        PlayerName = Console.ReadLine()!;
        PlayerName = Convert.ToString(PlayerName)!;
        TextInfo myTi = new CultureInfo("en-US", false).TextInfo;
        PlayerName = myTi.ToTitleCase(PlayerName);


            if(string.IsNullOrEmpty(PlayerName))
            {
            Dialog("Attendant:\"Hmm.. no name, I will call you.. Astrotron, ruler of worlds!\"");
            Thread.Sleep(1000);
            Dialog("Attendant:\"Ok maybe just Astrotron.\"");
                PlayerName = "Astrotron";
            }
            else
        {
        Console.WriteLine(" ");
        Dialog("Attendant:\"That is a really cool name " + PlayerName + "!\"");

        }
        player.Name = PlayerName;
        Thread.Sleep(1000);
        Dialog("\n\"One of the traders left these credits for you to get started.\"\n\"You can always come check your balance anytime" +
            " at the information booth.\"");
        Player.AddCredits(50, player);
        Console.Write($"You received 50 credits and your current credit balance is: ");
        Dialog($"{Player.PlayerCredits}", "blue");
        Console.WriteLine("\n---Press enter to continue---");
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
        Console.Write("Where would you like to go?\n1) Information Booth\n2) Casino\n3) Ship Bazaar\nResponse: ");
        var x = Console.ReadLine();
        x = Convert.ToString(x);
        if (x == "1") { InfoBooth(player); }
        else if (x == "2") { CasinoOptions(player); }
        else if (x == "3") { ShipBazaar(player); }  
        else
        {
            Console.WriteLine("Please enter either 1, 2, or 3.");
            MainArea(player);
        }
    
    }

    public static void InfoBooth(Player player)
    {
        Dialog("Attendant:\"\nWould you like to check your current credit balance?\"");
        Console.Write("Please select your response\n1) Yes\n2) No\nResponse: ");
        var x = Console.ReadLine();
        x = Convert.ToString(x);
        if (x == "1")
        {
            Console.Write($"Your current balance is ");
            Dialog($"{Player.PlayerCredits} credits", "blue");
            if(Player.PlayerCredits <= 0)
            {
                Dialog("Here take 50 more credits on the house. Try not to lose it this time.");
                Player.AddCredits(50, player);
                Dialog($"\nCredit Balance = {Player.PlayerCredits} credits", "blue");
                Console.WriteLine("\n---Please press enter to continue---");
                Console.ReadKey();
                MainArea(player);
            }
            Console.WriteLine("---Please press enter to continue---");
            Console.ReadKey();
            MainArea(player);
        }
        else if (x == "2") { Choices.Choice1(player); }

        else
        {
            Console.WriteLine("Please enter either number 1, or 2.");
            InfoBooth(player);
        }
    }

    public static void ShipBazaar(Player player)
    {
        Console.Clear();
        Console.WriteLine("\nYou enter the ship bazaar.  There are traders everywhere selling ship parts, from top of the line\n" +
            " aftermarket upgrades, to thermal taped components that appear to be barely pieced together.");
        Console.Write("\nYou find the area selling space ships (thermal tape excluded) and decide to browse available products." +
            "\n\nWhich one would you like to view?\n\n1) The SS-Vwing\n2) The SS-Falcon\n3) The SS-Leviathan\n4) Or exit back to main hub\nResponse: ");
        var x = Console.ReadLine();
        x = Convert.ToString(x);
        if(x == "1")
        {
            Items.SSVwing();
            ShipBazaar(player);
        }
        else if(x == "2")
        {
            Items.SSFalcon();
            ShipBazaar(player);
        }
        else if(x == "3")
        {
            Items.SSLeviathan();
            ShipBazaar(player);
        }
        else if(x == "4")
        {
            MainArea(player);
        }
        else
        {
            Console.WriteLine("Please enter either 1, 2, 3, or 4");
            ShipBazaar(player);
        }

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
        Console.WriteLine("\nWelcome to the Casino!\nCurrently our tables are closed for an upcoming tournament.");
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
        else if (input == "8") { Casino.PlayBlackJack(player); } //temporary to test it out.
        else
        {
            Console.WriteLine($"Please press either 1 or 2. {CasinoOptions}");
        }
       
    }






}
