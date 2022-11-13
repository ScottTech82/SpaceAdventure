using SpaceAdventure;
using System.ComponentModel;

Title.GameTitle();
Game.Starting();
Player player = new Player("Bob");
Game.NamePlayer(player);
Game.MainArea(player);




Console.ReadKey(); //stays at the bottom to keep the window open for now until a key is pressed.

/* Comments, Ideas, and Bug List.
 * 
 * Working On
 * 
 * 1. Overriding the ToString method to return the card number & card suite in all other methods.
 * 2. Could just list all cards options with suit in switch case, return them back together again.
 * 
 * 
 * Ideas
 * 
 * 1. Move Title to its own class and have other Titles for Casino and Ship Bazaar.  <--- in progress.
 * 2. Can I create a small mini shooting game with the ship? <--maybe a windows form app??
 * 
 * 
 * BUG List
 * 
 * 
 * 
 * 
 * 
 */

