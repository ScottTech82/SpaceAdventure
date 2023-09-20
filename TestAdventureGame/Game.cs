using SpaceAdventure.CasinoMain;
using SpaceAdventure.ConsoleGfx;
using SpaceAdventure.Convos;
using SpaceAdventure.Items;
using SpaceAdventure.PlayerCharacter;
using SpaceAdventure.SpaceBattles;
using System.Globalization;

namespace SpaceAdventure;

public class Game
{


    static string PlayerName = "";


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
            Thread.Sleep(500);
            Dialog("\"Ok maybe just Astrotron.\"");
                PlayerName = "Astrotron";
            }
            else
        {
        Console.WriteLine(" ");
        Dialog("Attendant:\"That is a really cool name " + PlayerName + "!\"");

        }
        player.Name = PlayerName;
        Thread.Sleep(500);
        Dialog("\n\"One of the traders left these credits for you to get started.\"\n\"You can always come check your balance anytime" +
            " at the information booth.\"");
        player.AddCredits(50, player);
        
        Thread.Sleep(1000);
        Dialog($"\nPlayer credit balance = {player.PlayerCredits} credits", "blue");
        PressContinue();
        Console.Clear();
    }



    public static void PressContinue()
    {
        Dialog("\n\n---Please press enter to continue---", "darkyellow");
        Console.ReadKey();
    }

    public static void PressContinueEncounter()
    {
        Dialog("---Please press enter to continue---", "darkyellow");
        Console.ReadKey();
    }


    public static void MainArea(Player player)
    {
        Console.Clear();
        Title.TradeHubTitle();
        Console.WriteLine("** You are currently in the main hub next to the information booth. **\n");
        Dialog("\nWhere would you like to go?", "blue");
        if (player.PlayerShip == null)
        {
            Console.Write("\n1) Information Booth (check credit balance or current ship)\n2) The Casino\n3) The Ship Bazaar\n\nResponse: ");
        }
        else
        {
            Console.Write("\n1) Information Booth (check credit balance or current ship)\n2) The Casino" +
                "\n3) The Ship Bazaar\n4) Leave the Galactic Trade Hub \n\nResponse: ");
        }
        var x = Console.ReadLine();
        x = Convert.ToString(x);
        if (x == "1") { InfoBooth(player); }
        else if (x == "2") 
        {
            ICasino casino = new Casino(player);
            casino.CasinoOptions(player); 
        }
        else if (x == "3") { ShipBazaar(player); }  
        else if (x == "4" && player.PlayerShip != null) { LocalSolarSystem(player); }
        else if (x == "4" && player.PlayerShip == null) 
        { 
            Console.WriteLine("Please enter either 1, 2, or 3.");
            MainArea(player);
        }
        else if (x == "8") { Encounter.EncounterFirst(player); }
        else
        {
            Console.WriteLine("Please enter either 1, 2, or 3.");
            MainArea(player);
        }
    
    }

    public static void InfoBooth(Player player)
    {
        Dialog("\nAttendant:\"Would you like to check your current credit balance or see your space ship?\"");
        Console.Write("\nPlease select your response\n1) Check Balance\n2) See Space Ship\n3) Neither\n\nResponse: ");
        var x = Console.ReadLine();
        x = Convert.ToString(x);
        if (x == "1")
        {
            player.PlayerBalance(player);

            if(player.PlayerCredits <= 0)
            {
                Dialog("\"Here take 50 more credits on the house. Try not to lose it this time.\"");
                player.AddCredits(50, player);
                player.PlayerBalance(player);
                PressContinue();
                Choices.Choice1(player);
            }
            PressContinue();
            MainArea(player);
        }
        else if (x == "2")
        {
            Console.Clear();
            player.CheckShip(player);
            PressContinue();
            MainArea(player);
        }
        else if (x == "3") { Choices.Choice1(player); }

        else
        {
            Console.WriteLine("Please enter either number 1, or 2.");
            InfoBooth(player);
        }
    }

    public static void ShipBazaar(Player player)
    {
        Console.Clear();
        if(player.visitShipBazaar == false)
        {
            Console.WriteLine("\nYou enter the ship bazaar.  There are traders everywhere selling ship parts, from top of the line\n" +
            "aftermarket upgrades, to thermal taped components that appear to be barely pieced together.");
            Thread.Sleep(1000);
            Console.WriteLine("\nYou find the area selling space ships (thermal tape excluded) and decide to browse available products.");
            player.visitShipBazaar = true;
            Console.WriteLine("Welcome to the Ship Bazaar.");
        }
        else
        {
            Console.WriteLine($"Welcome back to the Ship Bazaar {player.Name}.");
        }
        if(player.PlayerShip != null)
        {
            Console.WriteLine("I see you already have a registered ship, would you like to sell it or browse the currently available options?");
            Console.Write("\n1) Sell Ship\n2)Looking to Browse\nResponse: ");
            var input = Console.ReadLine();
            input = Convert.ToString(input);
            if(input == "1") { player.SellShip(player); }
        }
        Game.Dialog("\nWhich ship would you like to view?", "blue");
        Console.Write("\n1) The SS V-wing\n2) The SS Falcon\n3) The SS Leviathan\n4) The SS B1\n5) Exit back to main hub\n\nResponse: ");
        var x = Console.ReadLine();
        x = Convert.ToString(x);
        if(x == "1")
        {
            SpaceShips.SSVwing(player);
            ShipBazaar(player);
        }
        else if(x == "2")
        {
            SpaceShips.SSFalcon(player);
            ShipBazaar(player);
        }
        else if(x == "3")
        {
            SpaceShips.SSLeviathan(player);
            ShipBazaar(player);
        }
        else if(x == "4")
        {
            SpaceShips.SSB1(player);
            ShipBazaar(player);
        }        
        else if(x == "5")
        {
            MainArea(player);
        }
        else
        {
            Console.WriteLine("Please enter a valid response");
            ShipBazaar(player);
        }

    }


    public static void LocalSolarSystem(Player player)
    {
        Console.WriteLine("\nYou decide to leave the Galactic Trade Hub and see what awaits you in the local solar system.");
        Game.Dialog($"\n{player.Name}'s {player.PlayerShip} takes off from the trade hub and requests a destination for the nav system.");
        Game.Dialog($"\nPlease select a location.", "blue");
        Console.Write("\n----Work in Progress. Stay tuned.----");
    }

    public static void Dialog(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void Dialog(string message, string color)
    {
        switch (color)
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
            case "darkred":
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            case "darkyellow":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case "darkgreen":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case "gray":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            case "darkcyan":
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine(message);
        Console.ResetColor();
    }







}
