using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {

        static void Main(string[] args)
        {
            //declare variables
            double num1 = 0, num2 = 0, result = 0;
            string menuOption;


            //main program
            Console.WriteLine("Calculator Program");
            Console.WriteLine("==================");
            Console.Write("Enter 1st number: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter 2nd number: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            //Prompt for and get menu selection
            Console.Write("\nDo you want to (A)dd, (S)ubtract, (M)ultiply, (D)ivide, or (E)xit? ");
            menuOption = Console.ReadLine().ToUpper();
            while (menuOption != "E")
            {
                switch (menuOption)
                {
                    case "A":
                        result = AddNumbers(num1, num2);
                        Console.WriteLine($"\nSum of {num1} and {num2}: " + result);
                        break;
                    case "S":
                        Console.WriteLine($"\nThe difference of of {num1} and {num2}: " + SubtractNumbers(num1, num2));
                        break;
                    case "M":
                        result = MultiplyNumbers(num1, num2);
                        Console.WriteLine($"\nThe product of of {num1} and {num2}: " + result);
                        break;
                    case "D":
                        result = DivideNumbers(num1, num2);
                        Console.WriteLine($"\nThe quotient of of {num1} and {num2}: " + result);
                        break;
                    default:
                        Console.WriteLine("\n\n**Invalid Menu Option. Please Try Again");
                        break;
                }
                Console.Write("\nDo you want to (A)dd, (S)ubtrack, (M)ultiply, (D)ivide, or (E)xit? ");
                menuOption = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("\n\nThank you for using this program. Goodbye.");
            Console.ReadLine();

        }

        //declare function AddNumbers
        //take the two numbers provided and add them, returning the result.
        public static double AddNumbers(double a, double b)
        {
            double answer;
            answer = a + b;
            return answer;
        }

        //declare function SubtractNumbers
        //return the difference of the two numbers.
        public static double SubtractNumbers(double a, double b)
        {
            return a - b;
        }

        //declare function MultiplyNumbers
        //return the product of the two numbers.
        public static double MultiplyNumbers(double m1, double m2)
        {
            return m1 * m2;
        }

        //declare function DivideNumbers
        //take the two numbers provided and divide them, then return the result.
        public static double DivideNumbers(double dividend, double divisor)
        {
            double quotient;
            quotient = dividend / divisor;
            return quotient;
        }

    }
}
