using System;
using Project.Code;
using System.Reflection;
using Project.Resources;
using System.Collections.Generic;

namespace Project.App
{
    class Program
    {       
        static void Main(string[] args)
        {
            bool exit = false;
            FieldInfo[] operations = typeof(Operations).GetFields();
            Validator validator = new Validator();
            ValidatorMessage validatorMessage;

            string consoleInput;

            // Build string output for console menu
            string consoleMenu = "Select operation: ";

            foreach (var operation in operations)
            {
                consoleMenu += operation.GetValue(operation) + " \\";
            }

            // Loop program until exit is set to true
            while (!exit)
            {                
                do
                {
                    Console.WriteLine(consoleMenu);
                    consoleInput = Console.ReadLine().ToUpper();
                    validatorMessage = validator.ValidateOperation(consoleInput, operations);

                    if (!validatorMessage.Status)
                    {
                        DisplayError(validatorMessage.Message);
                    }

                } while (validatorMessage.Status != true);

                // Switch user consoleInput against available operations
                switch (consoleInput)
                {
                    case Operations.enlist:
                        // Napravi nešto na enlist komandu
                        EnlistStudent();
                        break;
                    case Operations.display:
                        DisplayStudents();
                        break;
                    case Operations.exit :
                        exit = true;
                        break;
                }
            }
        }
        
        private static void EnlistStudent()
        {
            var studentScript = new StudentScript();
            Validator validator = new Validator();
            ValidatorMessage validatorMessage;
            string consoleInput;

            do
            {
                Console.WriteLine("First name:");
                consoleInput = Console.ReadLine();
                validatorMessage = validator.ValidateName(consoleInput);

                if (validatorMessage.Status)
                {
                    studentScript.SetFirstName(consoleInput);
                }
                else
                {
                    DisplayError(validatorMessage.Message);
                }
            } while (validatorMessage.Status != true);
        }

        private static void DisplayError(string Message)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Message);
            Console.ResetColor();
        }

        private static void DisplayStudents()
        {
            List<Student> sortedStudents = StudentContainer.SortStudentList();
            int i = 1;
            Console.Clear();
            Console.WriteLine("Students in a system:\n");
            Console.WriteLine("{0,-10}{1,-5}{2,-20}{3,-20}{4,5}\n", "Red.br.", "ID", "First name", "Last name", "Gpa");
            foreach (Student student in sortedStudents)
            {
                Console.WriteLine(String.Format("{0}.         {1,-5}{2,-20}{3,-20}{4,-5}"
                        , i++, student.Id, student.FirstName, student.LastName, student.Gpa.ToString()));
            }
            Console.ReadKey();
            Console.Clear();
        }
    }//Program
}//Namespace Project.App

