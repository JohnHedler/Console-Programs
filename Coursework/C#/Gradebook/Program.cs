using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables.
            string teachFirstName = "", teachLastName = "", studentFirstName = "", studentLastName = "";
            double points = 0, percentage = 0;
            string grade = "";

            //Welcome.
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Hello, Professor.");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Please enter your identification.");
            Console.Write("First Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            teachFirstName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Last Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            teachLastName = Console.ReadLine();
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nProcessing");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("\n\nThank you.");
            System.Threading.Thread.Sleep(1000);
            System.Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello! Welcome to the Lindenburg School Gradebook program.");
            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThis program allows you to input student information regarding grades.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Once the grades are entered, the program will calculate a percent and score \nfor the student.");
            System.Threading.Thread.Sleep(1000);

            //Enter student information.
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPlease enter the student's first and last name.");
            Console.Write("First name: ");
            Console.ForegroundColor = ConsoleColor.White;
            studentFirstName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Last name: ");
            Console.ForegroundColor = ConsoleColor.White;
            studentLastName = Console.ReadLine();
            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThank you.");
            System.Threading.Thread.Sleep(500);

            //Enter student's points for class.
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nPlease enter " + studentFirstName + "'s points earned for the class (out of 1000): ");
            Console.ForegroundColor = ConsoleColor.White;
            points = Convert.ToDouble(Console.ReadLine());
            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThank you.");
            System.Threading.Thread.Sleep(1000);

            //Calculation of student's score from points.
            if ((points < 0) || (points > 1000))
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR: You have entered a bad score. Terminating program.");
                Console.ForegroundColor = ConsoleColor.White;
                goto BadScore;
            }
            else
            {
                Console.WriteLine("\nThank you for entering a proper score. Calculating.");
                System.Threading.Thread.Sleep(1000);
                percentage = points / 1000;
                if (percentage >= .895)
                {
                    grade = "A";
                }
                if ((percentage >= .795) && (percentage < .895))
                {
                    grade = "B";
                }
                if ((percentage >= .695) && (percentage < .795))
                {
                    grade = "C";
                }
                if ((percentage >= .595) && (percentage < .695))
                {
                    grade = "D";
                }
                if ((percentage >= .0) && (percentage < .595))
                {
                    grade = "F";
                }
            }

            //Display of gradebook.
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\nLindenburg School Gradebook");
            Console.WriteLine("=============================");
            Console.WriteLine("Student: " + studentLastName + ", " + studentFirstName);
            Console.WriteLine("Professor: " + teachLastName);
            Console.WriteLine("Points earned: " + points + "/1000");
            Console.WriteLine("Class Percentage: " + percentage.ToString("P"));
            Console.WriteLine("Grade: '" + grade + "'");
            System.Threading.Thread.Sleep(1000);

            //Goodbye.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThank you for using the Lindenburg School Gradebook program!");

        //Keep Window open and jump to from error.
        BadScore:
            Console.ReadLine();
        }
    }
}
