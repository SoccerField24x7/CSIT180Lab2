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
            string studentName;
            string className;

            Console.WriteLine("Welcome to the Grade Point Calculator.");
            Console.WriteLine("--------------------------------------");

            studentName = GetStudentName();

            decimal counter = 0;
            decimal totalCreditHours = 0;
            decimal totalPoints = 0; //totalPoints / totalCreditHours = GPA
            bool done = false;
            int unitTotal = 0;

            while (!done)
            {

                className = GetClassName();

                //Console.Write("Enter the number of units for the class: ");
                //var buffer = Console.ReadLine();
                var units = GetClassUnits();
                totalCreditHours += units;

                //Console.Write("Enter the letter grade received (do not add + or -): ");
                //var buffer = Console.ReadLine();
                var grade = GetLetterGrade();

                totalCreditHours += units * grade;

                counter++;

                Console.Write("Are you done entering your grades? (yes or no) ");
                var buffer = Console.ReadLine();
                done = EvaluateDone(buffer);
            }

            Console.ReadLine();
        }

        static bool EvaluateDone(string answer)
        {
            var lowerAnswer = answer.Trim().ToLower();
            if (lowerAnswer == "yes" || lowerAnswer == "y")
            {
                return true;
            }

            return false;
        }

        static int GetGradeValue(char letterGrade)
        {
            int gradeValue;
            switch (Char.ToLower(letterGrade))
            {
                case 'a':
                    gradeValue = 4;
                    break;
                case 'b':
                    gradeValue = 3;
                    break;
                case 'c':
                    gradeValue = 2;
                    break;
                case 'd':
                    gradeValue = 1;
                    break;
                default:
                    gradeValue = 0;
                    break;
            }

            return gradeValue;
        }

        static string GetStudentName()
        {
            string studentName = "";

            while (String.IsNullOrEmpty(studentName.Trim()))
            {
                Console.Write("Please Enter the Student's Name: ");
                studentName = Console.ReadLine();
                if (String.IsNullOrEmpty(studentName.Trim()))
                {
                    InvalidInput();
                }
            }

            return studentName;
        }

        static string GetClassName()
        {
            string buffer = "";
            while (String.IsNullOrEmpty(buffer))
            {
                Console.Write("Please enter the name of the class: ");
                buffer = Console.ReadLine();
                if (String.IsNullOrEmpty(buffer))
                {
                    InvalidInput();
                }
            }

            return buffer;
        }

        static int GetLetterGrade()
        {
            string buffer = "";
            int value = 0;

            while (String.IsNullOrEmpty(buffer))
            {
                Console.Write("Enter the grade you received: ");
                buffer = Console.ReadLine();
                if (String.IsNullOrEmpty(buffer) || buffer.Length > 1)
                {
                    InvalidInput();
                }
            }

            value = GetGradeValue(buffer.Trim().ToCharArray()[0]); // send only the first character to the function

            return value;
        }

        static int GetClassUnits()
        {
            string buffer = "";
            int retVal = 0;
            while (String.IsNullOrEmpty(buffer))
            {
                Console.Write("Please enter the number of units for this class: ");
                buffer = Console.ReadLine();
                if (String.IsNullOrEmpty(buffer))
                {
                    InvalidInput();
                }

                var result = int.TryParse(buffer, out retVal);
                if (result == false)
                {
                    InvalidInput();
                    buffer = "";
                }
            }

            return retVal;
        }

        static void InvalidInput()
        {
            Console.WriteLine("Invalid entry, please try again.");
        }

        static void PrintReport()
        {
        }
    }
}