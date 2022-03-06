using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInterface
{
    class AppProcesses
    {
        public static void DisplayAppInfo()
        {
            //Welcome message displayed to user.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Basic User Interface Program");
            Console.WriteLine("============================");
            Console.WriteLine("This program takes input from the user and outputs data to the user.");
        }

        public static void DisplayDiv(string outputTitle)
        {
            //Display title of input prompt to user.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n**************** " + outputTitle + " ****************");
        }

        public static void TerminateApp()
        {
            //Display end of program message to user.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nThank you for using this program. Press Enter to quit.");

            //Keep console open.
            Console.ReadLine();
        }
    }
}
