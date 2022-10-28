using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class Player
    {
        public string Name { get; set; }
        public static decimal PlayerCredits { get; set; }

        
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
            if (amount <= PlayerCredits)
            {
                PlayerCredits -= amount;
                return true;
            }
            else { 
                Console.WriteLine("It seems you do not have enough credits to cover that amount.");
                Game.CasinoOptions(player);
            }

            return false;

        }


    }
}
