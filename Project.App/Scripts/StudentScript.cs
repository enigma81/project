using Project.Code;
using System;
using System.Collections.Generic;

namespace Project.App
{
    public class StudentScript
    {
        private Student m_student;
        private List<Student> m_sortedStudents;
        private Validator m_validator;
        private ValidatorMessage m_validatorMessage;
        private string m_userInput;
        private enum SortOptions : byte { FirstName = 1, LastName };

        public void EnlistStudent(Validator Validator)
        {
            m_student = new Student();
            m_validator = Validator;

            StudentInput("First Name");
            StudentInput("Last Name");
            StudentInput("Gpa");

            m_student.Id = StudentIdGenerator.GetInstance.GenerateId();

            StudentContainer.AddStudentToList(m_student);
        }

        public void Display()
        {
            Console.WriteLine("Sort by (1) First Name / (2) Last Name");
            byte sortInput = 0;

            try
            {                
                sortInput = byte.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }    

            switch (sortInput)
            {
                case (byte)SortOptions.FirstName:
                    m_sortedStudents = StudentContainer.SortByFirstName();
                    break;

                case (byte)SortOptions.LastName:
                    m_sortedStudents = StudentContainer.SortByLastName();
                    break;

                default:
                    m_sortedStudents = StudentContainer.GetStudents();
                    break;
            }

            View1(m_sortedStudents);
        }

        private void StudentInput(string StudentField)
        {
            do
            {
                Console.WriteLine($"{StudentField}:");
                m_userInput = Console.ReadLine();

                if (StudentField == "First Name")
                    m_validatorMessage = m_validator.ValidateFirstName(m_userInput);
                else if (StudentField == "Last Name")
                    m_validatorMessage = m_validator.ValidateLastName(m_userInput);
                else if (StudentField == "Gpa")
                    m_validatorMessage = m_validator.ValidateGpa(m_userInput);                
                else
                    return;

                if (m_validatorMessage.Status)
                {
                    switch (StudentField)
                    {
                        case "First Name":
                            m_student.FirstName = m_userInput;
                            break;

                        case "Last Name":
                            m_student.LastName = m_userInput;
                            break;

                        case "Gpa":
                            m_student.Gpa = float.Parse(m_userInput);
                            break;
                    }
                }
                else
                {
                    DisplayError.Display(m_validatorMessage.Message);
                }

            } while (m_validatorMessage.Status != true);
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

