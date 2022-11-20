using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Items
{

    public string VwingStats { get; set; }
    public string FalconStats { get; set; }
    public string LevStats { get; set; }


 

    //Setting the VWingStats and want to be able to access it from outside this method below.  Should be able to set the value.

    public static void SSVwing (Player player)
    {
        Console.Clear();
    string Vwing = @"

        /\      /\
       /88\    /88\
      |    \/\/    |
      |     \/     |
       \ []    [] /
        \[]====[]/
           WWWW


      >The SS V-wing<
    ";
        
        string VwingStats = "Attack: 13\nDefense: 8\nSpeed: 13";


        Game.Dialog("\n\nThis is the SS V-wing an interceptor class attack ship.");
        Game.Dialog(Vwing, "darkmagenta");
 
        Game.Dialog($"{VwingStats}\nCost: 500 Credits");
        Game.Dialog("\n\nWould you like to purchase this one?", "blue");
        Console.Write("\n1) Yes\n2) No\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if(input == "1")
        {
            Player.AddShip(Vwing, VwingStats, player);
            Player.RemoveCredits(500, player);
            Game.MainArea(player);
        }else
        {
        Game.PressContinue();
        }
    }
    


    public static void SSFalcon (Player player)
    {
        Console.Clear();
    string Falcon = @"

            /\
           |  |
       /M  |  |  M\
      |88|_||||_|88|
      |88|=||||=|88|
       \W  VXXV  W/
            VV


      >The SS Falcon<
     ";
        string FalconStats = "Attack: 5\nDefense: 8\nSpeed: 8";


        Game.Dialog("\n\nThis is the SS Falcon a typical type of ship, with basic abilities.");
        Game.Dialog(Falcon, "darkmagenta");
        
        Game.Dialog($"{FalconStats}\nCost: 250 Credits");
        Game.Dialog("\n\nWould you like to purchase this one?", "blue");
        Console.Write("\n1) Yes\n2) No\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1")
        {
            Player.AddShip(Falcon, FalconStats, player);
            Player.RemoveCredits(250, player);
            Game.MainArea(player);
        }
        else
        {
            Game.PressContinue();
        }
    }



    public static void SSLeviathan (Player player)
    {
        Console.Clear();
    string Lev = @"

             /\
            |  |
            |XX|   
       /\  |XXXX|  /\
      /88\/  **  \/88\
     | ||   ****   || |
     | || _MMMMMM_ || |
      \11/ VVVVVV \11/
       VV   VVVV   VV
    

      >The SS Leviathan<
    ";

        string LevStats = "Attack: 21\nDefense: 13\nSpeed: 5";


        Game.Dialog("\n\nThis is the SS Leviathan a large capital class ship.");
        Game.Dialog(Lev, "darkmagenta");
        
        Game.Dialog($"{LevStats}\nCost: 1150 Credits");
        Game.Dialog("\n\nWould you like to purchase this one?", "blue");
        Console.Write("\n1) Yes\n2) No\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1")
        {
            Player.AddShip(Lev, LevStats, player);
            Player.RemoveCredits(1150, player);
            Game.MainArea(player);
        }
        else
        {
            Game.PressContinue();
        }
    }


    /* --just added to each ship for now, could make a separate method later.
     * 
    public static void PlayerPurchase ()
    {
        Game.Dialog("Would you like to purchase this one?", "blue");
        Console.WriteLine("Please select your response:\n1) Yes\n2) No\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if(input == "1")
        {

        }
        
    }
    */


}
