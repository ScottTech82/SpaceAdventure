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
 * 1. Bug list for the aces. Need to move them outside of the switch statement.
 * 2. Overriding the ToString method to return the card number & card suite in all other methods.
 * 3. Could just list all cards options with suit in switch case, return them back together again.
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
 * When the dealer gets 2 Aces it fires the CW twice and then if they draw a card and now have > 2 cards
 * it will fire the other CW's twice for each Ace.  This needs to take place outside of the value assigning.
 * 
 * 
 * 
 * 
 */

