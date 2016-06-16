using System;
using System.Collections.Generic;
using Project.Code;
using System.Globalization;

namespace Project.App
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool exit = false;           

            while (!exit)
            {
                string inputConsole = SelectOperation();

                switch (inputConsole)
                {
                    case "ENLIST":
                        AddNewStudent();
                        break;
                    case "DISPLAY":
                        DisplayStudents();
                        exit = true;
                        break;
                    default:
                        break;
                }
            }      
            Console.ReadKey();
        }

        #region Program static functions

        //Funkcija za Display studenata
        static void DisplayStudents()
        {
            List<Students> sortedStudents = StudentContainer.SortStudentList();
            int i = 1;
            Console.WriteLine("Students in a system:\n");
            foreach (Students student in sortedStudents)
            {
                Console.WriteLine(i++.ToString() + "." + "  " + student.Id + "  " + student.FirstName + ", " +
                student.LastName + " - " + student.Gpa);
            }
        }

        //Funkcija za Enlist novog studenta
        static void AddNewStudent()
        {
            Console.WriteLine("Student");
            Students newStudent = new Students();
            
            // First Name input
            Console.Write("First Name: ");
            string inputConsole = Console.ReadLine();
            var personValidate = Validator.FirstNameValidator(inputConsole);

            while (!personValidate.Status)
            {
                Console.WriteLine(personValidate.Message);
                inputConsole = Console.ReadLine().ToUpper();
                Validator.FirstNameValidator(inputConsole);
            }
            newStudent.FirstName = inputConsole;

            // Last Name input
            Console.Write("Last Name: ");
            inputConsole = Console.ReadLine();
            personValidate = Validator.LastNameValidator(inputConsole);

            while (!personValidate.Status)
            {
                Console.WriteLine(personValidate.Message);
                inputConsole = Console.ReadLine().ToUpper();
                personValidate = Validator.LastNameValidator(inputConsole);
            }
            newStudent.LastName = inputConsole;

            // Gpa input
            Console.Write("GPA: ");
            inputConsole = Console.ReadLine();
            personValidate = Validator.GpaValidator(inputConsole);

            while (!personValidate.Status)
            {
                Console.WriteLine(personValidate.Message);
                Console.Write("GPA: ");
                inputConsole = Console.ReadLine();
                personValidate = Validator.GpaValidator(inputConsole);
            }
            newStudent.Gpa = float.Parse(inputConsole, CultureInfo.InvariantCulture.NumberFormat);
            
            StudentIdGenerator generateID = StudentIdGenerator.GetInstance;
            newStudent.Id = generateID.Id;
            StudentContainer.AddStudentToList(newStudent);
        }

        static string SelectOperation()
        {
            string output = "Select operation: ";
            foreach (string str in Enum.GetNames(typeof(Operations.AvailableOperations)))
            {
                output += str + "/";
            }
            Console.WriteLine(output);
            string inputConsole = Console.ReadLine().ToUpper();
            var operationValidate = Validator.OperationValidator(inputConsole);

            while (!operationValidate.Status)
            {
                Console.WriteLine(operationValidate.Message);
                Console.WriteLine(output);
                inputConsole = Console.ReadLine().ToUpper(); 
                operationValidate = Validator.OperationValidator(inputConsole);
            }
            return inputConsole;
        }
        #endregion
    }
}

