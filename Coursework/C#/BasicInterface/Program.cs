/**************************************************
 * Basic User Interface Program
 * =============================
 * The program takes user input of name, age and
 * gas mileage to output it back to the user. This
 * program is just a simple way to show that you
 * can include multiple classes to utilize a way
 * of encapsulation/modularization.
 * 
 *************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables.
            string input;
            string name;
            int age;
            double galMileage;
            bool isValid = false;

            //Display welcoming messages to user.
            AppProcesses.DisplayAppInfo();
            AppProcesses.DisplayDiv("Start Program");

            //Display 'get name' message and receive input from user.
            AppProcesses.DisplayDiv("Get Name");
            name = InputProcesses.GetInput("Your Name");
            Console.WriteLine("Your name is: " + name);

            //Display 'get age' message and receive input from user.
            AppProcesses.DisplayDiv("Get Age");
            do
            {
                input = InputProcesses.GetInput("Your Age");
                isValid = Int32.TryParse(input, out age);
                if (!isValid || age <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe number entered is invalid. Please try again...\n");
                    isValid = false;
                }
            } while (!isValid);
            Console.WriteLine("Your age is: " + age + " year(s) old.");

            //Display 'get mileage' message and receive input from user.
            AppProcesses.DisplayDiv("Get Mileage");
            do
            {
                input = InputProcesses.GetInput("Gas Mileage");
                isValid = double.TryParse(input, out galMileage);
                if (!isValid || galMileage < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe number entered is invalid. Please try again...\n");
                    isValid = false;
                }
            } while (!isValid);
            Console.WriteLine("Your car's miles-per-gallon (MPG) is: " + galMileage.ToString("N2"));

            AppProcesses.DisplayDiv("Program Termination");
            AppProcesses.TerminateApp();
        }
    }
}
