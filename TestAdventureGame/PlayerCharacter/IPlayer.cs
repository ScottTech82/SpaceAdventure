using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.PlayerCharacter
{
    public interface IPlayer
    {
        bool AddCredits(decimal amount, Player player);
        bool RemoveCredits(decimal amount, Player player);
        void PlayerBalance(Player player);
        void RemoveCreditsZero(Player player);
        void RemoveCreditsInsuff(Player player);
        void AddShip(string ship, string shipstats, Player player);
        void SellShip(Player player);
        void CheckShip(Player player);

    }
}
