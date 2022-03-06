using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables.
            string name;
            double total, price;

            //Greetings.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello, and welcome to Crazy Jay's Fireworks Shop!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThis program will help you determine how much \nyou will owe at the end of your purchases.");
            Console.Write("\nWhat is your name? ");
            Console.ForegroundColor = ConsoleColor.White;
            name = Console.ReadLine();

            //Begin the iteration.
            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nPlease enter the cost of the firework, or input -1 to quit: ");
            priceTag:
                Console.ForegroundColor = ConsoleColor.White;
                price = Convert.ToDouble(Console.ReadLine());
                if (price < -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\nInvalid entry! Please enter another price, or input -1 to quit: ");
                    goto priceTag;
                }
                if (price != -1)
                {
                    if (price >= 50)
                    {
                        total = price * 0.90;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t~DISCOUNT!~");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Original Price: " + price.ToString("C"));
                        Console.WriteLine("Discount Price: " + total.ToString("C"));
                    }
                    else
                    {
                        total = price;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t-SOLD-");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Orginal Price: " + total.ToString("C"));
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThank you for your patronage, " + name + "!");
                    Console.WriteLine("\nWould you like to purchase another firework? If so-");
                }
            } while (price != -1);

            //Goodbye.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nThank you for using Crazy Jay's Fireworks Shop.");
            Console.WriteLine("\nYou have a great day, " + name + "!");

            //Keep window open.
            Console.ReadLine();
        }
    }
}
