using Project.Code;
using Project.Resources;
using System;
using System.Reflection;

namespace Project.App
{
    class OperationScript
    {
        private FieldInfo[] m_operations = typeof(Operations).GetFields();
        private Validator m_validator = new Validator();
        private ValidatorMessage m_validatorMessage;

        private string m_consoleInput;

        // Build string output for console menu
        
        public string SelectOperation()
        { 
            do
            {
                DisplayConsoleMenu();
                m_consoleInput = Console.ReadLine().ToUpper();
                m_validatorMessage = m_validator.ValidateOperation(m_consoleInput, m_operations);

                if (!m_validatorMessage.Status)
                {
                    DisplayError.Display(m_validatorMessage.Message);
                }

            } while (m_validatorMessage.Status != true);

            return m_consoleInput;
        }

        private void DisplayConsoleMenu()
        {
            string menu = "Select operation: ";

            foreach (var operation in m_operations)
            {
                menu += operation.GetValue(operation) + " \\";
            }
            Console.WriteLine(menu);
        }

    }//OperationScript
}//namespace
