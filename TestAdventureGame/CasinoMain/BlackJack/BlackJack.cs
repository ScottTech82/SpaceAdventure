using SpaceAdventure.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.CasinoMain.BlackJack
{
    public class BlackJack : IBlackJack
    {

        private readonly Player player;
        
        public BlackJack(Player player)
        {
            this.player = player;
        }


        public void PlayingBlackJack(Player player)
        {
            Console.WriteLine("\nWelcome to the BlackJack table!");
            Console.WriteLine("\nThe robotic dealer greets you and waits for your bet before continuing.");
            ICasino casino = new Casino(player);
            var betx = casino.Bet(player);
            Console.WriteLine("\n\nThe dealer begins to shuffle the cards.");
            Console.WriteLine("  (please do not press enter..)\n");


            var cardP1 = Cards.BlackJackCards();

            Thread.Sleep(500);
            var cardD1 = Cards.BlackJackCards();

            Thread.Sleep(500);
            var cardP2 = Cards.BlackJackCards();

            Thread.Sleep(500);
            var cardD2 = Cards.BlackJackCards();


            List<string> Pcards = new() { cardP1 };
            cardP2 = Cards.ChkCardDup(cardP1, cardP2);
            Pcards.Add(cardP2);


            List<string> Dcards = new() { cardD1 };
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
        public void BlackJackTurn(decimal betx, List<string> Pcards, List<string> Dcards, Player player)
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
                if (pTotal > 21)
                {
                    var dTotal = Cards.CardTotalDealer(Dcards, player);
                    BlackJackWinLose(betx, pTotal, dTotal, player);
                }
                else
                    BlackJackTurn(betx, Pcards, Dcards, player); //removed Pcardsuit & Dcardsuit
            }

        }

        public string BlackJackNewCard()
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

        public void BlackJackPlayAgain(Player player)
        {
            Console.Clear();
            Console.Write("Would you like to play BlackJack again?\n1) Yes\n2) No\n\nResponse: ");
            var input = Console.ReadLine();
            input = Convert.ToString(input);
            ICasino casino = new Casino(player);
            if (input == "1")
            {
                casino.PlayBlackJack(player);
            }
            else if (input == "2")
            {
                casino.CasinoOptions(player);
            }
            else
            {
                Console.WriteLine("\nPlease enter either 1, or 2.");
                BlackJackPlayAgain(player);
            }
        }



        public void BlackJackWinLose(decimal betx, int playerTotal, int dealerTotal, Player player)
        {

            Console.WriteLine($"\n\nYour total hand is {playerTotal} and the dealer's total hand is {dealerTotal}.");
            if (playerTotal > 21)
            {
                Console.WriteLine("\nBust! Your total card value exceeds 21.");
                player.PlayerBalance(player);
                Game.PressContinue();
                BlackJackPlayAgain(player);
            }

            else if (dealerTotal > 21)
            {
                Console.WriteLine($"\nThe dealers total of {dealerTotal} exceeds 21, the dealer has busted!");
                decimal multiplier = 7M;
                decimal x = betx * multiplier;
                player.AddCredits(x, player);
                Game.Dialog($"Your bet of {betx} x {multiplier} = {x} credits", "blue");
                player.PlayerBalance(player);
                Game.PressContinue();
                BlackJackPlayAgain(player);
            }

            else if (playerTotal < dealerTotal)
            {
                Console.WriteLine("\nThe dealer's hand has totaled more than yours, Dealer wins.  Please try again.");
                player.PlayerBalance(player);
                Game.PressContinue();
                BlackJackPlayAgain(player);
            }
            else if (playerTotal > dealerTotal)
            {
                Console.WriteLine("\nCongratulations!  You beat the dealer and won this round!");
                decimal multiplier = 7M;
                decimal x = betx * multiplier;
                player.AddCredits(x, player);
                Game.Dialog($"Your bet of {betx} x {multiplier} = {x} credits", "blue");
                player.PlayerBalance(player);
                Game.PressContinue();
                BlackJackPlayAgain(player);
            }
            else if (playerTotal == dealerTotal)
            {
                Console.WriteLine("\nUnfortunately a tie goes to the dealer.  However, your bet has been returned back to you.");
                player.AddCredits(betx, player);
                Game.Dialog($"Your bet of {betx} credits has been returned to you.", "blue");
                player.PlayerBalance(player);
                Game.PressContinue();
                BlackJackPlayAgain(player);
            }

        }

    }
}
