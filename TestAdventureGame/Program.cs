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
 * Finished Pazaak.. just need Comp Side Deck implemented and not standing at just 16, but checking player amount first.
 * 
 * 
 * 0. Decided Not to do -- Overriding the ToString method to return the card number & card suite in all other methods.
 * 0. Completed -- Could just list all cards options with suit in switch case, return them back together again.
 * 
 * 
 * Ideas
 * 
 * 1. *COMPLETE*  Move Title to its own class and have other Titles for Casino and Ship Bazaar.  
 * 2. Expand on the Ship Bazaar, where purchasing parts increases the base stats of the ship.
 * 3. Can I create a small mini shooting game with the ship? <--maybe a windows form app??
 * 4. Create a ship class with ship model, ship stats, ship title that can be expanded on later.
 *      a. Can also put Ship Cost as a property, that is checked when selling or purchasing. So I dont have to add them 
 *      to multiple different methods, like player.sellship checking if string contains.
 *      b. Ship Title should be separate from the string model, different color as well.
 *      
 * 5. Next would be leaving the hub and having the option to fly to the local solar system?
 *      a. Maybe get attacked along the way and have some options to fight off the pirates
 *      with getting some earnings and loot?  Could be just text based for now.
 *      b. Would have to randomize some of the encounter with misses, damage, etc.
 *      c. Create a repair section of the Ship Bazaar, which then I need to track ship damage (property of ship class)
 *      d. If you lose the battle, it basically starts the game over again where you are crashed on a planet and traders pick you up.
 *      It would have to wipe everything that currently happened.
 * 
 * 
 * BUG List
 * 
 * 
 * 
 * 
 * 
 */

