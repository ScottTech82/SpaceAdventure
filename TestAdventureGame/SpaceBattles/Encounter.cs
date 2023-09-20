using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceAdventure.PlayerCharacter;

namespace SpaceAdventure.SpaceBattles;

public class Encounter
{

    private Player player;
    



    public static void EncounterFirst(Player player)
    {
        //this will call the options depending on what is selected in the encounter.
        //make a random to determine if it will be a hit or miss. Maybe something like random 0-8 13567hit 024 miss?
        //will need to determine how many hits destroys.. maybe make a static health amount but damage is another random number?
        // damange is from 3-5 maybe.

        Console.Clear();
        Console.WriteLine("You notice a ship, in local space, on the quantum radar moving towards you at a rapid pace.");
        Thread.Sleep(500);
        Console.WriteLine("This can only mean one thing..  pirates!!");
        Thread.Sleep(500);
        Console.WriteLine("\nThe pirate hails your comms");
        Game.Dialog("\n\"Your ship and credits are ours.  You will not make it out.. alive!\"", "darkyellow");
        Game.PressContinue();




        /*1 = Start
         *2 = Fire
         *3 = Hit
         *4 = Miss
         *5 = EnemyShoot
         *6 = EnemyHit
         *7 = EnemyMiss
         *
         */

        Encounter1VWingOptions(player, 1);
        Thread.Sleep(2000);
    }

    public static void EncounterChoice(Player player)
    {
        Game.Dialog("\nWhat would you like to do?", "blue");
        Console.Write("\n1) FIRE!\n2)Attempt a dodge maneuver\n3)Try to escape\nResponse: ");
        var input = Console.ReadLine();
        input = Convert.ToString(input);
        if (input == "1")
        {
            Encounter1VWingOptions(player, 2);
        }
        else if (input == "2")
        {
            Console.WriteLine("You perform a dodge maneuver..");
            var dodge = EncounterDodge();
            EncounterDodgeRead(dodge);
        }
        else if (input == "3")
        {

        }
        else
        {
            Console.WriteLine("Please enter a valid selection");
            Game.PressContinue();
            EncounterChoice(player);
        }


    }


    public static void EncounterDodgeRead(string x)
    {

    }



    //testing the look of it;
    /*
    Encounter1VWingOptions(player, 1);
    Thread.Sleep(500);
    Game.PressContinueEncounter();      
    Encounter1VWingOptions(player, 2);
    Thread.Sleep(500);
    Game.PressContinueEncounter();
    Encounter1VWingOptions(player, 3);
    Thread.Sleep(500);
    Game.PressContinueEncounter();
    Encounter1VWingOptions(player, 4);
    Thread.Sleep(500);
    Game.PressContinueEncounter();   
    Encounter1VWingOptions(player, 5);
    Thread.Sleep(500);
    Game.PressContinueEncounter();
    Encounter1VWingOptions(player, 6);
    Thread.Sleep(500);
    Game.PressContinueEncounter();
    Encounter1VWingOptions(player, 7);

    Game.MainArea(player);
    */



    public static void EcounterRandom()
    {
        Random random = new Random();
        var rand = random.Next(0, 8);


    }

    //could pass in Dodge Ability and change the chances from Hit to Dodge.
    //Different switch statements.
    public static string EncounterDodge()
    {
        Random random = new Random();
        var rand = random.Next(0, 5);

        switch (rand)
        {
            case 0:
                return "Dodge";
            case 1:
                return "Hit";
            case 2:
                return "Dodge";
            case 3:
                return "Hit";
            case 4:
                return "Dodge";
            case 5:
                return "Hit";
            default:
                break;
        }

        return "";
    }















    //Displayed Ship Encounters

    public static void Encounter1VWingOptions(Player player, int x)
    {
        Console.Clear();

        if (x == 1)
        {

            string encounterStart = @"
          .       .  .     .    M  . . M  .     .               ..
        .     .        .       /M\    /M\   .       .   .     .     .
          .  .       .        |   \__/   |.   .       .         .
        .               .   . |  |    |  |  . .  .        .   .   .
            .   .     .      .|  |    |  |.    .     .  .
        .   .    .   .    .    \   88   /.  .  .   .        .
                .   .       .   \/\88/\/ .      .       .       .   .
         .  .     .     .    .     \/ .   .  .      .      .
               .   .           .     .  .      .       .   .        .
        .   .           .   .       .       .       .          .
             .   .    .           . .      .  
        .           .           .               .       .           .           
                .     .   .       .    .     .      .       .   .  
          .  .        .     .     .      .     . .    .    .    .
           .    .   .           .       .   .       .        .      .
        ..   .    .     .    .     . .    .     .       .   .   .
            .   .       .        .          .   .       .   .   . 
        .         .   .     .      .    .   .     .   .   .   
                        .             .   .   .         .       .
            .       .     .  .     .   .   .     .   .      .
              .      .     .  . /\     ./\  .   .  .     .     .
          .       .     .      /88\ .  /88\  .          .   .       .
             .        .   .  .|    \/\/    |    .    .    .  
        .        .  .   .     |     \/     | .    .         .    .
              .   .    .   .   \ []    [] / .   .      .  .  
            .                   \[]====[]/.         .        .  . 
          .    .  .  .    .    ..  WWWW .    .  .       .
";
            Game.Dialog(encounterStart, "green");

        }

        else if (x == 2)
        {
            string encounterPShoot = @"
          .       .  .     .    M  . . M  .     .               ..
        .     .        .       /M\    /M\   .       .   .     .     .
          .  .       .        |   \__/   |.   .       .         .
        .               .   . |  |    |  |  . .  .        .   .   .
            .   .     .      .|  |    |  |.    .     .  .
        .   .    .   .    .    \   88   /.  .  .   .        .
                .   .       .   \/\88/\/ .      .       .       .   .
         .  .     .     .    .     \/ .   .  .      .      .
               .   .           .     .  .      .       .   .        .
        .   .           .   .       .       .       .          .
             .   .    .           . .      .  
        .           .           .0      0        .       .           .           
                .     .   .      0.    .0    .      .       .   .
          .  .        .     .     .      .     . .    .    .    .
           .    .   .           .       .   .       .        .      .
        ..   .    .     .    .     . .    .     .       .   .   .
            .   .       .        .          .   .       .   .   . 
        .         .   .     .    0 .    0   .     .   .   .   
                        .        0    . 0 .   .         .       .
            .       .     .  .     .   .   .     .   .      .
              .      .     .  . /\     ./\  .   .  .     .     .
          .       .     .      /88\ .  /88\  .          .   .       .
             .        .   .  .|    \/\/    |    .    .    .  
        .        .  .   .     |     \/     | .    .         .    .
              .   .    .   .   \ []    [] / .   .      .  .  
            .                   \[]====[]/.         .        .  . 
          .    .  .  .    .    ..  WWWW .    .  .       .
";
            Game.Dialog(encounterPShoot, "green");
        }

        else if (x == 3)
        {
            string encounterPHit = @"
          .       .  .     .    M  . . M  .     .               ..
        .     .        .       /M\    /M\   .       .   .     .     .
          .  .       .        |   \__/   |.   .       .         .
        .               .   . |  |    |  |  . .  .        .   .   .
            .   .     .      .|  |    |  |.    .     .  .
        .   .    .   .    .    \** 88   /.  .  .   .        .
                .   .       . ** /\88/\/ .      .       .       .   .
         .  .     .     .    .  ** \/ .   .  .      .      .
               .   .           .     .  .      .       .   .        .
        .   .           .   .       .       .       .          .
             .   .    .           . .      .  
        .           .           .0      0        .       .           .           
                .     .   .      0.    .0    .      .       .   .
          .  .        .     .     .      .     . .    .    .    .
           .    .   .           .       .   .       .        .      .
        ..   .    .     .    .     . .    .     .       .   .   .
            .   .       .        .          .   .       .   .   . 
        .         .   .     .      .        .     .   .   .   
                        .             .   .   .         .       .
            .       .     .  .     .   .   .     .   .      .
              .      .     .  . /\     ./\  .   .  .     .     .
          .       .     .      /88\ .  /88\  .          .   .       .
             .        .   .  .|    \/\/    |    .    .    .  
        .        .  .   .     |     \/     | .    .         .    .
              .   .    .   .   \ []    [] / .   .      .  .  
            .                   \[]====[]/.         .        .  . 
          .    .  .  .    .    ..  WWWW .    .  .       .
";
            Game.Dialog(encounterPHit, "green");
        }
        else if (x == 4)
        {
            string encounterPMiss = @"
          .       .  .     .    M  . . M  .     .               ..
        .     .        .       /M\    /M\   .       .   .     .     .
          .  .       .        |   \__/   |.   .       .         .
        .               .   . |  |    |  |  . .  .        .   .   .
            .   .     .      .|  |    |  |.    .     .  .
        .   .    .   .    .    \   88   /.  .  .   .        .
                .   .       .   \/\88/\/ .      .       .       .   .
         .  .     .     .    .     \/ .   .  .      .      .
               .   .           .     .  .      .       .   .        .
        .   .           .   .       .       .       .          .
             .   .    .           . .      .  
        .           .           .0      0        .       .           .           
                .     .   .      0.    .0    .      .       .   .
          .  .        .     .     .      .     . .    .    .    .
           .    .   .           .       .   .       .        .      .
        ..   .    .     .    .     . .    .     .       .   .   .
            .   .       .        .          .   .       .   .   . 
        .         .   .     .      .        .     .   .   .   
                        .             .   .   .         .       .
            .       .     .  .     .   .   .     .   .      .
              .      .     .  . /\     ./\  .   .  .     .     .
          .       .     .      /88\ .  /88\  .          .   .       .
             .        .   .  .|    \/\/    |    .    .    .  
        .        .  .   .     |     \/     | .    .         .    .
              .   .    .   .   \ []    [] / .   .      .  .  
            .                   \[]====[]/.         .        .  . 
          .    .  .  .    .    ..  WWWW .    .  .       .
";
            Game.Dialog(encounterPMiss, "green");
        }
        else if (x == 5)
        {
            string encounterCShoot = @"
          .       .  .     .    M  . . M  .     .               ..
        .     .        .       /M\    /M\   .       .   .     .     .
          .  .       .        |   \__/   |.   .       .         .
        .               .   . |  |    |  |  . .  .        .   .   .
            .   .     .      .|  |    |  |.    .     .  .
        .   .    .   .    .    \   88   /.  .  .   .        .
                .   .       .   \/\88/\/ .      .       .       .   .
         .  .     .     .    .     \/ .   .  .      .      .
               .   .           .||   .||.      .       .   .        .
        .   .           .   .       .       .       .          .
             .   .    .           . .      .  
        .           .           .               .       .           .           
                .     .   .       .    .     .      .       .   .
          .  .        .     .     .      .     . .    .    .    .
           .    .   .           .       .   .       .        .      .
        ..   .    .     .    .  || . .||  .     .       .   .   .
            .   .       .        .          .   .       .   .   . 
        .         .   .     .      .    .   .     .   .   .   
                        .             .   .   .         .       .
            .       .     .  .     .   .   .     .   .      .
              .      .     .  . /\     ./\  .   .  .     .     .
          .       .     .      /88\ .  /88\  .          .   .       .
             .        .   .  .|    \/\/    |    .    .    .  
        .        .  .   .     |     \/     | .    .         .    .
              .   .    .   .   \ []    [] / .   .      .  .  
            .                   \[]====[]/.         .        .  . 
          .    .  .  .    .    ..  WWWW .    .  .       .
";
            Game.Dialog(encounterCShoot, "green");
        }
        else if (x == 6)
        {
            string encounterCHit = @"
          .       .  .     .    M  . . M  .     .               ..
        .     .        .       /M\    /M\   .       .   .     .     .
          .  .       .        |   \__/   |.   .       .         .
        .               .   . |  |    |  |  . .  .        .   .   .
            .   .     .      .|  |    |  |.    .     .  .
        .   .    .   .    .    \   88   /.  .  .   .        .
                .   .       .   \/\88/\/ .      .       .       .   .
         .  .     .     .    .     \/ .   .  .      .      .
               .   .           .     .  .      .       .   .        .
        .   .           .   .       .       .       .          .
             .   .    .           . .      .  
        .           .           .               .       .           .           
                .     .   .       .    .     .      .       .   .
          .  .        .     .     .      .     . .    .    .    .
           .    .   .           .       .   .       .        .      .
        ..   .    .     .    .  || . .||  .     .       .   .   .
            .   .       .        .          .   .       .   .   . 
        .         .   .     .      .    .   .     .   .   .   
                        .             .   .   .         .       .
            .       .     .  .  ** .   .   .     .   .      .
              .      .     .  . /**    ./\  .   .  .     .     .
          .       .     .      /88\*.  /88\  .          .   .       .
             .        .   .  .|    \/\/    |    .    .    .  
        .        .  .   .     |     \/     | .    .         .    .
              .   .    .   .   \ []    [] / .   .      .  .  
            .                   \[]====[]/.         .        .  . 
          .    .  .  .    .    ..  WWWW .    .  .       .
";
            Game.Dialog(encounterCHit, "green");
        }
        else if (x == 7)
        {
            string encounterCMiss = @"
          .       .  .     .    M  . . M  .     .               ..
        .     .        .       /M\    /M\   .       .   .     .     .
          .  .       .        |   \__/   |.   .       .         .
        .               .   . |  |    |  |  . .  .        .   .   .
            .   .     .      .|  |    |  |.    .     .  .
        .   .    .   .    .    \   88   /.  .  .   .        .
                .   .       .   \/\88/\/ .      .       .       .   .
         .  .     .     .    .     \/ .   .  .      .      .
               .   .           .     .  .      .       .   .        .
        .   .           .   .       .       .       .          .
             .   .    .           . .      .  
        .           .           .               .       .           .           
                .     .   .       .    .     .      .       .   .
          .  .        .     .     .      .     . .    .    .    .
           .    .   .           .       .   .       .        .      .
        ..   .    .     .    .  || . .||  .     .       .   .   .
            .   .       .        .          .   .       .   .   . 
        .         .   .     .      .    .   .     .   .   .   
                        .             .   .   .         .       .
            .       .     .  .     .   .   .     .   .      .
              .      .     .  . /\     ./\  .   .  .     .     .
          .       .     .      /88\ .  /88\  .          .   .       .
             .        .   .  .|    \/\/    |    .    .    .  
        .        .  .   .     |     \/     | .    .         .    .
              .   .    .   .   \ []    [] / .   .      .  .  
            .                   \[]====[]/.         .        .  . 
          .    .  .  .    .    ..  WWWW .    .  .       .
";
            Game.Dialog(encounterCMiss, "green");
        }









    }

}
