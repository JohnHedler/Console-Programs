using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            string state, name;
            int quantity = 0, selection;
            double price = 0, sale = 0, tax = 0;

            //Greetings
            Console.WriteLine("\nHello, and welcome to the Quick-E Mart.");
            Console.Write("What is your name? ");
            name = Console.ReadLine();
            Console.WriteLine("\nI have not seen you around here before. Where do you come from?");
            Console.WriteLine("1. Florida");
            Console.WriteLine("2. New Jersey");
            Console.WriteLine("3. New York");
            Console.Write("#: ");
        state:
            selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                state = "Florida";
            }
            else if (selection == 2)
            {
                state = "New Jersey";
            }
            else if (selection == 3)
            {
                state = "New York";
            }
            else
            {
                Console.WriteLine("\nI am sorry, but where are you from again?");
                goto state;
            }
            Console.WriteLine("\nThank you, " + name + ", from " + state + ", what can I do for you today?");
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Sell");
            Console.WriteLine("3. Exit");
        option:
            Console.Write("#: ");
            selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 2)
            {
                Console.WriteLine("\nWhat? You want to sell me something?");
                Console.WriteLine("This is not a pawn shop. Now, are you going to buy something or not?");
                goto option;
            }
            else if (selection == 3)
            {
                goto leave;
            }
            else
            {
                Console.WriteLine("\nOkay, I see you want this, but how much does it cost?");
                Console.Write("$");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nGreat, and how many do you want?");
                Console.Write("?: ");
                quantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nWonderful. Just let me do some math, real quick");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".\n\n");
            }
            //Calculate total price and tax
            sale = computeTotal(quantity, price);
            tax = computeTax(sale, state);

            //Display the end of sale
            Console.WriteLine("\t===============");
            Console.WriteLine("\t====RECEIPT====");
            Console.WriteLine("\t===============");
            Console.WriteLine("\n" + name);
            Console.WriteLine(state);
            Console.WriteLine("Unit price of item: " + price.ToString("C"));
            Console.WriteLine("Quantity requested: " + quantity);
            Console.WriteLine("The total of your purchase is " + sale.ToString("C"));
            Console.WriteLine("Tax for your purchase is " + tax.ToString("C"));
            Console.WriteLine("The total, with tax, is " + (sale + tax).ToString("C"));

        //Goodbye
        leave:
            Console.WriteLine("\n\nThank you. Have a great day!");
            Console.ReadLine();
        }

        public static double computeTotal(int quantity, double price)
        {
            return (quantity * price);
        }
        public static double computeTax(double sales, string state)
        {
            double tax = 0;
            if (state == "Florida")
            {
                tax = (sales * 6 / 100);
            }
            else if (state == "New Jersey")
            {
                tax = (sales * 7 / 100);
            }
            else if (state == "New York")
            {
                tax = (sales * 4 / 100);
            }
            return tax;
        }
    }
}
