using Project.Code;
using System;
using System.Globalization;

namespace Project.App
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
                    DisplayError.Display(m_validatorMessage.Message);
                }

            } while (m_validatorMessage.Status != true);
        }

    } // StudentScript
}// Namespace

