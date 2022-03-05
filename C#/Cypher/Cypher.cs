/*********************************************************************
 * Cypher Program (C#)
 * ------------------------------------------------------------------
 * User enters data into the application and it converts it over to
 * ASCII numbers. This data is saved to a text file, and the user is
 * able to receive data from the text file.
 * 
 * The data is read from the file, and converted back into text to
 * display to the user.
 ********************************************************************/
using System;
using System.IO;

namespace Cypher
{
    class Cypher
    {
        static void Main(string[] args)
        {
            //declare variables
            int option;

            //main program
            Console.WriteLine("Cypher Program");
            Console.WriteLine("==============");

            //call the function for user selection
            option = OptionSelect();

            //switch through returned choice for variable 'option'
            switch (option)
            {
                case '1': WriteFile(); break;
                case '2': ReadFile(); break;
                case '3': break;
                default: Console.WriteLine("\n\n**Error in detecting selection." +
                    " Please restart program and try again."); break;
            }

            //end program sequence
            Console.WriteLine();
            Console.WriteLine("Thank you for using this program. " +
                "Please press Enter to exit.");
            Console.ReadLine();
        }

        //declare functions
        static char OptionSelect()
        {
            //declare variables
            char option = 'a';

            //do loop until user selects the appropriate choice, or '3' to exit
            do
            {
                //display options to user
                Console.WriteLine("1) Write to file");
                Console.WriteLine("2) Read from file");
                Console.WriteLine("3) Exit Program");
                Console.Write("Please choose an option: ");

                try
                {
                    //assign user input to variable option
                    option = Convert.ToChar(Console.ReadLine());

                    //switch through choice to determine option
                    switch (option)
                    {
                        case '1': Console.WriteLine("Write..."); break;
                        case '2': Console.WriteLine("Read..."); break;
                        case '3': break;
                        default: Console.WriteLine("\n\n**Invalid input. Please try again."); break;
                    }
                }
                catch
                {
                    //catch for empty/null entry
                    Console.WriteLine("\n\n**Input must be a number. Please try again.");
                }
            } while (option != '1' && option != '2' && option != '3');

            return option;
        }

        static void WriteFile()
        {
            //declare variables
            string fileName;
            string userText;
            int convertLtr;

            try
            {
                //ask user for file name to be created and take input for the file's text
                Console.WriteLine("Please enter file name to be created:");
                fileName = Console.ReadLine();

                //check if file exists
                if (!File.Exists(fileName + ".txt"))
                {
                    //ask user for input
                    Console.WriteLine("Please enter text:");
                    userText = Console.ReadLine();

                    using (StreamWriter sw = File.CreateText(fileName + ".txt"))
                    {
                        //convert data to ASCII table integers
                        for (int i = 0; i < userText.Length; i++)
                        {
                            convertLtr = userText[i];
                            sw.Write(convertLtr + " ");
                        }
                        sw.Write("\n");
                    }

                    Console.WriteLine($"File '{fileName}.txt' has been successfully created and saved.");
                }
                else
                {
                    //ask user for input
                    Console.WriteLine("Please enter text:");
                    userText = Console.ReadLine();

                    using (StreamWriter sw = File.AppendText(fileName + ".txt"))
                    {
                        //convert data to ASCII table integers
                        for (int i = 0; i < userText.Length; i++)
                        {
                            convertLtr = userText[i];
                            sw.Write(convertLtr + " ");
                        }
                        sw.Write("\n");
                    }
                }
            }catch
            {
                Console.WriteLine("\n\n**Error creating file. Please try again.");
            }

        }

        static void ReadFile()
        {
            //declare variables
            string fileName;
            string textNum = "";
            int textWord;

            try
            {
                //ask user for file name
                Console.WriteLine("Please enter the file name to be read:");
                fileName = Console.ReadLine();

                //check if file exists
                if (!File.Exists(fileName + ".txt"))
                {
                    Console.WriteLine($"\n\n**Error 404: File '{fileName}.txt' not found.");
                }
                else
                {
                    //open file
                    using (StreamReader sr = File.OpenText(fileName + ".txt"))
                    {
                        string s;

                        //loop through each line to collect text
                        while ((s = sr.ReadLine()) != null)
                        {
                            //step through each index on the line of text
                            for (int i = 0; i < s.Length; i++)
                            {
                                //check if text is not a space
                                if(s[i] != ' ')
                                {
                                    if (char.IsNumber(s[i]))
                                    {
                                        textNum += s[i];
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\n\n**Error reading file '{fileName}.txt'. It may be damaged or corrupted.");
                                        return;
                                    }
                                }
                                
                                //check if text is a space
                                if(s[i] == ' ')
                                {
                                    textWord = Convert.ToInt32(textNum);
                                    Console.Write(Convert.ToChar(textWord));
                                    textNum = "";
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("\n\nEnd of file.");
                    }
                }
            }
            catch
            {
                Console.WriteLine("\n\n**Error reading file. It may be damaged or corrupted.");
            }
        }
    }
}