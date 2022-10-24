


using SpaceAdventure;
using System.ComponentModel;

Game.StartGame();
Game.Starting();
Player player = new Player("Bob", 100);
Game.NamePlayer(player);

Game.MainArea(player);

Game.CasinoOptions(player);



Console.ReadKey(); //stays at the bottom to keep the window open for now until a key is pressed.



