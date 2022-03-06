using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInterface
{
    class InputProcesses
    {
        public static string GetInput(string inputType)
        {
            //declare variables
            string strInput;

            //loop until user enters correct data
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nPlease enter the " + inputType + ": ");
                strInput = Console.ReadLine();

                if(strInput == null || strInput == "")
                {
                    Console.WriteLine("\n\n**Input cannot be blank.");
                }
                else
                {
                    return strInput;
                }
            } while (strInput != null || strInput != "");

            //return variables
            return strInput;
        }
    }
}
