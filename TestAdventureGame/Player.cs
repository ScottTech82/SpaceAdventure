using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Player
{
    public string Name { get; set; }
    public static decimal PlayerCredits { get; set; }
    public string? PlayerShip { get; set; }

    
    public Player(string Name)
    {
        this.Name = Name;
       
    }
    


    public static bool AddCredits(decimal amount, Player player)
    {
        PlayerCredits += amount;
        return true;
    }



    public static bool RemoveCredits(decimal amount, Player player)
    {
        if(amount == 0 || amount < 0)
        {
            RemoveCreditsZero(player);
        }
        else if (amount <= PlayerCredits)
        {
            PlayerCredits -= amount;
            return true;
        }
        else { 
            RemoveCreditsInsuff(player);
        }

        return false;

    }

    public static void PlayerBalance(Player player)
    {
        Console.Write($"\nYour current balance is ");
        Game.Dialog($"{PlayerCredits} credits.", "blue");
    }



    public static void RemoveCreditsZero(Player player)
    {
        Console.Clear();
        Game.Dialog("\nThe bouncers are called over to remove you.", "darkred");
        Game.Dialog("\nBouncer: \"You must wager a valid amount of credits at our tables, no freeloaders allowed!\"", "darkred");
        Game.PressContinue();
        Game.CasinoOptions(player);
    }

    public static void RemoveCreditsInsuff(Player player)
    {
        Console.Clear();
        Console.WriteLine("Dealer: \"It seems you do not have enough credits to cover that amount.\"");
        Console.Write($"\n\"Please use an amount that is equal to or less than your current balance.\"\n\"Or try your luck at another one of our games.\"");
        PlayerBalance(player);
        Console.WriteLine("\nYou are removed back to the casino entrance");
        Game.PressContinue();
        Game.CasinoOptions(player);
    }





}
