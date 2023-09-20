using SpaceAdventure.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.CasinoMain.BlackJack
{
    public interface IBlackJack
    {
        void PlayingBlackJack(Player player);
        void BlackJackTurn(decimal betx, List<string> Pcards, List<string> Dcards, Player player);
        string BlackJackNewCard();
        void BlackJackPlayAgain(Player player);
        void BlackJackWinLose(decimal betx, int playerTotal, int dealerTotal, Player player);
    }
}
