using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis115csharp
{
    class Program
    {

        static void Main(string[] args)
        {
            //Declare Variables
            double num1 = 0, num2 = 0, result = 0;
            string menuOption;


            //Get Data from User
            Console.Write("Enter 1st number: "); //Call the Console.Write Function. Pass prompt as a Parameter.
            num1 = Convert.ToDouble(Console.ReadLine()); //Call the Console.ReadLine Function. Save the Return Value in num1.
            Console.Write("Enter 2nd number: "); //Call the Console.Write Function. Pass prompt as a Parameter.
            num2 = Convert.ToDouble(Console.ReadLine()); //Call the Console.ReadLine Function. Save the Return Value in num2.

            //Prompt for and get menu selection
            Console.Write("Do you want to (A)dd, (S)ubtract, (M)ultiply, (D)ivide, or (E)xit? "); //Call the Console.Write Function. Pass prompt as a Parameter.
            menuOption = Console.ReadLine().ToUpper(); //Call the Console.ReadLine Function. Save the Return Value in menuOption.
            while (menuOption != "E") //Keep looping until user wants to Exit.
            {
                switch (menuOption)
                {//Handle Cases for Add, Subtract, Multiply, Divide
                    case "A":
                        result = AddNumbers(num1, num2); //Call AddNumbers() Function. Pass num1 and num2 as Parameters. Return Value is saved in result.
                        Console.WriteLine("The sum of the numbers is: " + result); //Call the Console.WriteLine Function. Pass message and result as a Parameter.
                        break;
                    case "S":
                        //Here's another way to call a Function. This time SubtractNumbers() is called from inside the Parameter list of the Console.WriteLine() Function. Return Value is displayed but NOT saved!
                        Console.WriteLine("The difference of the numbers is: " + SubtractNumbers(num1, num2));
                        break;
                    case "M":
                        result = MultiplyNumbers(num1, num2); //Call MultiplyNumbers() Function. Pass num1 and num2 as Parameters. Return Value is saved in result.
                        Console.WriteLine("The product of the numbers is: " + result); //Call the Console.WriteLine Function. Pass message and result as a Parameter.
                        break;
                    case "D":
                        result = DivideNumbers(num1, num2); //Call DivideNumbers() Function. Pass num1 and num2 as Parameters. Return Value is saved in result.
                        Console.WriteLine("The quotient of the numbers is: " + result); //Call the Console.WriteLine Function. Pass message and result as a Parameter.
                        break;
                    default:
                        Console.WriteLine("Invalid Menu Option. Please Try Again"); //If user enters an invalid menu option, they get this error.
                        break;
                }
                //Let the user try another menu option or exit.
                Console.Write("Do you want to (A)dd, (S)ubtrack, (M)ultiply, (D)ivide, or (E)xit? "); //Call the Console.Write Function. Pass prompt as a Parameter.
                menuOption = Console.ReadLine().ToUpper(); //Call the Console.ReadLine Function. Save the Return Value in menuOption.
            }
            Console.WriteLine("Goodbye"); //Call the Console.WriteLine Function. Pass message as a Parameter.
            Console.ReadLine(); //Call the Console.ReadLine Function. Ignore the return value.

        }

        //Declare AddNumbers() as a Function, with Return Type of Double
        //The Function accepts 2 parameters, locally refered to as a and b. Both are Double
        //Note that the data is passed according to position. The first parameter received becomes a, the second parameter received becomes b.
        public static double AddNumbers(double a, double b)
        {
            double answer;  //Decare answer variable as double
            answer = a + b; //Compute results
            return answer; //Return Value is sent back to Main()
        }

        //Declare SubtractNumbers() as a Function, with Return Type of Double
        //The Function accepts 2 parameters, locally refered to as a and b. Both are Double
        //Note that the data is passed according to position. The first parameter received becomes a, the second parameter received becomes b.
        public static double SubtractNumbers(double a, double b)
        {
            //In this variation, we don't declare a separate answer variable, instead, we just return the results.
            return a - b; //Return Value is sent back to Main()
        }

        //Declare MultiplyNumbers() as a Function, with Return Type of Double
        //The Function accepts 2 parameters, locally refered to as m1 and m2. Both are Double
        //Note that the data is passed according to position. The first parameter received becomes m1, the second parameter received becomes m2.
        public static double MultiplyNumbers(double m1, double m2)
        {
            return m1 * m2; //Return the product of m1 and m2 to Main()
        }

        //Declare DivideNumbers() as a Function, with Return Type of Double
        //The Function accepts 2 parameters, locally refered to as m1 and m2. Both are Double
        //Note that the data is passed according to position. The first parameter received becomes divident, the second parameter received becomes divisor.
        public static double DivideNumbers(double dividend, double divisor)
        {
            double quotient;  //Decare quotient variable as double
            quotient = dividend / divisor; //Compute results
            return quotient; //Return Value is sent back to Main()
        }

    }
}
