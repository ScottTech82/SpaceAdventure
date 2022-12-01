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



    public static decimal Bet(Player player)
    {
        Console.Write($"\nHow much are you willing to wager?");
        Player.PlayerBalance(player);
        Console.Write("\nPlease enter an amount to bet.\nResponse: ");
        var x = Console.ReadLine();
        decimal intx = Convert.ToDecimal(x);

        Player.RemoveCredits(intx, player);
        return intx;
    }


    public static void CasinoSlots(Player player)
    {
       
        Console.WriteLine("You enter and read the sign.. \"Casino Slot Machines!\"" +
            "\nWe currently have two levels. The beginner level with 3 reels, and the expert with 5 reels");
        Console.Write("\nWhich would you like to play today?" +
            "\n1) Beginner\n2) Expert\n3) More information\n4) Exit\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1") { Slots.SimpleSlot(player); }
        else if (input == "2") { Slots.MedSlot(player); }
        else if (input == "3")
        {
            Console.WriteLine("\nAddional Info: The beginner level slot machine requires that you get 2 matches to win" +
                " and all 3 matches for the Jackpot.\nThe expert level slot machine requires 3 or 4 matches to win" +
                " and all 5 matches for the Jackpot.\nSince the medium level is harder, the payouts are larger.\n");
            CasinoSlots(player);
        }
        else if (input == "4")
        {
            Game.CasinoOptions(player);
        }
        else
        {
            Console.WriteLine("Please enter either 1 or 2");
            CasinoSlots(player);
        }
    }



    public static void PlayBlackJack(Player player)
    {
        Console.WriteLine("\nWelcome to the BlackJack table!");
        Console.WriteLine("\nThe robotic dealer greets you and waits for your bet before continuing.");
        var betx = Bet(player);
        Console.WriteLine("\n\nThe dealer begins to shuffle the cards.");
        Console.WriteLine("  (please do not press enter..)\n");
        
        
        var cardP1 = Cards.BlackJackCards();
        
        Thread.Sleep(500);
        var cardD1 = Cards.BlackJackCards();
        
        Thread.Sleep(500);
        var cardP2 = Cards.BlackJackCards();
       
        Thread.Sleep(500);
        var cardD2 = Cards.BlackJackCards();
        

        List<string> Pcards = new() { cardP1};
        cardP2 = Cards.ChkCardDup(cardP1, cardP2);
        Pcards.Add(cardP2);


        List<string> Dcards = new() { cardD1};
        cardD2 = Cards.ChkCardDup(cardD1, cardD2);
        Dcards.Add(cardD2);

        /*
        Console.WriteLine("After satisfied with the shuffle or according to their programming,\nthe dealer has begun dealing the cards out...");
        Thread.Sleep(1500);
        
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

        Game.PressContinue();
        BlackJackTurn(betx, Pcards, Dcards, Pcardsuit, Dcardsuit, player);
        */
        Console.WriteLine("After satisfied with the shuffle or according to their programming,\nthe dealer has begun dealing the cards out...");
        Thread.Sleep(1500);

        Console.Write($"\nThe first card dealt to you is a ");
        Game.Dialog($"| {Pcards[0]} |", "green");
        Thread.Sleep(3000);

        Console.WriteLine($"\nThe dealer takes their first card face down.");
        Console.Write("\nThen deals your 2nd card ");
        Game.Dialog($"| {Pcards[1]} |", "green");
        Thread.Sleep(3000);

        Console.Write($"The dealer's second card is placed face up showing, ");
        Game.Dialog($"| {Dcards[1]} |", "green");
        Thread.Sleep(3000);

        Console.Write($"\nYou look at your cards again before deciding what to do ");
        Game.Dialog($"| {Pcards[0]} | {Pcards[1]} |", "green");

        Game.PressContinue();
        BlackJackTurn(betx, Pcards, Dcards, player);

    }
    //removed List<string>Pcardsuit & List<string>Dcardsuit.  Above removed the passing in Pcardsuit & Dcardsuit.
    public static void BlackJackTurn(decimal betx, List<string> Pcards, List<string> Dcards, Player player)
    {

        var newC = BlackJackNewCard();
        newC = Cards.ChkCardExists(newC, Pcards);
        /* var newS = Cards.BlackJackSuit(); */

        if (newC == "hold")
        {
            Console.Clear();
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
            /* Pcardsuit.Add(newS); */
            Console.Write("You now have ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var card in Pcards)
            {
                 Console.Write($"| {card} ");
            }
            Console.Write("|");
            Console.ResetColor();
            Game.PressContinue();
            var pTotal = Cards.CardTotalPlayer(Pcards, player);
            if(pTotal > 21)
            {
                var dTotal = Cards.CardTotalDealer(Dcards, player);
                BlackJackWinLose(betx, pTotal, dTotal, player);
            }
            else 
                BlackJackTurn(betx, Pcards, Dcards, player); //removed Pcardsuit & Dcardsuit
        }

    }

    public static string BlackJackNewCard()
    {
        Console.Write("\nWhat is your next move?\n1) Hit (request another card)\n2) Hold (keep your current cards)\n\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1")
        {
            Console.WriteLine("\nYou request another card.");
            var card3 = Cards.BlackJackCards(); //deck.Pop();
            Thread.Sleep(1000);
            Console.Write($"\nThe dealer flips over another card, it's a ");
            Game.Dialog($"| {card3} |", "green");
            Thread.Sleep(1000);
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
        Console.Write("Would you like to play BlackJack again?\n1) Yes\n2) No\n\nResponse: ");
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
            Player.PlayerBalance(player);
            Game.PressContinue();
            BlackJackPlayAgain(player); 
        }

        else if (dealerTotal > 21)
        {
            Console.WriteLine($"\nThe dealers total of {dealerTotal} exceeds 21, the dealer has busted!");
            decimal multiplier = 7M;
            decimal x = betx * multiplier;
            Player.AddCredits(x, player);
            Game.Dialog($"Your bet of {betx} x {multiplier} = {x} credits", "blue");
            Player.PlayerBalance(player);
            Game.PressContinue();
            BlackJackPlayAgain(player);
        }

        else if (playerTotal < dealerTotal)
        {
            Console.WriteLine("\nThe dealer's hand has totaled more than yours, Dealer wins.  Please try again.");
            Player.PlayerBalance(player);
            Game.PressContinue();
            BlackJackPlayAgain(player);
        }
        else if (playerTotal > dealerTotal)
        {
            Console.WriteLine("\nCongratulations!  You beat the dealer and won this round!");
            decimal multiplier = 7M;
            decimal x = betx * multiplier;
            Player.AddCredits(x, player);
            Game.Dialog($"Your bet of {betx} x {multiplier} = {x} credits", "blue");
            Player.PlayerBalance(player);
            Game.PressContinue();
            BlackJackPlayAgain(player);
        }
        else if (playerTotal == dealerTotal)
        {
            Console.WriteLine("\nUnfortunately a tie goes to the dealer.  However, your bet has been returned back to you.");
            Player.AddCredits(betx, player);
            Game.Dialog($"Your bet of {betx} credits has been returned to you.", "blue");
            Player.PlayerBalance(player);
            Game.PressContinue();
            BlackJackPlayAgain(player);
        }

    }


    public static void PlayPazaak(Player player)
    {

        //need to get new cards if they do not stand.  If they stand, no new cards but other player gets new cards.
        List<string> PlayerDealt = new List<string>();
        List<string> CompDealt= new List<string>();
        Game.Dialog("Welcome to the secret underground game of Pazaak!", "green");
        Game.Dialog("\nThis game was brought here by a vistor, from what they described as a galaxy, far, far away...");
        Game.Dialog("\n\nAnyway, the rules are simple. Get 20 points without going over.  " +
            "\nThe dealer deals a new card to you each turn unless you stand.  Your opponent can continue to draw until they stand." +
            "\nThe person with the highest total without going over wins the round. Win 3 rounds and you win the match.");
        Game.Dialog("\nThere is a side deck of 4 cards randomly drawn that you can use to raise or lower your total.");
        if(player.PazSideDeck.Count == 0)
        {
            Game.Dialog("\nYou get a basic side deck for free. You can add to it with better cards as you find them.");
            player.PazSideDeck.Add("+1");
            player.PazSideDeck.Add("+2");
            player.PazSideDeck.Add("+3");
            player.PazSideDeck.Add("+4");
            Console.WriteLine("\n***You received the +1, +2, +3, +4 cards in your side deck.***");
        }
        player.PazStand = false;
        player.PazCompStand= false;
        player.PazT1Card= false;
        var pSideDeck = PazSideDeck(player);
        var cSideDeck = PazCompEasySD();
        Game.PressContinue();
        PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);


    }


    public static void PazGamePlay(Player player, List<string>PlayerDealt, List<string>CompDealt, List<string>pSideDeck, List<string>cSideDeck)
    {
        Console.Clear();
        PazTotalTitle(player, PlayerDealt, CompDealt);

        
        Console.WriteLine($"\n\nThese are the cards currently dealt to each player.");

        Game.Dialog($"\n{player.Name}: ");
        Console.ForegroundColor= ConsoleColor.Green;
        foreach(var p in PlayerDealt)
        {
            Console.Write($"| {p} ");
        }
        Console.Write($"|");
        Console.ResetColor();

        Game.Dialog($"\n\nOpponent: ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var c in CompDealt)
        {
            Console.Write($"| {c} ");
        }
        Console.Write($"|");
        Console.ResetColor();
 
        //if(player.PazT1Card == false)
        //{
        //    player.PazT1Card = true;
        //    PazPlayerCard(player, PlayerDealt, CompDealt);
        //}
        //else 
        PazPlayerTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);


        



    }

    public static void PazPlayerTurn(Player player, List<string>PlayerDealt, List<string>CompDealt, List<string>pSideDeck, List<string>cSideDeck)
    {
        if(PlayerDealt.Count == 0 && CompDealt.Count == 0) 
        {
            PazPlayerCard(player, PlayerDealt, CompDealt);
            PazCompCard(player, PlayerDealt, CompDealt);
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }

        Game.Dialog($"\n\n\nThis is your dealt side deck ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach(var c in pSideDeck)
        {
            Console.Write($"| {c} ");
        }
        Console.Write("|");
        Console.ResetColor();
        Game.Dialog("\nWould you like to Continue drawing cards, Stand at this amount, or use your side deck?", "blue");
        Console.Write("\n1) Continue\n2) Stand\n3) Side Deck\n\nResponse: ");

        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1" && player.PazCompStand == false)
        {
            PazPlayerCard(player, PlayerDealt, CompDealt);
            PazCompTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        else if (input == "1" && player.PazCompStand == true)
        {
            PazPlayerCard(player, PlayerDealt, CompDealt);
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        else if (input == "2" && player.PazCompStand == false)
        {
            Console.WriteLine("\nYou stand with your current total, your opponents turn will continue until they stand.");
            player.PazStand = true;
            Game.PressContinue();
            PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        else if (input == "2" && player.PazCompStand == true)
        {
            Console.WriteLine("\nYou stand with your current total and your opponent has already decided to stand with their total");
            player.PazStand = true;
            Game.PressContinue();
            PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        else
        {
            Console.WriteLine("Please enter a valid response");
            PazPlayerTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
    }

    public static void PazCompTurn(Player player, List<string>PlayerDealt, List<string>CompDealt, List<string>pSideDeck, List<string>cSideDeck)
    {
        var cTotal = Cards.PazTotal(player, CompDealt);
        if (cTotal < 16 && player.PazStand == false)
        {
            PazCompCard(player, PlayerDealt, CompDealt);
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        else if(cTotal < 16 && player.PazStand == true)
        {
            PazCompCard(player, PlayerDealt, CompDealt);
            PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
            //Thinking of just putting PazGamePlayer here with a note that the Opponent stands.
            //but want to only say it once, so maybe create a boolean in the class, set to false default
        else if(cTotal >= 16 && player.PazCompStand == false && player.PazStand == false)
        {
            player.PazCompStand = true;
            Console.WriteLine($"\nYour oppenent has decided to stand at {cTotal}");
            Game.PressContinue();
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        else if (cTotal >= 16 && player.PazCompStand == false && player.PazStand == true)
        {
            player.PazCompStand = true;
            Console.WriteLine($"\nYour oppenent has decided to stand at {cTotal}");
            Game.PressContinue();
            PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        else 
        {
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        
    }

    public static List<string> PazPlayerCard(Player player, List<string>PlayerDealt, List<string>CompDealt)
    {
        var p = Cards.PazaakDealCards();
        PlayerDealt.Add(p);
        //may want to update to return 
        return PlayerDealt;
        //PazGamePlay(player, PlayerDealt, CompDealt);
    }

    public static List<string> PazCompCard(Player player, List<string>PlayerDealt, List<string>CompDealt)
    {
        var c = Cards.PazaakDealCards();
        CompDealt.Add(c);
        return CompDealt;
        //PazGamePlay(player, PlayerDealt, CompDealt);
    }

    public static void PazStand(Player player, List<string>PlayerDealt, List<string>CompDealt, List<string>pSideDeck, List<string>cSideDeck)
    {
        Console.Clear();
        PazTotalTitle(player, PlayerDealt, CompDealt);

        Console.WriteLine($"\n\nThese are the cards currently dealt to each player.");
        Game.Dialog($"\n{player.Name}: ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var p in PlayerDealt)
        {
            Console.Write($"| {p} ");
        }
        Console.Write($"|");
        Console.ResetColor();

        Game.Dialog($"\n\nOpponent: ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var c in CompDealt)
        {
            Console.Write($"| {c} ");
        }
        Console.Write($"|");
        Console.ResetColor();

        if(player.PazCompStand == false)
        {
            PazCompTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }
        else
        {
            PazEndGame(player, PlayerDealt, CompDealt);
        }

    }

    public static void PazEndGame(Player player, List<string>PlayerDealt, List<string>CompDealt)
    {
        Console.Clear();
        PazTotalTitle(player, PlayerDealt, CompDealt);
        var pTotal = Cards.PazTotal(player, PlayerDealt);
        var cTotal = Cards.PazTotal(player, CompDealt);
        if (pTotal > 20)
        {
            Console.WriteLine("\n\nYou bust by going over 20 total points!");
            Game.PressContinue();
            Game.CasinoOptions(player);
        }
        else if (cTotal > 20)
        {
            Console.WriteLine("\n\nYour opponent has busted by going over 20 total points. You Win!!");
            Game.PressContinue();
            Game.CasinoOptions(player);
        }
        else if (pTotal > cTotal)
        {
            Console.WriteLine("\n\nYour total is higher than your opponents without busting. You WIN!!");
            Game.PressContinue();
            Game.CasinoOptions(player);
        }
        else if (pTotal < cTotal)
        {
            Console.WriteLine("\n\nYour Opponent's total is higher than yours. Please try again.");
            Game.PressContinue();
            Game.CasinoOptions(player);
        }
    }

    public static void PazTotalTitle(Player player, List<string>PlayerDealt, List<string>CompDealt)
    {
        var pTotal = Cards.PazTotal(player, PlayerDealt);
        var cTotal = Cards.PazTotal(player, CompDealt);
        Game.Dialog($"|| {player.Name}'s Total = {pTotal} || <-> || Opponent's Total = {cTotal} ||");
    }

    public static List<string> PazSideDeck(Player player)
    {
        List<string> NewSideDeck = new List<string>();
        var count = player.PazSideDeck.Count();
        while(NewSideDeck.Count < 4 )
        {
            Random random = new Random();
            var r = random.Next(0, count +1);
            var sidecard = player.PazSideDeck[r];
            NewSideDeck.Add(sidecard);
            Thread.Sleep(500);
        }


        return NewSideDeck;
    }

    //create multiple comp side decks scaled for difficulty
    public static List<string> PazCompEasySD()
    {
        List<string> CompSideDeck = new List<string> { "+1", "+2", "+3", "+5" };
        return CompSideDeck;
    }
    

}


