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
     * Working in BlackJack
     *      It prints out The dealer will randomly choose whether their Ace will count as 1 or 10, twice.
     *      Then chose as 1. And shows dealer hand of Q | A | Q, 
     *      then says again the dealer will randomly choose whether their Ace will count as 1 or 10, again.
     *      
     * 
     * Ideas
     *  --Completed!-- 1. Add bets & winning/losing calculations.
     *  2. Create a blackjack table --working on currently.
     *  3. Poker tables will be closed for an upcoming tournament, unless I have time later to complete it.
     * 
     * 
     * BUG List
     *  --Completed!--  
     *  1. The expert level slot machine will display you won if there are 2 matching pairs.
            ie.     | Star | Quasar | Quasar | Pulsar | Pulsar |
            Displays you won, but this is not 3 matches or more. 
            And is probably only if result1 does not match, since I did not specify all results having 3 or more.
                Tried to have a little less && statements. Probably have to add more.

     *  --Completed!-- 2. Selecting Ship Bazaar sends to the Casino, since I have not created the Method yet.
     *  
     */



    public static void CasinoSlots(Player player)
    {
        //add in bet amounts and track in variables
        Console.WriteLine("You enter and read the sign.. \"Casino Slot Machines!\"" +
            "\nWe currently have two levels. The beginner level with 3 reels, and the expert with 5 reels");
        Console.Write("\nWhich would you like to play today?" +
            "\n1) Beginner\n2) Expert\n3) More information\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1") { SimpleSlot(player); }
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
        var betx = Bet(player);
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
            var multiplier = 5;
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
        var betx = Bet(player);
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

    public static decimal Bet(Player player)
    {
        Console.Write($"\nHow much are you willing to wager?");
        Game.Dialog($"\nYour current balance is {Player.PlayerCredits}", "blue");
        Console.Write("\nPlease enter an amount to bet.\nResponse: ");
        var x = Console.ReadLine();
        decimal intx = Convert.ToInt32(x);

        Player.RemoveCredits(intx, player);
        return intx;
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



    //the odds of randomly selecting the same number from the same array is slim, but possible.
    //need to think of a way to prevent this?

    //Need a method that allows the dealer to take another card if below a certain level,
    //but maybe, have it randomly choose, so the dealer isnt always super good? Need some mistakes coded in.

    //another issue is the ability to hit multiple times. Put the players cards and dealers cards in a list?

    public static void PlayBlackJack(Player player)
    {
        Console.WriteLine("\nWelcome to the BlackJack table!");

        Console.WriteLine("\nYou notice the dealer is a robot.  This might be tricky or maybe you could outsmart it.");
        var betx = Bet(player);
        Console.WriteLine("\n\nThe dealer begins to shuffle the cards.\n");

        var card1 = Cards.BlackJackCards();
        var suit1 = Cards.BlackJackSuit();
        Thread.Sleep(1000);
        var cardD1 = Cards.BlackJackCards();
        var suitD1 = Cards.BlackJackSuit();
        Thread.Sleep(500);
        var card2 = Cards.BlackJackCards();
        var suit2 = Cards.BlackJackSuit();
        Thread.Sleep(1000);
        var cardD2 = Cards.BlackJackCards();
        var suitD2 = Cards.BlackJackSuit();

        List<string> Pcards = new List<string>();
        Pcards.Add(card1);
        Pcards.Add(card2);
        List<string> Pcardsuit = new List<string>();
        Pcardsuit.Add(suit1);
        Pcardsuit.Add(suit2);
        List<string> Dcards = new List<string>();
        Dcards.Add(cardD1);
        Dcards.Add(cardD2);
        List<string> Dcardsuit = new List<string>();
        Dcardsuit.Add(suitD1);
        Dcardsuit.Add(suitD2);

        Console.WriteLine("After satisfied with the shuffle or according to their programming,\nthe dealer has begun dealing the cards out...");
        Thread.Sleep(1500);
        //probably separate the variable into a dialog for color. Change to console.write's.
        Console.Write($"\nThe first card dealt to you is a ");
        Game.Dialog($"| {Pcards[0]}{Pcardsuit[0]} |", "green");
        Thread.Sleep(3000);
        Console.Write($"\nThe dealer takes their first card face down and then deals your 2nd card, ");
        Game.Dialog($"| {Pcards[1]}{Pcardsuit[1]} |", "green");
        Thread.Sleep(3000);
        Console.Write($"The dealer's second card is placed face up showing, ");
        Game.Dialog($"| {Dcards[1]}{Dcardsuit[1]} |", "green");
        Thread.Sleep(3000);
        Console.Write($"\nYou look at your cards again before deciding what to do ");
        Game.Dialog($"| {Pcards[0]}{Pcardsuit[0]} | {Pcards[1]}{Pcardsuit[1]} |", "green");
        Console.WriteLine("\n\n---Please press enter to continue---");
        Console.ReadKey();
        BlackJackTurn(betx, Pcards, Dcards, Pcardsuit, Dcardsuit, player);


    }
    public static void BlackJackTurn(decimal betx, List<string> Pcards, List<string> Dcards, List<string> Pcardsuit, List<string> Dcardsuit, Player player)
    {

        var newC = BlackJackNewCard();
        var newS = Cards.BlackJackSuit();
        var card3 = "";
        if (newC == "hold")
        {
            Console.Write($"\nYou decide to hold with your current hand of ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var card in Pcards)
            {
                 Console.Write($"| {card} ");
            }
            Console.Write("|");
            Console.ResetColor();
            Thread.Sleep(1000);
            var newDcards = Cards.DealerHitHold(Dcards, player);
            Console.Write($"\nThe dealer shows their hand of ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var dcard in newDcards)
            {
                 Console.Write($"| {dcard} ");
            }
            Console.Write("|");
            Console.ResetColor();
            Thread.Sleep(1000);
            var pTotal = Cards.CardTotalPlayer(Pcards, player);
            var dTotal = Cards.CardTotalDealer(newDcards, player);
            BlackJackWinLose(betx, pTotal, dTotal, player);
        }
        else
        {
            Pcards.Add(newC);
            Pcardsuit.Add(newS);
            Console.Write("You now have ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var card in Pcards)
            {
                 Console.Write($"| {card} ");
            }
            Console.Write("|");
            Console.ResetColor();
            Console.WriteLine("\n\n---Please press enter to continue--");
            Console.ReadKey();
            var pTotal = Cards.CardTotalPlayer(Pcards, player);
            if(pTotal > 21)
            {
                var dTotal = Cards.CardTotalDealer(Dcards, player);
                BlackJackWinLose(betx, pTotal, dTotal, player);
            }
            else 
                BlackJackTurn(betx, Pcards, Dcards, Pcardsuit, Dcardsuit, player);
        }

    }

    public static string BlackJackNewCard()
    {
        Console.Write("\nWhat is your next move?\n1) Hit (request another card)\n2) Hold (keep your current cards)\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1")
        {
            Console.WriteLine("\nYou request another card.");
            var card3 = Cards.BlackJackCards();
            Thread.Sleep(2000);
            Console.Write($"\nThe dealer flips over another card, it's a ");
            Game.Dialog($"{card3}", "green");
            return card3;
        }
        else if (input == "2")
        {
            var hold = "hold";
            return hold;
        }
        else
        {
            Console.WriteLine("Please press either 1 or 2!");
            BlackJackNewCard();
        }
        var placeholder = "";
        return placeholder;
    }

    public static void BlackJackPlayAgain(Player player)
    {
        Console.Clear();
        Console.Write("Would you like to play BlackJack again?\n1) Yes\n2) No\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if(input == "1")
        {
            PlayBlackJack(player);
        }
        else if(input == "2")
        {
            Game.CasinoOptions(player);
        }
        else
        {
            Console.WriteLine("\nPlease enter either 1, or 2.");
            BlackJackPlayAgain(player);
        }
    }
   


    public static void BlackJackWinLose(decimal betx, int playerTotal, int dealerTotal, Player player)
    {

        Console.WriteLine($"\n\nYour total hand is {playerTotal} and the dealer's total hand is {dealerTotal}.");
        if (playerTotal > 21)
        {
            Console.WriteLine("\nBust! Your total card value exceeds 21.");
            Console.WriteLine("\n---Please press enter to continue---");
            Console.ReadKey();
            BlackJackPlayAgain(player); 
        }

        else if (playerTotal < dealerTotal)
        {
            Console.WriteLine("\nThe dealer's hand has totaled more than yours, Dealer wins.  Please try again.");
            Console.WriteLine("\n---Please press enter to continue---");
            Console.ReadKey();
            BlackJackPlayAgain(player);
        }
        else if (playerTotal > dealerTotal)
        {
            Console.WriteLine("\nCongratulations!  You beat the dealer and won this round!");
            decimal multiplier = 4M;
            decimal x = betx * multiplier;
            Player.AddCredits(x, player);
            Game.Dialog($"Your bet of {betx} x {multiplier} = {x}", "blue");
            Console.WriteLine("\n---Please press enter to continue---");
            Console.ReadKey();
            BlackJackPlayAgain(player);
        }
        else if (playerTotal == dealerTotal)
        {
            Console.WriteLine("\nUnfortunately a tie goes to the dealer.  Please try again.");
            Console.WriteLine("\n---Please press enter to continue---");
            Console.ReadKey();
            BlackJackPlayAgain(player);
        }

    }
}


