using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Title
{
    public static void GameTitle()
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

        Game.Dialog(title, "darkmagenta");


        Game.Dialog("                                            Welcome to the Galaxy of Triangulum!", "green");
        Console.WriteLine("\n-----Press Enter to begin your adventure-----");
        Console.ReadKey();

    }


    public static void TradeHubTitle()
    {
        string tradehubtitle = @" 

         _____ ____  _     ____  ____  _____  _  ____    _____  ____  ____  ____  _____   _     _     ____ 
        /  __//  _ \/ \   /  _ \/   _\/__ __\/ \/   _\  /__ __\/  __\/  _ \/  _ \/  __/  / \ /|/ \ /\/  _ \
        | |  _| / \|| |   | / \||  /    / \  | ||  /      / \  |  \/|| / \|| | \||  \    | |_||| | ||| | //
        | |_//| |-||| |_/\| |-|||  \_   | |  | ||  \_     | |  |    /| |-||| |_/||  /_   | | ||| \_/|| |_\\
        \____\\_/ \|\____/\_/ \|\____/  \_/  \_/\____/    \_/  \_/\_\\_/ \|\____/\____\  \_/ \|\____/\____/
                 



            ";

        Game.Dialog(tradehubtitle, "green");

    }

    public static void CasinoTitle()
    {
        string castitle = @"

                      /$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$ /$$   /$$  /$$$$$$ 
                     /$$__  $$ /$$__  $$ /$$__  $$|_  $$_/| $$$ | $$ /$$__  $$
                    | $$  \__/| $$  \ $$| $$  \__/  | $$  | $$$$| $$| $$  \ $$
                    | $$      | $$$$$$$$|  $$$$$$   | $$  | $$ $$ $$| $$  | $$
                    | $$      | $$__  $$ \____  $$  | $$  | $$  $$$$| $$  | $$
                    | $$    $$| $$  | $$ /$$  \ $$  | $$  | $$\  $$$| $$  | $$
                    |  $$$$$$/| $$  | $$|  $$$$$$/ /$$$$$$| $$ \  $$|  $$$$$$/
                     \______/ |__/  |__/ \______/ |______/|__/  \__/ \______/ 
                                                          
    ";

        Game.Dialog(castitle, "green");


    }





}
