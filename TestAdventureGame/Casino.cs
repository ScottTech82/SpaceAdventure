using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SpaceAdventure
{
    public class Casino
    {


        //I need to call this method 3 times, one for each row.
        //that way the random should actually be randam all 3 times instead of all 3 at the same machine time.
        
        public static string SlotMachine()
        {

            string[] selection = new string[] {"Asteroid", "Planet", "Star", "Nebula", "Galaxy"};
            Random random = new Random();
            int rnd = random.Next(0, 5);

            var result = selection[rnd];
            return result;   


        }

        public static void CasinoSlotChoice1()
        {
            Game.Dialog("Would you like to try again?", "blue");
            Console.Write("1) Yes \n2) No thanks\nResponse: ");
            var input = Console.ReadLine();
            input = Convert.ToString(input);
            if (input == "1")
            {
                Console.Clear();
                CasinoSlots();
            }
            else if (input == "2")
            {
                Console.WriteLine("Thank you for playing, please come again.");
            }
            else { Console.WriteLine($"Please press either 1 or 2."); CasinoSlotChoice1(); }
        }


        public static void CasinoSlots()
        {
            //add in bet amounts and track in variables

            Console.WriteLine("You put the credits in and spin the machine. The first column begins to spin.");
            var result1 = Casino.SlotMachine();
            Console.WriteLine($"    and the first result is.... \n");
            Thread.Sleep(2000);
            Game.Dialog($"              | { result1} |    ?    |    ?    |", "green");
            Console.WriteLine("\n---Press Enter for the second result---\n");
            Console.ReadKey();

            Console.WriteLine("The second column begins to spin.");
            var result2 = Casino.SlotMachine();
            Console.WriteLine($"    and the second result is.... \n");
            Thread.Sleep(2000);
            Game.Dialog($"              | {result1} | {result2} |    ?    |", "green");
            Console.WriteLine("\n---Press enter for the third result---\n");
            Console.ReadKey();

            Console.WriteLine("The third and final column begins to spin rapidly.");
            var result3 = Casino.SlotMachine();
            Console.WriteLine($"    the third result is.... \n");
            Thread.Sleep(3000);
            Game.Dialog($"              | {result1} | {result2} | {result3} |", "green");
            Console.ReadKey();


            if (result1 != result2 && result1 != result3 && result2 != result3)
            {
                //bet deducted from the total.
                Console.WriteLine("\nAww, better luck next time!\n");
            }
            if (result1 == result2 || result1 == result3 || result2 == result3)
            {
                Console.WriteLine("\nYou matched two and won a prize!\n");
            }
            if (result1 == result2 && result1 == result3)
            {
                //add in winnings variable and multiply it, putting the result in. 
                //the winnings will need to be added to the players total money in items.cs.
                Console.WriteLine("\nYOU WON!! Congratulations, enjoy your winnings!\n");
            }
            Console.Write("---Press enter to continue---");
            Console.ReadKey();
            Console.Clear();
            Casino.CasinoSlotChoice1();
        }
    }
}
