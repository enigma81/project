using System;
using System.Text;

using Project.Resources;
using System.Collections.Generic;
using System.Globalization;

namespace Project.Code
{
    public sealed class OperationController
    { 
        public string SelectOperation()
        {
            string inputConsole;
            StringBuilder output = new StringBuilder();
            var operationFields = typeof(Operations).GetFields();
            var validator = ValidatorFactory.CreateValidator<OperationValidator>();

            output.Append("Select operation: ");
            foreach (var field in operationFields)
            {
                output.Append(field.GetValue(field).ToString() + " \\");
            }
                                   
            Console.WriteLine(output);

            
            inputConsole = Console.ReadLine().ToUpper();
            validator.Validate(inputConsole, operationFields);

            while (validator.validatorMessage.Status != true)
            {
                Console.WriteLine(validator.validatorMessage.Message);
                Console.WriteLine(output);
                inputConsole = Console.ReadLine().ToUpper();
                validator.Validate(inputConsole, operationFields);
            }

            return inputConsole;
        }

        public void AddNewStudent()
        {
            Students newStudent = new Students();
            var validator = ValidatorFactory.CreateValidator<StudentsValidator>();
            string inputConsole;

            Console.WriteLine("Student\n");

            // First Name input
            Console.Write("First Name: ");
            inputConsole = Console.ReadLine();

            validator.ValidateName(inputConsole);
            while (validator.validatorMessage.Status != true)
            {
                Console.WriteLine(validator.validatorMessage.Message);
                inputConsole = Console.ReadLine();
                validator.ValidateName(inputConsole);
            }
            newStudent.FirstName = inputConsole;

            // Last Name input
            Console.Write("Last Name: ");
            inputConsole = Console.ReadLine();
            validator.ValidateName(inputConsole);

            while (validator.validatorMessage.Status != true)
            {
                Console.WriteLine(validator.validatorMessage.Message);
                inputConsole = Console.ReadLine();
                validator.ValidateName(inputConsole);
            }
            newStudent.LastName = inputConsole;

            // Gpa input
            Console.Write("GPA: ");
            inputConsole = Console.ReadLine();
            validator.ValidateGpa(inputConsole);

            while (validator.validatorMessage.Status != true)
            {
                Console.WriteLine(validator.validatorMessage.Message);
                Console.Write("GPA: ");
                inputConsole = Console.ReadLine();
                validator.ValidateGpa(inputConsole);
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
