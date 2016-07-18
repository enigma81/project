using Project.Code;
using System;
using System.Collections.Generic;

namespace Project.App
{
    public class StudentScript
    {
        private const string FirstName = "First Name";
        private const string LastName = "Last Name";
        private const string Gpa = "Gpa";

        private Student student;
        private List<Student> sortedStudents;
        private Validator validator;
        private string userInput;
        private enum SortOptions { FirstName = 1, LastName };
        
        public void EnlistStudent(Validator Validator)
        {
            student = new Student();
            validator = Validator;

            StudentInput(FirstName);
            StudentInput(LastName);
            StudentInput(Gpa);
            
            Console.WriteLine($"Save - {"Y",-5}N");
            
            if(Console.ReadLine().ToUpper() == "Y")
            {
                student.Id = StudentIdGenerator.GetInstance.GenerateId();
                StudentContainer.GetInstance.AddStudentToList(student);
            }
                
        }

        public void Display()
        {
            Console.WriteLine("Sort by (1) First Name / (2) Last Name");
            
            int sortInput;
                        
            if (int.TryParse(Console.ReadLine(), out sortInput))
            {
                switch (sortInput)
                {
                    case (int)SortOptions.FirstName:
                        sortedStudents = StudentContainer.GetInstance.SortByFirstName();
                        break;

                    case (int)SortOptions.LastName:
                        sortedStudents = StudentContainer.GetInstance.SortByLastName();
                        break;

                    default:
                        sortedStudents = StudentContainer.GetInstance.GetStudents();
                        break;
                }
            }
            else
                sortedStudents = StudentContainer.GetInstance.GetStudents();

            View1(sortedStudents);
        }

        private void StudentInput(string StudentField)
        {
            ValidatorMessage validatorMessage;

            do
            {
                Console.WriteLine($"{StudentField}:");
                userInput = Console.ReadLine();

                if (StudentField == FirstName)
                    validatorMessage = validator.ValidateFirstName(userInput);
                else if (StudentField == LastName)
                    validatorMessage = validator.ValidateLastName(userInput);
                else if (StudentField == Gpa)
                    validatorMessage = validator.ValidateGpa(userInput);                
                else
                    return;

                if (validatorMessage.Status)
                {
                    switch (StudentField)
                    {
                        case FirstName:
                            student.FirstName = userInput;
                            break;

                        case LastName:
                            student.LastName = userInput;
                            break;

                        case Gpa:
                            student.Gpa = float.Parse(userInput);
                            break;
                    }
                }
                else
                {
                    DisplayError.Display(validatorMessage.Message);
                }

            } while (validatorMessage.Status != true);
        }

        #region Views
        private void View1(List<Student> Students)
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine("Students in a system:\n");
            Console.WriteLine($"{"Ord.No.",-10}{"ID",-5}{"First name",-20}{"Last name",-20}{"Gpa",5}\n");

            foreach (Student student in Students)
            {
                Console.WriteLine($"{i++}{".", -9}{student.Id,-5}{student.FirstName,-20}{student.LastName,-20}{student.Gpa,5}");
            }

            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        
    } // StudentScript
}// Namespace

