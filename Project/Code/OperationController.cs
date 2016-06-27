using System;
using System.Text;
using System.Reflection;
using Project.Resources;
using System.Collections.Generic;

namespace Project.Code
{
    public sealed class OperationController
    {
        public string SelectOperation()
        {
            ValidatorMessage validation;
            string consoleInput;
            FieldInfo[] operationFields = typeof(Operations).GetFields();
            var operationValidator = ValidatorFactory.CreateValidator<OperationValidator>();
            StringBuilder output = new StringBuilder();

            output.Append("Select operation: ");
            foreach (var field in operationFields)
            {
                output.Append(field.GetValue(field)).Append(" \\");
            }

            do
            {
                Console.WriteLine(output);
                consoleInput = Console.ReadLine().ToUpper();
                validation = operationValidator.ValidateOperation(consoleInput, operationFields);
                if (!validation.Status)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(validation.Message);
                    Console.ResetColor();
                }
            } while (validation.Status != true);

            return consoleInput;
        }

        public void AddNewStudent()
        {
            Students student = new Students();
            NewStudent newStudent = new NewStudent();

            Console.WriteLine("Student:\n");

            student.FirstName    = newStudent.AddFirstName();
            student.LastName     = newStudent.AddLastName();
            student.Gpa          = newStudent.AddGpa();
            student.Id           = StudentIdGenerator.GetInstance.GenerateId();
            StudentsContainer.AddStudentToList(student);
        }

        //Funkcija za Display studenata
        public void DisplayStudents()
        {
            //List<Students> sortedStudents = StudentsContainer.SortStudentList();
            StudentsContainer.SortStudentList();
            int i = 1;
            Console.WriteLine("Students in a system:\n");
            Console.WriteLine("{0,-10}{1,-5}{2,-20}{3,-20}{4,5}\n", "Red.br.", "ID", "First name", "Last name", "Gpa");
            foreach (Students student in StudentsContainer.students)
            {
                Console.WriteLine(String.Format("{0}.         {1,-5}{2,-20}{3,-20}{4,-5}"
                        , i++, student.Id, student.FirstName, student.LastName, student.Gpa.ToString()));
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
