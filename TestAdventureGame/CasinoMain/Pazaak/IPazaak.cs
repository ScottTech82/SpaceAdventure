using SpaceAdventure.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.CasinoMain.Pazaak
{
    public interface IPazaak
    {
        void PlayingPazaak(Player player);

        void PazGamePlay(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk);

        void PazPlayerTurn(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk);

        void PazCompTurn(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk);


        List<string> PazPlayerCard(Player player, List<string> PlayerDealt, List<string> CompDealt);

        List<string> PazCompCard(Player player, List<string> PlayerDealt, List<string> CompDealt);

        void PazStand(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk);

        void PazRound(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk);

        void PazEndGame(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk);

        void PazEndMatch(Player player, List<string> PlayerDealt, List<string> CompDealt, decimal betx, int pWins, int cWins);

        void PazTotalTitle(Player player, List<string> PlayerDealt, List<string> CompDealt, int pWins, int cWins);

        void PazTableDisplay(Player player, List<string> PlayerDealt, List<string> CompDealt, List<string> pSideDeck, List<string> cSideDeck);

        List<string> PazSideDeck(Player player);

        List<string> PazCompEasySD();

        int UsePazSD(Player player, List<string> pSideDeck);

        string PazTitleWins(int xWins);

        void PazCpuStandCheck(Player player, List<string> PlayerDealt, List<string> CompDealt, List<string> pSideDeck, List<string> cSideDeck, decimal betx,
            int pWins, int cWins, int cpuSideChk);

        void PazCpuSideCheck(Player player, List<string> PlayerDealt, List<string> CompDealt, List<string> pSideDeck, List<string> cSideDeck,
            decimal betx, int pWins, int cWins, int cpuSideChk);

        void RefreshDisplay(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, int pWins, int cWins);

        //void PazCpuSideDeckPlayerStand(Player player, List<string> PlayerDealt, List<string> CompDealt,
        //List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk);

        //void PazCpuSideDeckNoStand(Player player, List<string> PlayerDealt, List<string> CompDealt,
        //    List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk);

        //    List<string> PazCompSDTest(Player player, List<string> CompDealt, List<int> cSdInt, int pTotal, int cTotal, int c);
    }
}
