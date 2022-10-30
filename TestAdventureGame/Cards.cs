using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Cards
{



    public static string BlackJackCards()
    {
        /* Didnt work, tried array in an array, or jaggedarray. But I should be able to do it with just 
         * two different arrays, one for suit one for cards and put them together in the return.
         * But then I cant really remove a number from the list.
        string[] Diamonds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Hearts = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Spades = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] Clubs = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        string[][] cards = new string[][]
        { Diamonds, Hearts, Spades, Clubs};
        */
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

    public static int CardTotalPlayer(List<string> Pcards, Player player)
    {

        List<int> playerCalc = new List<int>();

        foreach (var card in Pcards)
        {
            switch (card)
            {

                case "2":
                    playerCalc.Add(2);
                    break;
                case "3":
                    playerCalc.Add(3);
                    break;
                case "4":
                    playerCalc.Add(4);
                    break;
                case "5":
                    playerCalc.Add(5);
                    break;
                case "6":
                    playerCalc.Add(6);
                    break;
                case "7":
                    playerCalc.Add(7);
                    break;
                case "8":
                    playerCalc.Add(8);
                    break;
                case "9":
                    playerCalc.Add(9);
                    break;
                case "10":
                    playerCalc.Add(10);
                    break;
                case "J":
                    playerCalc.Add(10);
                    break;
                case "Q":
                    playerCalc.Add(10);
                    break;
                case "K":
                    playerCalc.Add(10);
                    break;
                case "A":
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
                        Game.Dialog("\nThat is not a valid response and it will default to a value of 1." +
                            "\nPlease try to be more respectful in the future and type only the requested responses.", "red");
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

        List<int> dealerCalc = new List<int>();
        foreach (var dcard in Dcards)
        {
            switch (dcard)
            {

                case "2":
                    dealerCalc.Add(2);
                    break;
                case "3":
                    dealerCalc.Add(3);
                    break;
                case "4":
                    dealerCalc.Add(4);
                    break;
                case "5":
                    dealerCalc.Add(5);
                    break;
                case "6":
                    dealerCalc.Add(6);
                    break;
                case "7":
                    dealerCalc.Add(7);
                    break;
                case "8":
                    dealerCalc.Add(8);
                    break;
                case "9":
                    dealerCalc.Add(9);
                    break;
                case "10":
                    dealerCalc.Add(10);
                    break;
                case "J":
                    dealerCalc.Add(10);
                    break;
                case "Q":
                    dealerCalc.Add(10);
                    break;
                case "K":
                    dealerCalc.Add(10);
                    break;
                case "A":
                    Random rand = new Random();
                    var x = rand.Next(1, 3);
                    
                    if (x == 1)
                    {
                        if(dealerCalc.Count > 2)
                        {
                            var a = 1;
                            Console.WriteLine($"\nAfter drawing a new card the dealer has randomly re-chosen the value of A to be {a}");
                            dealerCalc.Add(1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"\nIn order to provide the player an option to win and" +
                                $"\ngive the dealerbot more of a biological mistake factor, the dealerbot will randomly choose" +
                                $" if A is equal to 1 or 11.");
                            dealerCalc.Add(1);
                            break;
                        }
                    }
                    else if (x == 2)
                    {
                        if(dealerCalc.Count > 2)
                        {
                            var a = 11;
                            Console.WriteLine($"\nAfter drawing a new card the dealer has randomly re-chosen the value of A to be {a}");
                            dealerCalc.Add(11);
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"\n\nIn order to provide the player an additional option to win and" +
                                $"give the dealer \nmore of a mistake factor, the dealer will randomly choose" +
                                $" if A is equal to 1 or 11.");
                            Thread.Sleep(2000);
                            dealerCalc.Add(11);
                            break;
                        }
                    }
                    else
                    {
                        dealerCalc.Add(1);
                        break;
                    }
                default:
                    break;
            }
        }
    
        var dealerTotal = 0;
        foreach (var dcalccard in dealerCalc)
        {
            dealerTotal += dcalccard;
            
        }
        return dealerTotal;


    }

    public static List<string> DealerHitHold(List<string> Dcards, Player player)
    {
        var x = CardTotalDealer(Dcards, player);

        if(x >= 15)
        {
            return Dcards;
        }

        else
        {
            var newDcard = BlackJackCards();
            Dcards.Add(newDcard);
            DealerHitHold(Dcards, player);
        }
        return Dcards;

    }

 

}
