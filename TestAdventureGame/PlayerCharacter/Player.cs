using SpaceAdventure.CasinoMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.PlayerCharacter
{
    public class Player
    {
        public string Name { get; set; }
        public decimal PlayerCredits { get; set; }
        public string? PlayerShip { get; set; }
        public string? ShipStats { get; set; }
        public bool visitShipBazaar { get; set; } = false;
        public bool visitPazaak { get; set; } = false;
        public List<string> PazSideDeck { get; set; }
        public bool? PazT1Card { get; set; }
        public bool? PazStand { get; set; }
        public bool? PazCompStand { get; set; }

        public Player(string Name)
        {
            this.Name = Name;
        }

        public bool AddCredits(decimal amount, Player player)
        {
            player.PlayerCredits += amount;
            return true;
        }



        public bool RemoveCredits(decimal amount, Player player)
        {
            if (amount == 0 || amount < 0)
            {
                RemoveCreditsZero(player);
            }
            else if (amount <= player.PlayerCredits)
            {
                player.PlayerCredits -= amount;
                return true;
            }
            else
            {
                RemoveCreditsInsuff(player);
            }

            return false;

        }

        public void PlayerBalance(Player player)
        {
            Console.Write($"\nYour current balance is: ");
            Game.Dialog($"{player.PlayerCredits} credits.", "blue");
        }



        public void RemoveCreditsZero(Player player)
        {
            Console.Clear();
            Game.Dialog("\nThe bouncers are called over to remove you.", "darkred");
            Game.Dialog("\nBouncer: \"You must wager a valid amount of credits at our tables, no freeloaders allowed!\"", "darkred");
            Game.PressContinue();
            Casino casino = new Casino(player);
            casino.CasinoOptions(player);
        }

        public void RemoveCreditsInsuff(Player player)
        {
            Console.Clear();
            Console.WriteLine("\"It seems you do not have enough credits to cover that amount.\"");
            Console.Write($"\n\"Please use an amount that is equal to or less than your current balance.\"\n\"Or try your luck at one of our games to earn more credits.\"");
            PlayerBalance(player);
            Console.WriteLine("\nYou are removed back to entrance");
            Game.PressContinue();
            Game.MainArea(player);
        }


        public void AddShip(string ship, string shipstats, Player player)
        {
            if (player.PlayerShip != null)
            {
                Console.Clear();
                Console.WriteLine($"You already have a space ship in the hangar, you will have to go sell your current ship before purchasing a new one.");
                Console.WriteLine("Please come back when you have an empty hangar.");
                SellShip(player);
            }
            player.PlayerShip += ship;
            player.ShipStats += shipstats;
            Console.Clear();
            Game.Dialog($"\nYou have a new space ship!\n", "green");
            Game.Dialog($"{player.PlayerShip}", "darkmagenta");
            Game.PressContinue();
        }

        public void SellShip(Player player)
        {
            Game.Dialog($"\nWould you like to sell your current ship?", "blue");
            Console.Write("\n1) Yes\n2) No\nResponse: ");
            var input = Console.ReadLine();
            input = Convert.ToString(input);
            if (input == "1")
            {
                if (player.PlayerShip == null)
                {
                    Console.WriteLine("You have no current ship.");
                    Game.ShipBazaar(player);
                }
                else if (player.PlayerShip.Contains("V-wing"))
                {
                    AddCredits(500, player);
                    Console.WriteLine("You sold your ship and received 500 credits.");
                    PlayerBalance(player);
                    player.PlayerShip = null;
                    player.ShipStats = null;
                }
                else if (player.PlayerShip.Contains("Falcon"))
                {
                    AddCredits(250, player);
                    Console.WriteLine("You sold your ship and received 250 credits.");
                    PlayerBalance(player);
                    player.PlayerShip = null;
                    player.ShipStats = null;
                }
                else if (player.PlayerShip.Contains("Leviathan"))
                {
                    AddCredits(1150, player);
                    Console.WriteLine("You sold your ship and received 1150 credits.");
                    PlayerBalance(player);
                    player.PlayerShip = null;
                    player.ShipStats = null;
                }
                Game.PressContinue();
                Game.ShipBazaar(player);
            }
            else
            {
                Console.WriteLine("\nNo problem, thanks for coming!");
                Game.PressContinue();
                Game.ShipBazaar(player);
            }
        }

        public void CheckShip(Player player)
        {
            if (player.PlayerShip == null)
            {
                Console.WriteLine("\nYou currently do not have a ship. Please visit the Ship Bazaar to view the current options.");
            }
            else
            {
                Game.Dialog("\nHere is a live feed to the hangar showing your current ship.", "green");
                Game.Dialog($"\n{player.PlayerShip}", "darkmagenta");
                Game.Dialog($"\n{player.ShipStats}");
            }

        }
    }
}
