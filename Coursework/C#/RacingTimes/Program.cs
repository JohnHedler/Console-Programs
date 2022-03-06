using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare constant
            const int TIMES = 3;

            //Declare arrays
            double[] chuckler = new double[TIMES];
            double[] waddles = new double[TIMES];

            //Declare variables
            int index = 0;
            int chucklerCount = 0;
            int waddlesCount = 0;
            double seconds = 0;
            string time = "0.0";

            //Welcome
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nHello, and welcome to the 10th annual Fatman and Bobbin Race!");
            Console.WriteLine("Today, we are going to see who will win with the best time- overall!");
            Console.WriteLine("And our challengers are The Chuckler and Mr. Waddles.");

            //Input times for The Chuckler
            for (index = 0; index < TIMES; index++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nPlease enter time " + (index + 1) + " for The Chuckler: ");
                Console.ForegroundColor = ConsoleColor.White;
                chuckler[index] = Convert.ToDouble(Console.ReadLine());
            }

            //Input times for Mr. Waddles
            for (index = 0; index < TIMES; index++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nPlease enter time " + (index + 1) + " for Mr. Waddles: ");
                Console.ForegroundColor = ConsoleColor.White;
                waddles[index] = Convert.ToDouble(Console.ReadLine());
            }

            //Check to see who wins each race
            for (index = 0; index < TIMES; index++)
            {
                if (chuckler[index] < waddles[index])
                {
                    chucklerCount++;
                    seconds = waddles[index] - chuckler[index];
                    time = seconds.ToString("0.0");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nThe Chuckler wins by " + time + " seconds.");
                }
                else if (waddles[index] < chuckler[index])
                {
                    waddlesCount++;
                    seconds = chuckler[index] - waddles[index];
                    time = seconds.ToString("0.0");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nMr. Waddles wins by " + time + " seconds.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThe match is a tie!");
                }
            }

            //Check to see who wins the race tournament
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\nAnd the winner is... ");
            System.Threading.Thread.Sleep(3000);

            if (chucklerCount > waddlesCount)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("The Chuckler!");
            }
            else if (waddlesCount > chucklerCount)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Mr. Waddles!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("NEITHER! IT'S A TIE!");
            }

            //Keep window open
            Console.ReadLine();
        }
    }
}
