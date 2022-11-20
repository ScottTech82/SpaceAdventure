using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Cards
{

    public string Card { get; set; } 
    public string Suit { get; set; }

    public override string ToString()
    {
        return Card + Suit;
    }
    //the odds of randomly selecting the same number from the same array is slim, but possible.
    //need to think of a way to prevent this? Use random to pull from List or Dictionary using remove and then push into stack


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

    /*
    public static string BlackJackCards()
    {
        /* Didnt work, tried array in an array, or jaggedarray. But I should be able to do it with just 
         * two different arrays, one for suit one for cards and put them together in the return.
         *
        string[] Diamonds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Hearts = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Spades = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Clubs = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        string[][] cards = new string[][]
        { Diamonds, Hearts, Spades, Clubs};
        */ /*
        string[] cards = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        Random rand = new Random();
        Thread.Sleep(500);
        var xxr = rand.Next(0, 13);
        var card = cards[xxr];
        return card;

        
    }
    public static string BlackJackSuit()
    {
        //unicode hex is Heart = 2665, Diamond = 2666, Spade = 2660, Club = 2663, must use '\uXXXX' to print char to console.
        //didnt work, could not return char.  Trying copy & paste the symbol as a string now.
        //separating the suit and card number since the calculation was not reading correctly.
        string[] cardsuit = new string[] { "♥", "♦", "♠", "♣" };
        Random rand = new Random();
        Thread.Sleep(500);
        var xr = rand.Next(0, 4);
        var suit = cardsuit[xr];
        return suit;
    }
    */

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
                foreach(var dcalcard in dealerCalc)
                    {
                        dealerTotal += dcalcard;
                    }
                }
            
        }
        return dealerTotal;


    }

    public static List<string> DealerHitHold(List<string> Dcards, Stack<string> deck, Player player)
    {
        var x = CardTotalDealer(Dcards, player);

        if(x >= 16)
        {
            return Dcards;
        }

        else
        {
            var newDcard = deck.Pop(); //BlackJackCards();
            Dcards.Add(newDcard);
            DealerHitHold(Dcards, deck, player);
        }
        return Dcards;

    }

 

}
