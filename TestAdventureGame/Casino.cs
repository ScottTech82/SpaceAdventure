using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SpaceAdventure;

public class Casino
{

    /* Comments, Ideas, and Bug List.
     * 
     * 
     * Ideas
     *  1. Add bets & winning/losing calculations.
     *  2. Create a blackjack table
     *  3. Poker tables will be closed for an upcoming tournament, unless I have time later to complete it.
     * 
     * 
     * BUG List
     *  1. The expert level slot machine will display you won if there are 2 matching pairs.
            ie.     | Star | Quasar | Quasar | Pulsar | Pulsar |
            Displays you won, but this is not 3 matches or more. 
            And is probably only if result1 does not match, since I did not specify all results having 3 or more.
                Tried to have a little less && statements. Probably have to add more.

     *  --Completed!-- 2. Selecting Ship Bazaar sends to the Casino, since I have not created the Method yet.
     *  
     */


    //update this to have a method that runs the simple slot machine with below code. Then make a medium one with 
    //more reels and maybe even a really hard one?

    public static void CasinoSlots(Player player)
    {
        //add in bet amounts and track in variables
        Console.WriteLine("You enter and read the sign.. \"Casino Slot Machines!\"" +
            "\nWe currently have two levels. The beginner level with 3 reels, and the expert with 5 reels");
        Console.Write("\nWhich would you like to play today?" +
            "\n1) Beginner\n2) Expert\n3) More information\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if(input == "1") { SimpleSlot(player); }
        else if (input == "2") { MedSlot(player); }
        else if (input == "3")
        {
            Console.WriteLine("\nAddional Info: The beginner level slot machine requires that you get 2 matches to win" +
                " and all 3 matches for the Jackpot.\nThe expert level slot machine requires 3 or 4 matches to win" +
                " and all 5 matches for the Jackpot.\nSince the medium level is harder, the payouts are larger.\n");
            CasinoSlots(player);
        }
        else
        {
            Console.WriteLine("Please enter either 1 or 2");
            CasinoSlots(player);
        }
    }


    public static void SimpleSlot(Player player)
    {

        Console.WriteLine("With the credits deposited, the reels begin to spin.");
        var result1 = SlotMachineSimple();
        Console.WriteLine($"\n  The first result is.... \n");
        Thread.Sleep(2000);
        Game.Dialog($"              | {result1} |    ?     |    ?     |", "green");

        //Console.WriteLine("The second column begins to spin.");
        var result2 = SlotMachineSimple();
        Console.WriteLine($"\n  The second result is.... \n");
        Thread.Sleep(2000);
        Game.Dialog($"              | {result1} | {result2} |    ?     |", "green");

        //Console.WriteLine("The third and final column begins to spin rapidly.");
        var result3 = SlotMachineSimple();
        Console.WriteLine($"\n  The third result is.... \n");
        Thread.Sleep(2000);
        Game.Dialog($"              | {result1} | {result2} | {result3} |", "green");
        //Console.ReadKey();


        if (result1 == result2 && result1 == result3)
        {
            //add in winnings variable and multiply it, putting the result in. 
            //the winnings will need to be added to the players total money in items.cs.
            Console.WriteLine("\nYOU WON!! Congratulations, enjoy your winnings!\n");
        }
        else if (result1 != result2 && result1 != result3 && result2 != result3)
        {
            //bet deducted from the total.
            Console.WriteLine("\nAww, better luck next time!\n");
        }
        else
        {
            Console.WriteLine("\nYou have two matches!\n");
        }
        Console.Write("---Press enter to continue---");
        Console.ReadKey();
        SlotChoice1(player);


    }

    public static void MedSlot(Player player)
    {

        Console.WriteLine("With the credits deposited, the reels begin to spin.");
        var result1 = SlotMachineMed();
        Console.WriteLine($"\n  The first result is.... \n");
        Thread.Sleep(2000);
        Game.Dialog($"              | {result1} |    ?     |    ?     |    ?     |    ?     |", "green");

        //Console.WriteLine("The second column begins to spin.");
        var result2 = SlotMachineMed();
        Console.WriteLine($"\n  The second result is.... \n");
        Thread.Sleep(2000);
        Game.Dialog($"              | {result1} | {result2} |    ?     |    ?     |    ?     |", "green");

        //Console.WriteLine("The third and final column begins to spin rapidly.");
        var result3 = SlotMachineMed();
        Console.WriteLine($"\n  The third result is.... \n");
        Thread.Sleep(2000);
        Game.Dialog($"              | {result1} | {result2} | {result3} |    ?     |    ?     |", "green");
        //Console.ReadKey();

        var result4 = SlotMachineMed();
        Console.WriteLine($"\n  The fourth result is.... \n");
        Thread.Sleep(2000);
        Game.Dialog($"              | {result1} | {result2} | {result3} | {result4} |    ?     |", "green");

        var result5 = SlotMachineMed();
        Console.WriteLine($"\n  The final result is.... \n");
        Thread.Sleep(2000);
        Game.Dialog($"              | {result1} | {result2} | {result3} | {result4} | {result5} |", "green");


        if (result1 == result2 && result1 == result3 && result1 == result4 && result1 == result5)
        {
            //add in winnings variable and multiply it, putting the result in. 
            //the winnings will need to be added to the players total money in items.cs.
            Console.WriteLine("\nYOU WON THE JACKPOT!! Congratulations, enjoy your winnings!\n");
        }
        else if (result1 != result2 && result1 != result3 && result2 != result3 && result1 != result4 
            && result2 != result4 && result3 != result4)
        {
            //bet deducted from the total.
            Console.WriteLine("\nAww, you did not have 3 or more matches. Better luck next time!\n");
        }
        
        else
        {
            Console.WriteLine("\nYou win! Congrats, and enjoy your winnings!\n");
        }
        Console.Write("---Press enter to continue---");
        Console.ReadKey();
        SlotChoice2(player);

    }



    //I need to call this method 3 times, one for each row.
    //that way the random should actually be randam all 3 times instead of all 3 at the same machine time.

    public static string SlotMachineSimple()
    {
        string[] selection = new string[] { "Asteroid", " Planet ", "  Star  ", " Nebula ", " Galaxy " };
        Random random = new Random();
        int rnd = random.Next(0, 5);

        var result = selection[rnd];
        return result;
    }

    public static string SlotMachineMed()
    {
        string[] selection = { "Asteroid", " Planet ", "  Star  ", " Nebula ", " Galaxy ", "SuperNova", " Pulsar ", " Quasar " };
        Random random = new Random();
        int rnd = random.Next(0, 8);

        var result = selection[rnd];
        return result;
    }


    public static void SlotChoice1(Player player)
    {
        Console.Clear();
        Game.Dialog("Would you like to try again?", "blue");
        Console.Write("1) Yes \n2) No thanks\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1")
        {
            Console.Clear();
            CasinoSlots(player);
        }
        else if (input == "2")
        {
            Console.WriteLine("\nThank you for playing, please come again.\n");
            Console.Write("Would you like to play a different slot machine or exit the Casino?" +
                "\n1) Different Slot Machine\n2) Exit the Casino\nResponse: ");
            var x = Console.ReadLine();
            x = Convert.ToString(x);
            if (x == "1") { CasinoSlots(player); }
            else if (x == "2") { Game.MainArea(player); }
        }
        else { Console.WriteLine($"Please press either 1 or 2."); SlotChoice1(player); }
    }


    public static void SlotChoice2(Player player)
    {
        Console.Clear();
        Game.Dialog("Would you like to try again?", "blue");
        Console.Write("1) Yes \n2) No thanks\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1")
        {
            Console.Clear();
            MedSlot(player);
        }
        else if (input == "2")
        {
            Console.WriteLine("\nThank you for playing, please come again.\n");
            Console.Write("Would you like to play a different slot machine or exit the Casino?" +
                "\n1) Different Slot Machine\n2) Exit the Casino\nResponse: ");
            var x = Console.ReadLine();
            x = Convert.ToString(x);
            if (x == "1") { CasinoSlots(player); }
            else if (x == "2") { Game.MainArea(player); }
        }
        else { Console.WriteLine($"Please press either 1 or 2."); SlotChoice2(player); }
    }




}

