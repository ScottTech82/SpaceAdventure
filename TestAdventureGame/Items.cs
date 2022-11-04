using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Items
{

   

    public static void SSVwing ()
    {
        Console.Clear();
    string Ship1 = @"

        /\      /\
       /88\    /88\
      |    \/\/    |
      |     \/     |
       \ []    [] /
        \[]====[]/
           WWWW
     ";
        Game.Dialog("\n\nThis is the SS V-wing an interceptor class attack ship.");
        Game.Dialog(Ship1, "darkmagenta");
 
        Game.Dialog("Attack: 13\nDefense: 8\nSpeed: 13\nCost: 500 Credits");
        Game.PressContinue();
    }
    

    public static void SSFalcon ()
    {
        Console.Clear();
    string Ship2 = @"

            /\
           |  |
       /M  |  |  M\
      |88|_||||_|88|
      |88|=||||=|88|
       \W  VXXV  W/
            VV
     ";
        Game.Dialog("\n\nThis is the SS Falcon a typical type of ship, with basic abilities.");
        Game.Dialog(Ship2, "darkmagenta");
        
        Game.Dialog("Attack: 5\nDefense: 8\nSpeed: 8\nCost: 250 Credits");
        Game.PressContinue();
    }

    public static void SSLeviathan ()
    {
        Console.Clear();
    string Ship3 = @"
    
             /\
            |  |
            |XX|   
       /\  |XXXX|  /\
      /88\/  **  \/88\
     | ||   ****   || |
     | || _MMMMMM_ || |
      \11/ VVVVVV \11/
       VV   VVVV   VV
    ";
        Game.Dialog("\n\nThis is the SS Leviathan a large capital class ship.");
        Game.Dialog(Ship3, "darkmagenta");
        
        Game.Dialog("Attack: 21\nDefense: 13\nSpeed: 5\nCost: 1150 Credits");
        Game.PressContinue();
    }



}
