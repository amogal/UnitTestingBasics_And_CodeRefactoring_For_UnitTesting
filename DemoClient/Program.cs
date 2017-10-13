using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoClassLibrary;

namespace DemoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculationFactory factory = new CalculationFactory();
            decimal a = 10;
            decimal b = 2;

            decimal result = factory.Divide(a, b);

            Console.WriteLine("Result of dividing " + a.ToString() + " by " + b.ToString() + " is " + result.ToString());
            Console.WriteLine();

            Console.WriteLine("***************************************************************");

            Console.WriteLine();

            //Invalid password
            string password = "amogal|2017";

            //Valid Password
            //string password = "BlitzOct17";
                        
            Console.WriteLine("Password selected: " + password);
            Console.WriteLine();                        
            //var validationtext = ValidatePassword.PassWordValid(password);
            var validationtext = RefactoredValidatePassword.PassWordValid(password);
            if (!string.IsNullOrEmpty(validationtext))
            {
                Console.WriteLine("Selected password is a NOT a VALID password ");
                Console.WriteLine();
                Console.WriteLine("**********************************************************************************");
                Console.WriteLine(validationtext);
                Console.WriteLine("**********************************************************************************");
            }
            else
            {
                Console.WriteLine("Selected password is a valid password");
            }

            Console.ReadLine();
        }
    }
}
