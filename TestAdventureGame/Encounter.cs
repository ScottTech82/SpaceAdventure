using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure;

public class Encounter
{


    public static void Encounter1VWingOptions(Player player, int x)
    {

        if (x == 1)
        {
            string encounterStart = @"
        .   .  .       .     .   .     .   .  .   .    .   .  .     .
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
        .   .     .           .       .        .  .  .    .
        .               .           .                   .               
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
        .    .       . .    .   .   .  .   .       .        .
          .     .       .       .     .     .   .       .           .

";
            Console.WriteLine(encounterStart);
        }


        else if (x == 2)
        {
            string encounterPShoot = @"
        .   .  .       .     .   .     .   .  .   .    .   .  .     .
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
        .   .     .           .       .        .  .  .    .
        .               .           .                   .               
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
        .    .       . .    .   .   .  .   .       .        .
          .     .       .       .     .     .   .       .           .

";
            Console.WriteLine(encounterPShoot);
        }

        else if (x == 3)
        {
            string encounterPHit = @"
        .   .  .       .     .   .     .   .  .   .    .   .  .     .
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
        .   .     .           .       .        .  .  .    .
        .               .           .                   .               
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
        .    .       . .    .   .   .  .   .       .        .
          .     .       .       .     .     .   .       .           .

";
            Console.WriteLine(encounterPHit);
        }
        else if (x == 4)
        {
            string encounterPMiss = @"
        .   .  .       .     .   .     .   .  .   .    .   .  .     .
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
        .   .     .           .       .        .  .  .    .
        .               .           .                   .               
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
        .    .       . .    .   .   .  .   .       .        .
          .     .       .       .     .     .   .       .           .

";
            Console.WriteLine(encounterPMiss);
        }
        else if (x == 5)
        {
            string encounterCShoot = @"
        .   .  .       .     .   .     .   .  .   .    .   .  .     .
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
        .   .     .           .       .        .  .  .    .
        .               .           .                   .               
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
        .    .       . .    .   .   .  .   .       .        .
          .     .       .       .     .     .   .       .           .

";
            Console.WriteLine(encounterCShoot);
        }
        else if (x == 6)
        {
            string encounterCHit = @"
        .   .  .       .     .   .     .   .  .   .    .   .  .     .
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
        .   .     .           .       .        .  .  .    .
        .               .           .                   .               
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
        .    .       . .    .   .   .  .   .       .        .
          .     .       .       .     .     .   .       .           .

";
            Console.WriteLine(encounterCHit);
        }
        else if (x == 7)
        {
            string encounterCMiss = @"
        .   .  .       .     .   .     .   .  .   .    .   .  .     .
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
        .   .     .           .       .        .  .  .    .
        .               .           .                   .               
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
        .    .       . .    .   .   .  .   .       .        .
          .     .       .       .     .     .   .       .           .

";
            Console.WriteLine(encounterCMiss);
        }









    }


    public static void EncounterFirst(Player player)
    {
        //this will call the options depending on what is selected in the encounter.
        //make a random to determine if it will be a hit or miss. Maybe something like random 0-8 13567hit 024 miss?
        //will need to determine how many hits destroys.. maybe make a static health amount but damage is another random number?
        // damange is from 3-5 maybe.


        //testing the look of it;
        Encounter1VWingOptions(player, 1);
        Thread.Sleep(500);
        Game.PressContinue();        
        Encounter1VWingOptions(player, 2);
        Thread.Sleep(500);
        Game.PressContinue();
        Encounter1VWingOptions(player, 3);
        Thread.Sleep(500);
        Game.PressContinue();
        Encounter1VWingOptions(player, 4);
        Thread.Sleep(500);
        Game.PressContinue();   
        Encounter1VWingOptions(player, 5);
        Thread.Sleep(500);
        Game.PressContinue();
        Encounter1VWingOptions(player, 6);
        Thread.Sleep(500);
        Game.PressContinue();
        Encounter1VWingOptions(player, 7);

        Game.MainArea(player);


    }


    /*
     * 
    string testsideways = @"
    ABCDEFGHIJKLMNOPQRSTUVWXYZ


          ==========
       ===VVVVVVVVVV        
       VVV          VVVV 
    3||                VVVV> 
   33||           <VVVV 
   33||         <D
   33||           <VVVV    
    3||               VVVV>
       VVV          VVVV
       ===VVVVVVVVVV
          ==========

";

    */

} 
