using Project.Code;
using System;
using System.Collections.Generic;

namespace Project.App
{
    public class StudentScript
    {
        private Student student;
        private List<Student> sortedStudents;
        private Validator validator;
        private enum StudentField { FirstName = 1, LastName, Gpa };
        
        public void EnlistStudent(Validator Validator)
        {
            student = new Student();
            validator = Validator;

            StudentInput(StudentField.FirstName);
            StudentInput(StudentField.LastName);
            StudentInput(StudentField.Gpa);
            
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
                    case (int)StudentField.FirstName:
                        sortedStudents = StudentContainer.GetInstance.SortByFirstName();
                        break;

                    case (int)StudentField.LastName:
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

        private void StudentInput(StudentField StudentField)
        {
            ValidatorMessage validatorMessage;
            string userInput;

            do
            {
                Console.WriteLine($"{StudentField}:");
                userInput = Console.ReadLine();

                if (StudentField == StudentField.FirstName)
                    validatorMessage = validator.ValidateFirstName(userInput);
                else if (StudentField == StudentField.LastName)
                    validatorMessage = validator.ValidateLastName(userInput);
                else if (StudentField == StudentField.Gpa)
                    validatorMessage = validator.ValidateGpa(userInput);                
                else
                    return;

                if (validatorMessage.Status)
                {
                    switch (StudentField)
                    {
                        case StudentField.FirstName:
                            student.FirstName = userInput;
                            break;

                        case StudentField.LastName:
                            student.LastName = userInput;
                            break;

                        case StudentField.Gpa:
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

