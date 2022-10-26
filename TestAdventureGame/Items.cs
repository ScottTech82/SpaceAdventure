using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Items
{

    public static void Vwing ()
    {

    string Ship1 = @"

        /\      /\
       /88\    /88\
      |    \/\/    |
      |     \/     |
       \ []    [] /
        \[]====[]/
           WWWW
     ";
    Game.Dialog(Ship1, "darkmagenta");
    }

    public static void BasicShip ()
    {

    string Ship2 = @"

            /\
           |  |
       /M  |  |  M\
      |88|_||||_|88|
      |88|=||||=|88|
       \W| VXXV |W/
            VV
     ";
        Game.Dialog(Ship2, "darkmagenta");
    }

    public static void ThirdShip ()
    {

    string Ship3 = @"
    
             /\
            /XX\
       /\  / ** \  /\
      /88\/  **  \/88\
     / ||    **    || \
     \ || _MMMMMM_ || /
      \11/ VVVVVV \11/
       \/   VVVV   \/
    ";
        Game.Dialog(Ship3, "darkmagenta");
    }



}
