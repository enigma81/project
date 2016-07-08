using Project.Code;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Project.App.Code
{
    public class StudentScript
    {
        private Student m_student;
        private Validator m_validator = new Validator();
        private ValidatorMessage m_validatorMessage;
        private string m_consoleInput;

        public void EnlistStudent()
        {
            m_student = new Student();
            
            UserInput("First Name");
            UserInput("Last Name");
            UserInput("Gpa");

            m_student.Id = StudentIdGenerator.GetInstance.GenerateId();

            StudentContainer.AddStudentToList(m_student);
        }

        public void DisplayStudents()
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

        private void UserInput(string Val)
        {
            do
            {
                Console.WriteLine("{0}:", Val);
                m_consoleInput = Console.ReadLine();

                if (Val == "First Name" || Val == "Last Name")
                    m_validatorMessage = m_validator.ValidateName(m_consoleInput);
                else if (Val == "Gpa")
                    m_validatorMessage = m_validator.ValidateGpa(m_consoleInput);
                else
                    return;

                if (m_validatorMessage.Status)
                {
                    switch (Val)
                    {
                        case "First Name":
                            m_student.FirstName = m_consoleInput;
                            break;

                        case "Last Name":
                            m_student.LastName = m_consoleInput;
                            break;

                        case "Gpa":
                            m_student.Gpa = float.Parse(m_consoleInput, CultureInfo.InvariantCulture);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    ErrorDisplay.DisplayError(m_validatorMessage.Message);
                }

            } while (m_validatorMessage.Status != true);
        }

    }
}

