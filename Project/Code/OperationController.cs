using System;
using System.Text;

using Project.Resources;
using System.Collections.Generic;
using System.Globalization;

namespace Project.Code
{
    public sealed class OperationController
    {
        Validator validator = new Validator();

        public string SelectOperation()
        {
            string inputConsole;
            StringBuilder output = new StringBuilder();
            var operationFields = typeof(Operations).GetFields();

            output.Append("Select operation: ");
            foreach (var field in operationFields)
            {
                output.Append(field.GetValue(field).ToString() + " \\");
            }
                                   
            Console.WriteLine(output);

            inputConsole = Console.ReadLine().ToUpper();
            ValidationStatus validation = validator.OperationValidator(inputConsole, operationFields);
            while (validation.Status != true)
            {
                Console.WriteLine(validation.Message);
                Console.WriteLine(output);
                inputConsole = Console.ReadLine().ToUpper();
                validation = validator.OperationValidator(inputConsole, operationFields);
            }

            return inputConsole;
        }

        public void AddNewStudent()
        {
            Students newStudent = new Students();
            string inputConsole;
            ValidationStatus validationStatus = null;

            Console.WriteLine("Student\n");

            // First Name input
            Console.Write("First Name: ");
            inputConsole = Console.ReadLine();

            validationStatus = validator.NameValidator(inputConsole);
            while (validationStatus.Status != true)
            {
                Console.WriteLine(validationStatus.Message);
                inputConsole = Console.ReadLine();
                validator.NameValidator(inputConsole);
            }
            newStudent.FirstName = inputConsole;

            // Last Name input
            Console.Write("Last Name: ");
            inputConsole = Console.ReadLine();
            validationStatus = validator.NameValidator(inputConsole);

            while (validationStatus.Status != true)
            {
                Console.WriteLine(validationStatus.Message);
                inputConsole = Console.ReadLine();
                validationStatus = validator.NameValidator(inputConsole);
            }
            newStudent.LastName = inputConsole;

            // Gpa input
            Console.Write("GPA: ");
            inputConsole = Console.ReadLine();
            validationStatus = validator.GpaValidator(inputConsole);

            while (validationStatus.Status != true)
            {
                Console.WriteLine(validationStatus.Message);
                Console.Write("GPA: ");
                inputConsole = Console.ReadLine();
                validationStatus = validator.GpaValidator(inputConsole);
            }
            newStudent.Gpa = float.Parse(inputConsole, CultureInfo.InvariantCulture.NumberFormat);

            StudentIdGenerator generateID = StudentIdGenerator.GetInstance;
            newStudent.Id = generateID.Id;
            StudentContainer.AddStudentToList(newStudent);
        }

        //Funkcija za Display studenata
        public void DisplayStudents()
        {
            List<Students> sortedStudents = StudentContainer.SortStudentList();
            int i = 1;
            Console.WriteLine("Students in a system:\n");
            foreach (Students student in sortedStudents)
            {
                Console.WriteLine(i++.ToString() + "." + "  " + student.Id + "  " + student.FirstName + ", " +
                student.LastName + " - " + student.Gpa);
            }
            Console.ReadKey();
            Console.Clear();
        }

    }
}
