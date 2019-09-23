/*********************************************************************
 * Program:     GPACalc
 * Student:     Jesse Quijano (#001456787)
 * Purpose:     Lab2 - Calculating Grade Point Averages
 * Description: Demonstrate Looping and Branching concepts without utilizing arrays
 *               or classes or unit tests
 *************************************************************************************/

using System;

namespace GPACalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName;
            string className;
            decimal totalCreditHours = 0;
            decimal totalPoints = 0;
            bool done = false;

            Console.WriteLine("Welcome to the Grade Point Calculator.");
            Console.WriteLine("----------------------------------------------------------");

            studentName = GetStudentName();
            
            // capture each class until the user says they are done
            while (!done)
            {
                // Get the name of the class that was taken
                className = GetClassName();

                // accept the number of units for the class
                var units = GetClassUnits();

                // capture a running total of the credits
                totalCreditHours += units;

                // Accept the letter grade
                var grade = GetLetterGrade();

                // let's calculate the total points by multiplying the grade by the 
                totalPoints += grade * units;

                Console.Write("Are you done entering your grades? (yes or no) ");
                var buffer = Console.ReadLine();
                done = EvaluateDone(buffer);
            }

            //output the report
            PrintReport(totalPoints, totalCreditHours);

            // pause so output can be seen
            Console.ReadLine();
        }

        /// <summary>
        /// This evaluates the input of the "are you done" prompt
        /// </summary>
        /// <param name="answer">What the user input</param>
        /// <returns>True if they said they are done, False if they did not</returns>
        static bool EvaluateDone(string answer)
        {
            var lowerAnswer = answer.Trim().ToLower();
            if (lowerAnswer == "yes" || lowerAnswer == "y")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Convert the letter grade entered to a number
        /// </summary>
        /// <param name="letterGrade">Character representing the grade received</param>
        /// <returns>Value of the letter grade entered</returns>
        static int GetGradeValue(char letterGrade)
        {
            int gradeValue;
            switch (Char.ToLower(letterGrade))  // convert to lower case to ensure we don't have case-sensitivity
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
                case 'f':
                    gradeValue = 0;
                    break;
                default:
                    gradeValue = -1;  // if they gave us something non-standard, report it
                    break;
            }

            return gradeValue;
        }

        /// <summary>
        /// Get the student's name from the command prompt.  Ensures we don't get a blank and keeps prompting if we do
        /// </summary>
        /// <returns>The student's name</returns>
        static string GetStudentName()
        {
            string studentName = "";

            while (String.IsNullOrEmpty(studentName.Trim()))
            {
                Console.Write("Please enter the student's name: ");
                studentName = Console.ReadLine();
                if (String.IsNullOrEmpty(studentName.Trim()))
                {
                    InvalidInput();
                }
            }

            return studentName;
        }

        /// <summary>
        /// Function to receive the input of the class name. Ensures we don't have 
        /// </summary>
        /// <returns></returns>
        static string GetClassName()
        {
            string buffer = "";
            while (String.IsNullOrEmpty(buffer.Trim()))
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

        /// <summary>
        /// Input loop to accept a letter grade and convert it to its numberic equivalent.
        /// Continues looping until an acceptable value is received.
        /// </summary>
        /// <returns>Integer representing the letter grade</returns>
        static int GetLetterGrade()
        {
            string buffer = "";
            int value = 0;

            while (String.IsNullOrEmpty(buffer.Trim()))
            {
                Console.Write("Enter the grade you received: ");
                buffer = Console.ReadLine();

                if (!ValidateGradeInput(buffer.Trim()))
                {
                    InvalidInput();
                    buffer = ""; // clear the buffer so we loop
                }
            }

            // all of the checks have passed, let's convert it to a number (int)
            value = GetGradeValue(buffer.Trim().ToCharArray()[0]);

            return value;
        }
        
        /// <summary>
        /// Accepts the result of keyboard input of a letter grade, and validates whether it's correct
        /// </summary>
        /// <param name="inputBuffer"></param>
        /// <returns></returns>
        static bool ValidateGradeInput(string inputBuffer)
        {
            // we only want to consider a single char
            char letterGrade = inputBuffer.ToCharArray()[0]; // we can only consider the first letter

            // basic checks to see if format is valid and it's a number
            if (IsNumber(letterGrade.ToString()) || String.IsNullOrEmpty(inputBuffer) || inputBuffer.Length > 1)
            {
                return false;
            }

            // now let's see if the input provided is a valid grade
            if (GetGradeValue(letterGrade) == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Accepts the hour/units for the course.  Loops until a valide number is received (0-5)
        /// </summary>
        /// <returns>Integer</returns>
        static int GetClassUnits()
        {
            string buffer = "";
            int retVal = 0;
            while (String.IsNullOrEmpty(buffer.Trim()))
            {
                Console.Write("Please enter the number of units for this class: ");
                buffer = Console.ReadLine();
                if (String.IsNullOrEmpty(buffer))
                {
                    InvalidInput();
                }

                if (!IsNumber(buffer))
                {
                    InvalidInput();
                    buffer = "";
                }

                int.TryParse(buffer.Trim(), out retVal);
                if (retVal < 0 || retVal > 5)
                {
                    InvalidInput();
                    buffer = "";
                }
            }

            return retVal;
        }

        /// <summary>
        /// Determine whether the string is a valid integer
        /// </summary>
        /// <param name="data">A string containing the data to be tested</param>
        /// <returns>True if the input is a number, False if not</returns>
        static bool IsNumber(string data)
        {
            return int.TryParse(data, out int value);
        }

        /*** output helpers ***/
        static void InvalidInput()
        {
            Console.WriteLine("Invalid entry, please try again.");
        }

        static void PrintReport(decimal totalPoints, decimal totalCreditHours)
        {
            Console.WriteLine($"Your grade point average is: {(totalPoints / totalCreditHours).ToString("0.000")}");
        }
    }
}