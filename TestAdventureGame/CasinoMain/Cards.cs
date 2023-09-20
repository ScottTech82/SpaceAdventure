using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using SpaceAdventure.PlayerCharacter;

namespace SpaceAdventure.CasinoMain;

public class Cards
{

    public string Card { get; set; }
    public string Suit { get; set; }

    public override string ToString()
    {
        return Card + Suit;
    }



    public static string BlackJackCards()
    {

        string[] cards = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        Random rand = new Random();
        Thread.Sleep(500);
        var xxr = rand.Next(0, 13);
        var card = cards[xxr];

        string[] cardsuit = new string[] { "♥", "♦", "♠", "♣" };
        Random rands = new Random();
        Thread.Sleep(500);
        var xr = rands.Next(0, 4);
        var suit = cardsuit[xr];

        return card + suit;


    }
    /*
    public static string BlackJackSuit()
    {

        string[] cardsuit = new string[] { "♥", "♦", "♠", "♣" };
        Random rand = new Random();
        Thread.Sleep(500);
        var xr = rand.Next(0, 4);
        var suit = cardsuit[xr];
        return suit;
    }
    */

    public static List<string> DealerHitHold(List<string> Dcards, Player player)
    {
        var x = CardTotalDealer(Dcards, player);

        if (x >= 16)
        {
            return Dcards;
        }

        else
        {
            var newDcard = BlackJackCards(); //deck.Pop();
            newDcard = ChkCardExists(newDcard, Dcards);
            Dcards.Add(newDcard);
            DealerHitHold(Dcards, player);
        }
        return Dcards;

    }

    public static string ChkCardDup(string card1, string card2)
    {
        if (card2 == card1)
        {
            card2 = BlackJackCards();
            ChkCardDup(card1, card2);
        }
        return card2;
    }

    public static string ChkCardExists(string card, List<string> cards)
    {
        if (cards.Contains(card))
        {
            card = BlackJackCards();
            ChkCardExists(card, cards);
        }
        return card;
    }

    public static int CardTotalPlayer(List<string> Pcards, Player player)
    {

        List<int> playerCalc = new List<int>();

        foreach (var card in Pcards)
        {
            switch (card)
            {

                case "2♥":
                case "2♦":
                case "2♠":
                case "2♣":
                    playerCalc.Add(2);
                    break;
                case "3♥":
                case "3♦":
                case "3♠":
                case "3♣":
                    playerCalc.Add(3);
                    break;
                case "4♥":
                case "4♦":
                case "4♠":
                case "4♣":
                    playerCalc.Add(4);
                    break;
                case "5♥":
                case "5♦":
                case "5♠":
                case "5♣":
                    playerCalc.Add(5);
                    break;
                case "6♥":
                case "6♦":
                case "6♠":
                case "6♣":
                    playerCalc.Add(6);
                    break;
                case "7♥":
                case "7♦":
                case "7♠":
                case "7♣":
                    playerCalc.Add(7);
                    break;
                case "8♥":
                case "8♦":
                case "8♠":
                case "8♣":
                    playerCalc.Add(8);
                    break;
                case "9♥":
                case "9♦":
                case "9♠":
                case "9♣":
                    playerCalc.Add(9);
                    break;
                case "10♥":
                case "10♦":
                case "10♠":
                case "10♣":
                    playerCalc.Add(10);
                    break;
                case "J♥":
                case "J♦":
                case "J♠":
                case "J♣":
                    playerCalc.Add(10);
                    break;
                case "Q♥":
                case "Q♦":
                case "Q♠":
                case "Q♣":
                    playerCalc.Add(10);
                    break;
                case "K♥":
                case "K♦":
                case "K♠":
                case "K♣":
                    playerCalc.Add(10);
                    break;
                case "A♥":
                case "A♦":
                case "A♠":
                case "A♣":
                    Console.Write("\n\nWould you like your Ace to count as a 1 or 11?\nResponse: ");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        playerCalc.Add(1);
                        break;
                    }
                    else if (input == "11")
                    {
                        playerCalc.Add(11);
                        break;
                    }
                    else
                    {
                        Game.Dialog("\nThat is not a valid response and it will default to a value of 1.", "red");
                        playerCalc.Add(1);
                        break;
                    }
                default:
                    break;
            }
        }

        var playerTotal = 0;
        foreach (var calccard in playerCalc)
        {
            playerTotal += calccard;

        }
        return playerTotal;

    }


    public static int CardTotalDealer(List<string> Dcards, Player player)
    {
        int x = 0;
        List<int> dealerCalc = new List<int>();
        foreach (var dcard in Dcards)
        {
            switch (dcard)
            {

                case "2♥":
                case "2♦":
                case "2♠":
                case "2♣":
                    dealerCalc.Add(2);
                    break;
                case "3♥":
                case "3♦":
                case "3♠":
                case "3♣":
                    dealerCalc.Add(3);
                    break;
                case "4♥":
                case "4♦":
                case "4♠":
                case "4♣":
                    dealerCalc.Add(4);
                    break;
                case "5♥":
                case "5♦":
                case "5♠":
                case "5♣":
                    dealerCalc.Add(5);
                    break;
                case "6♥":
                case "6♦":
                case "6♠":
                case "6♣":
                    dealerCalc.Add(6);
                    break;
                case "7♥":
                case "7♦":
                case "7♠":
                case "7♣":
                    dealerCalc.Add(7);
                    break;
                case "8♥":
                case "8♦":
                case "8♠":
                case "8♣":
                    dealerCalc.Add(8);
                    break;
                case "9♥":
                case "9♦":
                case "9♠":
                case "9♣":
                    dealerCalc.Add(9);
                    break;
                case "10♥":
                case "10♦":
                case "10♠":
                case "10♣":
                    dealerCalc.Add(10);
                    break;
                case "J♥":
                case "J♦":
                case "J♠":
                case "J♣":
                    dealerCalc.Add(10);
                    break;
                case "Q♥":
                case "Q♦":
                case "Q♠":
                case "Q♣":
                    dealerCalc.Add(10);
                    break;
                case "K♥":
                case "K♦":
                case "K♠":
                case "K♣":
                    dealerCalc.Add(10);
                    break;
                case "A♥":
                case "A♦":
                case "A♠":
                case "A♣":
                    x = 11;
                    dealerCalc.Add(x);
                    break;

                default:
                    break;
            }
        }

        var dealerTotal = 0;
        foreach (var dcalccard in dealerCalc)
        {
            dealerTotal += dcalccard;

            if (dealerTotal > 21 && dealerCalc.Contains(11))
            {
                dealerCalc.Remove(11);
                dealerCalc.Add(1);
                dealerTotal = 0;
                foreach (var dcalcard in dealerCalc)
                {
                    dealerTotal += dcalcard;
                    DealerHitHold(Dcards, player);
                    return dealerTotal;
                }
            }

        }
        return dealerTotal;


    }


    public static string PazaakDealCards()
    {
        //pazaak had 4 sets of cards from 1 to 10.
        string[] cards = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
         "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",  "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
        Random rand = new Random();
        Thread.Sleep(500);
        var xcard = rand.Next(0, 40);
        var card = cards[xcard];

        return card;
    }


    public static int PazTotal(Player player, List<string> Dealt)
    {

        List<int> calc = new List<int>();

        foreach (var card in Dealt)
        {
            switch (card)
            {
                case "1":
                    calc.Add(1);
                    break;
                case "2":
                    calc.Add(2);
                    break;
                case "3":
                    calc.Add(3);
                    break;
                case "4":
                    calc.Add(4);
                    break;
                case "5":
                    calc.Add(5);
                    break;
                case "6":
                    calc.Add(6);
                    break;
                case "7":
                    calc.Add(7);
                    break;
                case "8":
                    calc.Add(8);
                    break;
                case "9":
                    calc.Add(9);
                    break;
                case "10":
                    calc.Add(10);
                    break;

                case "+1":
                    calc.Add(1);
                    break;
                case "+2":
                    calc.Add(2);
                    break;
                case "+3":
                    calc.Add(3);
                    break;
                case "+4":
                    calc.Add(4);
                    break;
                case "+5":
                    calc.Add(5);
                    break;

                case "-1":
                    calc.Add(-1);
                    break;
                case "-2":
                    calc.Add(-2);
                    break;
                case "-3":
                    calc.Add(-3);
                    break;
                case "-4":
                    calc.Add(-4);
                    break;
                case "-5":
                    calc.Add(-5);
                    break;

                default:
                    break;
            }
        }

        var dealtTotal = 0;
        foreach (var c in calc)
        {
            dealtTotal += c;
        }
        return dealtTotal;

    }


    public static int GetPazSDIndex(string psd)
    {
        //need to limit the side deck size to 20.
        switch (psd)
        {
            case "1":
                return 1 - 1;
            case "2":
                return 2 - 1;
            case "3":
                return 3 - 1;
            case "4":
                return 4 - 1;
            case "5":
                return 5 - 1;
            case "6":
                return 6 - 1;
            case "7":
                return 7 - 1;
            case "8":
                return 8 - 1;
            case "9":
                return 9 - 1;
            case "10":
                return 10 - 1;
            case "11":
                return 11 - 1;
            case "12":
                return 12 - 1;
            case "13":
                return 13 - 1;
            case "14":
                return 14 - 1;
            case "15":
                return 15 - 1;
            case "16":
                return 16 - 1;
            case "17":
                return 17 - 1;
            case "18":
                return 18 - 1;
            case "19":
                return 19 - 1;
            case "20":
                return 20 - 1;

            default: return -1;

        }



    }

    public static List<int> PazConvInt(Player player, List<string> SideDeck)
    {
        List<int> sdInt = new List<int>();
        foreach (var c in SideDeck)
        {

            switch (c)
            {

                case "+1":
                    sdInt.Add(1);
                    break;
                case "+2":
                    sdInt.Add(2);
                    break;
                case "+3":
                    sdInt.Add(3);
                    break;
                case "+4":
                    sdInt.Add(4);
                    break;
                case "+5":
                    sdInt.Add(5);
                    break;

                case "-1":
                    sdInt.Add(-1);
                    break;
                case "-2":
                    sdInt.Add(-2);
                    break;
                case "-3":
                    sdInt.Add(-3);
                    break;
                case "-4":
                    sdInt.Add(-4);
                    break;
                case "-5":
                    sdInt.Add(-5);
                    break;

                default:
                    break;
            }

        }

        return sdInt;
    }




    //Previously tried solutions, I like the current one the best.

    /* Didnt work, tried array in an array, or jaggedarray. But I should be able to do it with just 
         * two different arrays, one for suit one for cards and put them together in the return.
         * But then I cant really remove a number from the list.
         * But I could check for duplicates and have it re-random a new card.
         * 
        string[] Diamonds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Hearts = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Spades = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Clubs = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[][] cards = new string[][]
        { Diamonds, Hearts, Spades, Clubs};
        */


    //unicode hex is Heart = 2665, Diamond = 2666, Spade = 2660, Club = 2663, must use '\uXXXX' to print char to console.
    //didnt work, could not return char.  copy & paste the symbol as a string instead.
    //separating the suit and card number since the calculation was not reading correctly.
    /*
    public static string BlackJackDeck()
    {
        string[] cards = new string[] { "\U0001F0A1", "\U0001F0A2", "\U0001F0A3", "\U0001F0A4", "\U0001F0A5", "\U0001F0A6",
        "\U0001F0A7", "\U0001F0A8", "\U0001F0A9", "\U0001F0AA", "\U0001F0AB", "\U0001F0AC", "\U0001F0AD", "\U0001F0AE" };
        Random random = new Random();
        Thread.Sleep(500);
        var xxr = random.Next(0, 13);
        var card = cards[xxr];
        return card;
    }
    */

    //the odds of randomly selecting the same number from the same array is slim, but possible.
    //need to think of a way to prevent this?


    /* Experimented with using a stack, but it was waaaaayyyyy too slooowwww..
     * since it had to re-random whenever a duplicate was found and as got to 40 out of 52 possible results, thats extremely likely
     * 
    public static Stack<string> DeckShuffle()
    {
        Stack<string> deck = new Stack<string>(52);
        while(deck.Count < 52)
        {

        string[] bjcards = new [] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        Random rand = new Random();
        Thread.Sleep(500);
        var bjrando = rand.Next(0, 13);
        var bjcard = bjcards[bjrando];
        
        string[] cardsuit = new string[] { "♥", "♦", "♠", "♣" };
        Random rands = new Random();
        Thread.Sleep(500);
        var suitrand = rands.Next(0, 4);
        var suit = cardsuit[suitrand];

        var newbjcard = bjcard+suit;
        if(!deck.Contains(newbjcard))
            {
                deck.Push(newbjcard);
            }


        }
        return deck;
    }
    */


}
