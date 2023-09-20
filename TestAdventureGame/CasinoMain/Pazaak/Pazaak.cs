using SpaceAdventure.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.CasinoMain.Pazaak
{
    public class Pazaak : IPazaak
    {

        private Player player;

        //cpuSideCheck needs to be a property and not passed in to methods.
        //same with pWins and cWins
        //should be able to make a pazbet property to set according to betx variable.

        //Check on PazCpuSideCheck method the else if statement, add to it.  Should skip if cTotal < pTotal?

        public Pazaak(Player player)
        {
            this.player = player;
        }



        public void PlayingPazaak(Player player)
        {
            List<string> PlayerDealt = new List<string>();
            List<string> CompDealt = new List<string>();
            Game.Dialog("Welcome to the secret underground game of Pazaak!", "green");
            Game.Dialog("\nThis game was brought here by a vistor, from what they described as a galaxy, far, far away...");
            if (player.visitPazaak == false)
            {
                Game.Dialog("\n\nAnyway, the rules are simple. Get 20 points without going over.  " +
                    "\nThe dealer deals a new card to you each turn unless you stand.  Your opponent can continue to draw until they stand." +
                    "\nThe person with the highest total without going over wins the round. Win 3 rounds and you win the match.");
                Game.Dialog("\nThere is a side deck of 4 cards that you can use to raise or lower your total.");
                player.visitPazaak = true;
                
                if (player.PazSideDeck is null || player.PazSideDeck.Count == 0)
                {
                    player.PazSideDeck = new List<string>();
                    Game.Dialog("\nYou get a basic side deck for free. You can add to it with better cards as you find them.");
                    player.PazSideDeck.Add("+1");
                    player.PazSideDeck.Add("+2");
                    player.PazSideDeck.Add("+3");
                    player.PazSideDeck.Add("+4");
                    Console.WriteLine("\n***You received the +1, +2, +3, +4 cards in your side deck.***");
                }
            }
            else
            {
                Game.Dialog($"\n\nHi {player.Name}, Do you want to hear the rules again?", "darkcyan");
                Console.Write("\n1) Yes\n2) No\nResponse: ");
                var input = Console.ReadLine();
                input = Convert.ToString(input);
                if (input == "1")
                {
                    Game.Dialog("\n\nBasically get 20 points without going over." +
                        "\nThe dealer deals a new card to you each turn unless you stand.  Your opponent can continue to draw until they stand." +
                        "\nThe person with the highest total without going over wins the round. Win 3 rounds and you win the match.", "darkcyan");
                    Game.Dialog("\n\nThere is also a side deck of 4 cards randomly drawn that you can use to raise or lower your total " +
                        "depending on what cards you have.", "darkcyan");
                }
            }
            player.PazStand = false;
            player.PazCompStand = false;
            player.PazT1Card = false;
            var pWins = 0;
            var cWins = 0;
            var cpuSideChk = 0;
            var pSideDeck = PazSideDeck(player);
            var cSideDeck = PazCompEasySD();
            ICasino casino = new Casino(player);
            var betx = casino.Bet(player);
            Game.PressContinue();
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
        }

        public void PazGamePlay(Player player, List<string> PlayerDealt, List<string> CompDealt,
        List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);

            var pTotal = Cards.PazTotal(player, PlayerDealt);
            var cTotal = Cards.PazTotal(player, CompDealt);

            if (pTotal > 20 || cTotal > 20)
            {
                PazEndGame(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (player.PazStand == true && player.PazCompStand == false)
            {
                PazCompTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (player.PazStand == true && player.PazCompStand == true)
            {
                PazEndGame(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (player.PazStand == false)
            {
                PazPlayerTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else
            {
                PazEndGame(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
        }

        public void PazPlayerTurn(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            if (PlayerDealt.Count == 0 && CompDealt.Count == 0)
            {
                PazPlayerCard(player, PlayerDealt, CompDealt);
                PazCompCard(player, PlayerDealt, CompDealt);
                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }

            Game.Dialog("\n\n\nWould you like to Continue drawing cards, Stand at this amount, or use your side deck?", "blue");
            Console.Write("\n1) Draw a Card\n2) Stand\n3) Side Deck\n\nResponse: ");

            var input = Console.ReadLine();
            input = Convert.ToString(input);
            if (input == "1" && player.PazCompStand == false)
            {
                PazPlayerCard(player, PlayerDealt, CompDealt);
                RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                PazCompTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (input == "1" && player.PazCompStand == true)
            {
                PazPlayerCard(player, PlayerDealt, CompDealt);
                RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (input == "2" && player.PazCompStand == false)
            {
                Console.WriteLine("\nYou stand with your current total, your opponents turn will continue until they stand.");
                player.PazStand = true;
                Game.PressContinue();
                PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (input == "2" && player.PazCompStand == true)
            {
                Console.WriteLine("\nYou stand with your current total and your opponent has already decided to stand with their total");
                player.PazStand = true;
                Game.PressContinue();
                PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (input == "3")
            {
                if (pSideDeck.Count == 0)
                {
                    Console.WriteLine("You have no cards in your side deck.");
                    PazPlayerTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                //getting the player chosen index for the side deck.
                var sdIndex = UsePazSD(player, pSideDeck);

                //I now have the chosen side deck card in a string format.
                var sdCard = pSideDeck.ElementAt(sdIndex);
                pSideDeck.RemoveAt(sdIndex);

                //add to the player dealt list and calc it later or add that to the total?
                PlayerDealt.Add(sdCard);
                var xTotal = Cards.PazTotal(player, PlayerDealt);
                if (xTotal == 20)
                {
                    player.PazStand = true;
                    Console.WriteLine("\nYour total equals 20 and you stand automatically");
                    Game.PressContinue();
                    PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (player.PazCompStand == false)
                {
                    PazCompTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else
                {
                    PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid response");
                PazPlayerTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
        }

        public void PazCompTurn(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            var cTotal = Cards.PazTotal(player, CompDealt);
            var pTotal = Cards.PazTotal(player, PlayerDealt);

            if(cTotal > 20 || pTotal > 20)
            {
                PazEndGame(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            //set this up to review the main player total and use the side deck to try and get as close to 20 as possible.
            if (player.PazCompStand == false)
            {

                //cpu always hit if less than 12 and player has not stood
                if (cTotal <= 12 && player.PazStand == false)
                {
                    PazCompCard(player, PlayerDealt, CompDealt);
                    RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                    PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                //if player stands cpu decides to take another card or stand based on the total
                //**might need to incorporate the side deck here as well if the cpu can exceed pTotal by using one.**
                else if (cTotal <= 12 && player.PazStand == true)
                {
                    if (cTotal < pTotal)
                    {
                        PazCompCard(player, PlayerDealt, CompDealt);
                        RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                        PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                        PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    }
                    else
                    {
                        PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                                //shouldnt hit this next line, but leaving just in case.
                        PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    }
                }
                //Player stands and cpu now determines if it can beat the player total
                else if (cTotal > 12 && player.PazStand == true && player.PazCompStand == false)
                {
                    if (cTotal <= pTotal)
                    {
                        //PazCpuSideDeckPlayerStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                        PazCpuSideCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                        PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                        PazCompCard(player, PlayerDealt, CompDealt);
                        RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                        PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    }
                    else
                    {
                        PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                        PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    }
                }
                else if (cTotal > 12 && player.PazStand == false && player.PazCompStand == false)
                {
                    //PazCpuSideDeckNoStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    PazCpuSideCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    PazCompCard(player, PlayerDealt, CompDealt);
                    RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else
                {
                    PazEndGame(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
            }
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
        }

        public void PazCpuStandCheck(Player player, List<string> PlayerDealt, List<string> CompDealt, List<string> pSideDeck, List<string> cSideDeck, decimal betx,
            int pWins, int cWins, int cpuSideChk)
        {
            var pTotal = Cards.PazTotal(player, PlayerDealt);
            var cTotal = Cards.PazTotal(player, CompDealt);

            if (player.PazCompStand != true)
            {
                if (cTotal > 20)
                {
                    PazEndGame(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cTotal == 20)
                {
                    player.PazCompStand = true;
                    RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {cTotal}");
                    Game.PressContinue();
                    PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (player.PazStand == true && cTotal > pTotal)
                {
                    player.PazCompStand = true;
                    RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {cTotal}");
                    Game.PressContinue();
                    PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (player.PazStand == false && pSideDeck.Count == 0 && cTotal > pTotal)
                {
                    player.PazCompStand = true;
                    RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {cTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cpuSideChk >= 5)
                {
                    player.PazCompStand = true;
                    RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {cTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                //if no option to win, do not stand instead keep drawing cards or check side deck.
                else
                {
                    return;
                }
            }
            return;
        }

        //This method is going to check if the cpu total can be increased to 20, 19 or 18 without using tons of if else statements.
        public void PazCpuSideCheck(Player player, List<string> PlayerDealt, List<string> CompDealt, List<string> pSideDeck, List<string> cSideDeck,
            decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            var cTotal = Cards.PazTotal(player, CompDealt);
            var pTotal = Cards.PazTotal(player, PlayerDealt);
            var cSdInt = Cards.PazConvInt(player, cSideDeck);
            //DO I even need this?  Seems like I can remove it and remove all cpuSideChk, it shouldnt really slow it down.
            if (cpuSideChk <= 6)
            {
                cpuSideChk += 1;
                int x = 20;
                while (x > 16)
                {
                    //foreach doesnt work here as I have a string list converted to int list, need to reference the same location in both lists
                    //to calc integers and add/remove from string list.
                    for (int i = 0; i < cSideDeck.Count; i++)
                    {
                        if (cTotal + cSdInt[i] == x)
                        {
                            string c = cSideDeck[i];
                            CompDealt.Add(cSideDeck[i]);
                            cSideDeck.RemoveAt(i);
                            RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                            Console.WriteLine($"\n\n\nThe opponent is using their side deck card of {c}");
                            Game.PressContinue();
                            PazCpuStandCheck(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                            continue;

                        }
                    }
                    //if cpu cannot make x pts with side deck and player has x points, break out of loop. Draw a card.
                    //Dont waste a side deck card to have a smaller total than player.
                    if(pTotal == x)
                    {
                        return;
                    }
                    //attempting to add a little randomization to whether the CPU uses a side deck card or not
                    //And prevent it from using too many side deck cards to total 20 in 1 turn.
                    else if (cpuSideChk > 2 && cTotal > pTotal)
                    {
                        int[] selection = new int[] { 1, 2, 3, 4, 5 };
                        Random random = new Random();
                        int rnd = random.Next(0, 5);
                        var result = selection[rnd];
                        if (result == 2 || result == 4)
                        {
                            return;
                        }
                    }
                    x--;
                }
                //going to return back without using the side deck.
                return;
            }
            return;
        }


        public List<string> PazPlayerCard(Player player, List<string> PlayerDealt, List<string> CompDealt)
        {
            var p = Cards.PazaakDealCards();
            PlayerDealt.Add(p);
            return PlayerDealt;
        }


        public List<string> PazCompCard(Player player, List<string> PlayerDealt, List<string> CompDealt)
        {
            var c = Cards.PazaakDealCards();
            CompDealt.Add(c);
            return CompDealt;
        }


        public void PazStand(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            Console.Clear();
            PazTotalTitle(player, PlayerDealt, CompDealt, pWins, cWins);
            PazTableDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);

            if (player.PazCompStand == false)
            {
                PazCompTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (player.PazCompStand == true && player.PazStand == false)
            {
                PazPlayerTurn(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else
            {
                PazEndGame(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
        }

        public void PazRound(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            Console.Clear();
            PazTotalTitle(player, PlayerDealt, CompDealt, pWins, cWins);

            Console.WriteLine("\n\nThe next round will begin shortly, first to win 3 rounds wins the match.");

            player.PazStand = false;
            player.PazCompStand = false;
            player.PazT1Card = false;

            PlayerDealt.Clear();
            CompDealt.Clear();

            Game.PressContinue();
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
        }

        public void PazEndGame(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            Console.Clear();
            PazTotalTitle(player, PlayerDealt, CompDealt, pWins, cWins);
            var pTotal = Cards.PazTotal(player, PlayerDealt);
            var cTotal = Cards.PazTotal(player, CompDealt);
            if (pTotal > 20)
            {
                cWins += 1;
                RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                Console.WriteLine("\n\nYou bust by going over 20 total points!");
                Game.PressContinue();
                if (cWins == 3)
                {
                    PazEndMatch(player, PlayerDealt, CompDealt, betx, pWins, cWins);
                }
                else
                {
                    PazRound(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
            }
            else if (cTotal > 20)
            {
                pWins += 1;
                RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                Console.WriteLine("\n\nYour opponent has busted by going over 20 total points. You Win!!");
                Game.PressContinue();
                if (pWins == 3)
                {
                    PazEndMatch(player, PlayerDealt, CompDealt, betx, pWins, cWins);
                }
                else
                {
                    PazRound(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
            }
            else if (pTotal > cTotal)
            {
                pWins += 1;
                RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                Console.WriteLine("\n\nYour total is higher than your opponents without busting. You WIN!!");
                Game.PressContinue();
                if (pWins == 3)
                {
                    PazEndMatch(player, PlayerDealt, CompDealt, betx, pWins, cWins);
                }
                else
                {
                    PazRound(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk); //should make different method for new round starts.
                }
            }
            else if (pTotal < cTotal)
            {
                cWins += 1;
                RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                Console.WriteLine("\n\nYour Opponent's total is higher than yours. Please try again.");
                Game.PressContinue();
                if (cWins == 3)
                {
                    PazEndMatch(player, PlayerDealt, CompDealt, betx, pWins, cWins);
                }
                else
                {
                    PazRound(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk); //should make different method for new round starts.
                }
            }
            else
            {
                RefreshDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, pWins, cWins);
                Console.WriteLine("\n\nYou Tied, no wins are awarded.");
                Game.PressContinue();
                if(cWins == 3 || pWins == 3)
                {
                    PazEndMatch(player, PlayerDealt, CompDealt, betx, pWins, cWins);
                }
                else
                {
                    PazRound(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
            }
        }

        public void PazEndMatch(Player player, List<string> PlayerDealt, List<string> CompDealt, decimal betx, int pWins, int cWins)
        {
            Console.Clear();
            PazTotalTitle(player, PlayerDealt, CompDealt, pWins, cWins);
            if (pWins >= 3)
            {
                Console.WriteLine("\n\n\nYou won the match by winning 3 games");
                decimal multiplier = 7M;
                decimal x = betx * multiplier;
                player.AddCredits(x, player);
                Game.Dialog($"\nYour bet of {betx} x {multiplier} = {x} credits", "blue");
                player.PlayerBalance(player);
                Game.PressContinue();
                ICasino casino = new Casino(player);
                casino.CasinoOptions(player);
            }
            else
            {
                Console.WriteLine("\n\n\nYour opponent won the match by winning 3 games, better luck next time!");
                player.PlayerBalance(player);
                Game.PressContinue();
                ICasino casino = new Casino(player);
                casino.CasinoOptions(player);
            }
        }

        public void PazTotalTitle(Player player, List<string> PlayerDealt, List<string> CompDealt, int pWins, int cWins)
        {
            var pTotal = Cards.PazTotal(player, PlayerDealt);
            var cTotal = Cards.PazTotal(player, CompDealt);

            var pWin = PazTitleWins(pWins);
            var cWin = PazTitleWins(cWins);
            string title = "                                     ****  Pazaak Card Game  ****";

            Game.Dialog(title, "gray");
            Game.Dialog($"             ||   {player.Name}'s Total = {pTotal}   || {pWin} <- Wins -> {cWin} ||   Opponent's Total = {cTotal}   ||\n");
        }

        public void PazTableDisplay(Player player, List<string> PlayerDealt, List<string> CompDealt, List<string> pSideDeck, List<string> cSideDeck)
        {
            Game.Dialog($"\n\n{player.Name}'s Cards: ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var p in PlayerDealt)
            {
                Console.Write($"| {p} ");
            }
            Console.Write($"|");
            Game.Dialog($"\n\n  -Side Deck-", "gray");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var c in pSideDeck)
            {
                Console.Write($"| {c} ");
            }
            Console.Write("|");
            Game.Dialog("\n\n ---  ---  ---  ", "gray");
            Game.Dialog($"\nOpponent's Cards: ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var c in CompDealt)
            {
                Console.Write($"| {c} ");
            }
            Console.Write($"|");
            Game.Dialog($"\n\n  -Opp. Side Deck-", "gray");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var c in cSideDeck)
            {
                Console.Write($"| {c} ");
            }
            Console.Write("|");
            Console.ResetColor();
        }


        public List<string> PazSideDeck(Player player)
        {
            List<string> NewSideDeck = new List<string>();
            var count = player.PazSideDeck.Count();
            if (count == 4)
            {
                foreach (var c in player.PazSideDeck)
                {
                    NewSideDeck.Add(c);
                }
            }
            else
            {
                while (NewSideDeck.Count < 4)
                {
                    Random random = new Random();
                    var r = random.Next(0, count);
                    var sidecard = player.PazSideDeck[r];
                    if (NewSideDeck.Contains(sidecard))
                    {
                        PazSideDeck(player);
                    }
                    NewSideDeck.Add(sidecard);
                    Thread.Sleep(500);
                }
            }
            return NewSideDeck;
        }

        //create multiple comp side decks scaled for difficulty
        public List<string> PazCompEasySD()
        {
            List<string> CompSideDeck = new List<string> { "+1", "+2", "+3", "+5" };
            return CompSideDeck;
        }


        public int UsePazSD(Player player, List<string> pSideDeck)
        {
            Console.WriteLine("\nWhich card would you like to use?", "blue");
            foreach (var c in pSideDeck)
            {
                int idx = pSideDeck.IndexOf(c) + 1;
                Console.Write($"\n{idx}) | {c} |");
            }
            Console.Write("\nResponse: ");
            var psd = Console.ReadLine();
            psd = Convert.ToString(psd);
            if (psd != null)
            {
                var inputIdx = Cards.GetPazSDIndex(psd);
                if (inputIdx == -1)
                {
                    Console.WriteLine("Please enter a valid response");
                    UsePazSD(player, pSideDeck);
                }
                return inputIdx;
            }
            else
            {
                Console.WriteLine("Please enter a valid response");
                UsePazSD(player, pSideDeck);
            }
            return 0;
        }

        public string PazTitleWins(int xWins)
        {
            var xWin = "";
            switch (xWins)
            {
                case 0:
                    return xWin = "";
                case 1:
                    return xWin = "♦";
                case 2:
                    return xWin = "♦♦";
                case 3:
                    return xWin = "♦♦♦";
                default:
                    break;
            }
            return xWin;
        }


        public void RefreshDisplay(Player player, List<string> PlayerDealt, List<string> CompDealt, 
            List<string> pSideDeck, List<string> cSideDeck, int pWins, int cWins)
        {
            Console.Clear();
            PazTotalTitle(player, PlayerDealt, CompDealt, pWins, cWins);
            PazTableDisplay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck);
        }




        //PREVIOUSLY WORKING SIDE DECK CODE.  Wanted to simplify it and future proof in case the size of the side deck is increased.
        /*
        public void PazCpuSideDeckPlayerStand(Player player, List<string> PlayerDealt, List<string> CompDealt,
         List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            var cTotal = Cards.PazTotal(player, CompDealt);
            var pTotal = Cards.PazTotal(player, PlayerDealt);
            var cSdInt = Cards.PazConvInt(player, cSideDeck);

            if (cSideDeck.Count > 0)
            {
                if (cTotal + cSdInt[0] > pTotal && cTotal + cSdInt[0] <= 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[0]}");
                    CompDealt.Add(cSideDeck[0]);
                    cSideDeck.RemoveAt(0);
                    player.PazCompStand = true;
                    var newTotal = cTotal + cSdInt[0];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 1 && cTotal + cSdInt[1] > pTotal && cTotal + cSdInt[1] <= 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[1]}");
                    CompDealt.Add(cSideDeck[1]);
                    cSideDeck.RemoveAt(1);
                    player.PazCompStand = true;
                    var newTotal = cTotal + cSdInt[1];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 2 && cTotal + cSdInt[2] > pTotal && cTotal + cSdInt[2] <= 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[2]}");
                    CompDealt.Add(cSideDeck[2]);
                    cSideDeck.RemoveAt(2);
                    player.PazCompStand = true;
                    var newTotal = cTotal + cSdInt[2];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 3 && cTotal + cSdInt[3] > pTotal && cTotal + cSdInt[3] <= 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[3]}");
                    CompDealt.Add(cSideDeck[3]);
                    cSideDeck.RemoveAt(3);
                    player.PazCompStand = true;
                    var newTotal = cTotal + cSdInt[3];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cTotal + cSdInt[0] == pTotal && cTotal + cSdInt[0] <= 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[0]}");
                    CompDealt.Add(cSideDeck[0]);
                    cSideDeck.RemoveAt(0);
                    player.PazCompStand = true;
                    var newTotal = cTotal + cSdInt[0];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 1 && cTotal + cSdInt[1] == pTotal && cTotal + cSdInt[1] <= 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[1]}");
                    CompDealt.Add(cSideDeck[1]);
                    cSideDeck.RemoveAt(1);
                    player.PazCompStand = true;
                    var newTotal = cTotal + cSdInt[1];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 2 && cTotal + cSdInt[2] == pTotal && cTotal + cSdInt[2] <= 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[2]}");
                    CompDealt.Add(cSideDeck[2]);
                    cSideDeck.RemoveAt(2);
                    player.PazCompStand = true;
                    var newTotal = cTotal + cSdInt[2];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 3 && cTotal + cSdInt[3] == pTotal && cTotal + cSdInt[3] <= 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[3]}");
                    CompDealt.Add(cSideDeck[3]);
                    cSideDeck.RemoveAt(3);
                    player.PazCompStand = true;
                    var newTotal = cTotal + cSdInt[3];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else
                {
                    if (cTotal > 20)
                    {
                        PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    }
                    Console.WriteLine($"\n\nWith no side deck option to win, your opponent has decided to draw another card.");
                    PazCompCard(player, PlayerDealt, CompDealt);
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
            }

            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
        }

        public void PazCpuSideDeckNoStand(Player player, List<string> PlayerDealt, List<string> CompDealt,
            List<string> pSideDeck, List<string> cSideDeck, decimal betx, int pWins, int cWins, int cpuSideChk)
        {
            var cTotal = Cards.PazTotal(player, CompDealt);
            var cSdInt = Cards.PazConvInt(player, cSideDeck);

            //Checking if side cards exist then comparing cpu total to player total and 
            //adding side deck card as long as its under 20.
            if (cpuSideChk == 5)
            {
                player.PazCompStand = true;
                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
            }
            else if (cSideDeck.Count > 0)
            {
                //check if adding in a side deck card will equate to 20.
                if (cTotal + cSdInt[0] == 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[0]}");
                    CompDealt.Add(cSideDeck[0]);
                    cSideDeck.RemoveAt(0);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[0];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 1 && cTotal + cSdInt[1] == 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[1]}");
                    CompDealt.Add(cSideDeck[1]);
                    cSideDeck.RemoveAt(1);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[1];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 2 && cTotal + cSdInt[2] == 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[2]}");
                    CompDealt.Add(cSideDeck[2]);
                    cSideDeck.RemoveAt(2);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[2];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 3 && cTotal + cSdInt[3] == 20)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[3]}");
                    CompDealt.Add(cSideDeck[3]);
                    cSideDeck.RemoveAt(3);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[3];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                //check if adding a side deck card will equate to 19
                else if (cTotal + cSdInt[0] == 19)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[0]}");
                    CompDealt.Add(cSideDeck[0]);
                    cSideDeck.RemoveAt(0);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[0];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 1 && cTotal + cSdInt[1] == 19)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[1]}");
                    CompDealt.Add(cSideDeck[1]);
                    cSideDeck.RemoveAt(1);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[1];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 2 && cTotal + cSdInt[2] == 19)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[2]}");
                    CompDealt.Add(cSideDeck[2]);
                    cSideDeck.RemoveAt(2);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[2];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 3 && cTotal + cSdInt[3] == 19)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[3]}");
                    CompDealt.Add(cSideDeck[3]);
                    cSideDeck.RemoveAt(3);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[3];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                //check to see if it will equate to 18
                else if (cTotal + cSdInt[0] == 18)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[0]}");
                    CompDealt.Add(cSideDeck[0]);
                    cSideDeck.RemoveAt(0);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[0];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 1 && cTotal + cSdInt[1] == 18)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[1]}");
                    CompDealt.Add(cSideDeck[1]);
                    cSideDeck.RemoveAt(1);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[1];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 2 && cTotal + cSdInt[2] == 18)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[2]}");
                    CompDealt.Add(cSideDeck[2]);
                    cSideDeck.RemoveAt(2);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[2];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else if (cSideDeck.Count > 3 && cTotal + cSdInt[3] == 18)
                {
                    Console.WriteLine($"\nThe opponent is using their side deck card of {cSideDeck[3]}");
                    CompDealt.Add(cSideDeck[3]);
                    cSideDeck.RemoveAt(3);
                    player.PazCompStand = true;
                    cpuSideChk += 1;
                    var newTotal = cTotal + cSdInt[3];
                    Console.WriteLine($"\n\nYour opponent has decided to stand at {newTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
                else
                {
                    if (cTotal >= 12 && cTotal <= 17)
                    {
                        PazCompCard(player, PlayerDealt, CompDealt);
                        Console.WriteLine("Your opponent has decided to draw a card");
                        Game.PressContinue();
                        PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                    }
                    player.PazCompStand = true;
                    Console.WriteLine($"\nYour opponent has decided to stand at {cTotal}");
                    Game.PressContinue();
                    PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
                }
            }
            cpuSideChk += 1;
            PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins, cpuSideChk);
        }

        */




        //NO LONGER USING

        //public List<string> PazCompSDTest(Player player, List<string> CompDealt,
        //    List<int> cSdInt, int pTotal, int cTotal, int c)
        //{

        //    //Did not use the pTotal or cTotal yet.  Might need later.

        //    foreach (var x in cSdInt)
        //    {
        //        switch (x)
        //        {
        //            case 1:
        //                if (cTotal + 1 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("+1");
        //                    return CompDealt;
        //                }
        //                break;
        //            case 2:
        //                if (cTotal + 2 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("+2");
        //                    return CompDealt;
        //                }
        //                break;
        //            case 3:
        //                if (cTotal + 3 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("+3");
        //                    return CompDealt;
        //                }
        //                break;
        //            case 4:
        //                if (cTotal + 4 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("+4");
        //                    return CompDealt;
        //                }
        //                break;
        //            case 5:
        //                if (cTotal + 5 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("+5");
        //                    return CompDealt;

        //                }
        //                break;

        //            case -1:
        //                if (cTotal - 1 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("-1");
        //                    return CompDealt;
        //                }
        //                break;
        //            case -2:
        //                if (cTotal - 2 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("-2");
        //                    return CompDealt;
        //                }
        //                break;
        //            case -3:
        //                if (cTotal - 3 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("-3");
        //                    return CompDealt;
        //                }
        //                break;
        //            case -4:
        //                if (cTotal - 4 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("-4");
        //                    return CompDealt;
        //                }
        //                break;
        //            case -5:
        //                if (cTotal - 5 == c)
        //                {
        //                    player.PazCompStand = true;
        //                    CompDealt.Add("-5");
        //                    return CompDealt;
        //                }
        //                break;

        //            default:
        //                break;
        //        }
        //    }
        //    return CompDealt;
        //}

        /* --older idea on comp player paz decisions.
        foreach(var x in cSdInt)
                {
                    switch(x)
                    {
                        case 1:
                            if(cTotal + 1 == 20 && player.PazStand == false)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+1");
                                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);
                            }
                            else if (cTotal + 1 == 20 && player.PazStand == true)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+1");
                                PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);
                            }
                            break;                
                        case 2:
                            if (cTotal + 2 == 20 && player.PazStand == false)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+2");
                                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);
                            }
                            else if (cTotal + 2 == 20 && player.PazStand == true)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+2");
                                PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);
                            }
                            break;                
                         case 3:
                            if (cTotal + 3 == 20 && player.PazStand == false)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+3");
                                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);
                            }
                            else if (cTotal + 3 == 20 && player.PazStand == true)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+3");
                                PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);
                            }
                            break;                
                        case 4:
                            if (cTotal + 4 == 20 && player.PazStand == false)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+4");
                                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);

                            }
                            else if (cTotal + 4 == 20 && player.PazStand == true)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+4");
                                PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);
                            }
                            break;                
                        case 5:
                            if (cTotal + 5 == 20 && player.PazStand == false)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+5");
                                PazGamePlay(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);

                            }
                            else if (cTotal + 5 == 20 && player.PazStand == true)
                            {
                                player.PazCompStand = true;
                                CompDealt.Add("+5");
                                PazStand(player, PlayerDealt, CompDealt, pSideDeck, cSideDeck, betx, pWins, cWins);
                            }
                            break;

                        default:
                            break;
                    }
                }
        */


    }
}
