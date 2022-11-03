using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Slots
{



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


    public static void SimpleSlot(Player player)
    {
        var betx = Casino.Bet(player);
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
            var multiplier = 4;
            decimal x = betx * multiplier;
            Player.AddCredits(x, player);
            Game.Dialog($"Your bet of {betx} x {multiplier} = {x}", "blue");
        }
        else if (result1 != result2 && result1 != result3 && result2 != result3)
        {
            //bet deducted from the total.
            Console.WriteLine("\nAww, better luck next time!\n");
        }
        else
        {
            Console.WriteLine("\nYou have two matches!\n");
            var multiplier = 2;
            decimal x = betx * multiplier;
            Player.AddCredits(x, player);
            Game.Dialog($"Your bet of {betx} x {multiplier} = {x}", "blue");
        }
        Console.Write($"\nYour new credit balance is ");
        Game.Dialog($"{Player.PlayerCredits} credits.", "blue");
        Console.Write("\n---Press enter to continue---");
        Console.ReadKey();
        SlotChoice1(player);


    }

    public static void MedSlot(Player player)
    {
        var betx = Casino.Bet(player);
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
            var multiplier = 6;
            decimal x = betx * multiplier;
            Player.AddCredits(x, player);
            Game.Dialog($"Your bet of {betx} x {multiplier} = {x}", "blue");
        }
        else if (result1 != result2 && result1 != result3 && result1 != result4 && result1 != result5 ||
            result1 != result2 && result1 != result3 && result1 != result4 ||
            result1 != result2 && result1 != result3 && result1 != result5 ||
            result1 != result2 && result1 != result5 && result1 != result4 ||
            result1 != result5 && result1 != result3 && result1 != result4 ||
            result2 != result1 && result2 != result3 && result2 != result4 && result2 != result5 ||
            result2 != result1 && result2 != result3 && result2 != result4 ||
            result2 != result1 && result2 != result3 && result2 != result5 ||
            result2 != result1 && result2 != result5 && result2 != result4 ||
            result2 != result5 && result2 != result3 && result2 != result4 ||
            result3 != result1 && result3 != result2 && result3 != result4 && result3 != result5 ||
            result3 != result1 && result3 != result2 && result3 != result4 ||
            result3 != result1 && result3 != result2 && result3 != result5 ||
            result3 != result1 && result3 != result5 && result3 != result4 ||
            result3 != result5 && result3 != result2 && result3 != result4 ||
            result4 != result1 && result4 != result2 && result4 != result3 && result4 != result5 ||
            result4 != result1 && result4 != result2 && result4 != result5 ||
            result4 != result1 && result4 != result5 && result4 != result3 ||
            result4 != result5 && result4 != result2 && result4 != result3 ||
            result5 != result1 && result5 != result2 && result5 != result3 && result5 != result4 ||
            result5 != result1 && result5 != result2 && result5 != result4 ||
            result5 != result1 && result5 != result4 && result5 != result3 ||
            result5 != result4 && result5 != result2 && result5 != result3)
        {
            //bet deducted from the total.
            Console.WriteLine("\nAww, you did not have 3 or more matches. Better luck next time!\n");
        }
        //if 1

        else
        {
            Console.WriteLine("\nYou win! Congrats, and enjoy your winnings!\n");
            var multiplier = 3;
            decimal x = betx * multiplier;
            Player.AddCredits(x, player);
            Game.Dialog($"Your bet of {betx} x {multiplier} = {x}", "blue");
        }
        Console.Write($"\nYour new credit balance is ");
        Game.Dialog($"{Player.PlayerCredits} credits.", "blue");
        Console.Write("\n---Press enter to continue---");
        Console.ReadKey();
        SlotChoice2(player);

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
            Casino.CasinoSlots(player);
        }
        else if (input == "2")
        {
            Console.WriteLine("\nThank you for playing, please come again.\n");
            Console.Write("Would you like to play a different slot machine or exit the Casino?" +
                "\n1) Different Slot Machine\n2) Exit the Casino\nResponse: ");
            var x = Console.ReadLine();
            x = Convert.ToString(x);
            if (x == "1") { Casino.CasinoSlots(player); }
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
            if (x == "1") { Casino.CasinoSlots(player); }
            else if (x == "2") { Game.MainArea(player); }
        }
        else { Console.WriteLine($"Please press either 1 or 2."); SlotChoice2(player); }
    }


}
