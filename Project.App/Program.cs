using System;
using System.Collections.Generic;
using Project.Code;

namespace Project.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation;
            bool exit = false;

            while (!exit)
            {
                operation = SelectOperation();

                switch (operation)
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

        //Funkcija za Display studenata
        static void DisplayStudents()
        {
            List<Students> sortedStudents = StudentContainer.SortStudentList();
            int i = 1;
            Console.WriteLine("Students in a system:\n");
            foreach (Students s in sortedStudents)
            {
                Console.WriteLine(i++.ToString() + "." + "  " + s.Id + "  " + s.FirstName + ", " +
                s.LastName + " - " + s.Gpa);
            }
        }

        //Funkcija za Enlist novog studenta
        static void AddNewStudent()
        {
            Console.WriteLine("Student");
            Students newStudent = new Students();
            string inputPerson;
            
            // First Name input
            Console.Write("First Name: ");
            inputPerson = Console.ReadLine();
            var personValidate = Validator.FirstNameValidator(inputPerson);

            while (!personValidate.ValidationSuccess)
            {
                Console.WriteLine(personValidate.GetError());
                inputPerson = Console.ReadLine().ToUpper();
                personValidate = Validator.FirstNameValidator(inputPerson);
            }
            newStudent.FirstName = inputPerson;

            // Last Name input
            Console.Write("Last Name: ");
            inputPerson = Console.ReadLine();
            personValidate = Validator.LastNameValidator(inputPerson);

            while (!personValidate.ValidationSuccess)
            {
                Console.WriteLine(personValidate.GetError());
                inputPerson = Console.ReadLine().ToUpper();
                personValidate = Validator.LastNameValidator(inputPerson);
            }
            newStudent.LastName = inputPerson;

            // Gpa input
            bool testGpa = false;
            float gpa;
            
            do
            {
                Console.Write("GPA: ");
                try
                {
                    gpa = float.Parse(Console.ReadLine());
                    newStudent.Gpa = gpa;
                    testGpa = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to insert numerical value.");
                    testGpa = false;
                }
            } while (testGpa == false);

            StudentIdGenerator generateID = StudentIdGenerator.GetInstance;
            newStudent.Id = generateID.Id;
            StudentContainer.AddStudentToList(newStudent);
        }

        static string SelectOperation()
        {
            string operation;
            string output = "Select operation: ";
            foreach (string str in Enum.GetNames(typeof(Operations.AvailableOperations)))
            {
                output += str + "/";
            }
            Console.WriteLine(output);
            operation = Console.ReadLine().ToUpper();
            var operationValidate = Validator.OperationValidator(operation);

            while (!operationValidate.ValidationSuccess)
            {
                Console.WriteLine(operationValidate.GetError());
                Console.WriteLine(output);
                operation = Console.ReadLine().ToUpper();
                operationValidate = Validator.OperationValidator(operation);
            }
            return operation;
        }
    }
}

