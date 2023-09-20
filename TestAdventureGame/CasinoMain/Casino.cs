using SpaceAdventure.CasinoMain.SlotMachines;
using SpaceAdventure.ConsoleGfx;
using SpaceAdventure.PlayerCharacter;

namespace SpaceAdventure.CasinoMain;

public class Casino : ICasino
{

    private Player player;


    public Casino(Player player)
    {
        this.player = player;

    }




    public decimal Bet(Player player)
    {
        Console.Write($"\nHow much are you willing to wager?");
        player.PlayerBalance(player);
        Console.Write("\nPlease enter an amount to bet.\nResponse: ");
        var x = Console.ReadLine();
        decimal intx = Convert.ToDecimal(x);

        player.RemoveCredits(intx, player);
        return intx;
    }

    public void CasinoOptions(Player player)
    {
        Console.Clear();
        Title.CasinoTitle();
        Console.WriteLine("\nWelcome to the Casino!");
        Console.WriteLine("\nCurrently our poker tables are closed for an upcoming tournament.");
        Console.WriteLine("You could test your luck at the slot machines or the blackjack table.");
        Game.Dialog("\nWhich would you like to try?", "blue");
        Console.Write("\n1) Slot Machines\n2) BlackJack\n3) *New* Pazaak\n4) Exit\n\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1")
        {
            Console.Clear();
            CasinoSlots(player);
        }
        else if (input == "2")
        {
            Console.Clear();
            PlayBlackJack(player);
        }
        else if (input == "3")
        {
            Console.Clear();
            PlayPazaak(player);
        }
        else if (input == "4")
        {
            Console.WriteLine("Ok, please come by later to test your luck. Have a great day!");
            Game.MainArea(player);
        }
        else
        {
            Console.WriteLine($"Please press either 1, 2, or 3. {CasinoOptions}");
        }

    }

    public void CasinoSlots(Player player)
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
            CasinoOptions(player);
        }
        else
        {
            Console.WriteLine("Please enter either 1 or 2");
            CasinoSlots(player);
        }
    }



    public void PlayBlackJack(Player player)
    {
        try
        {
            BlackJack.BlackJack blackJack = new(player);
            blackJack.PlayingBlackJack(player);
        }
        catch (Exception ex)
        {
            throw;
        }
    }



    public void PlayPazaak(Player player)
    {
        try
        {
            Pazaak.Pazaak pazaak = new(player);
            pazaak.PlayingPazaak(player);
        }
        catch (Exception ex)
        {
            Game.Dialog($"Error in Pazaak. {ex.Message}", "red");
            throw;
        }
    }



}


