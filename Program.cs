using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = "";

            Console.WriteLine("Welcome to the Grade Point Calculator.");
            Console.WriteLine("--------------------------------------");

            while (String.IsNullOrEmpty(studentName.Trim()))
            {
                Console.WriteLine("Please Enter the Student's Name:");
                studentName = Console.ReadLine();
                if (String.IsNullOrEmpty(studentName.Trim()))
                {
                    Console.WriteLine("Invalid entry, please try again.");
                }
            }


            Console.ReadLine();
        }
    }
}
