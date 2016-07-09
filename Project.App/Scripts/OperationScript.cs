using Project.Code;
using Project.Resources;
using System;
using System.Reflection;

namespace Project.App
{
    class OperationScript
    {
        private FieldInfo[] m_operations;
        private Validator m_validator;
        private ValidatorMessage m_validatorMessage;

        private string m_consoleInput;
        private string m_menu;

        public OperationScript()
        {
            m_operations = typeof(Operations).GetFields();
            m_validator = new Validator();
            m_menu = GetConsoleMenu();
        }        
        
        public string SelectOperation()
        { 
            do
            {
                Console.WriteLine(m_menu);
                m_consoleInput = Console.ReadLine().ToUpper();
                m_validatorMessage = m_validator.ValidateOperation(m_consoleInput, m_operations);

                if (!m_validatorMessage.Status)
                {
                    DisplayError.Display(m_validatorMessage.Message);
                }

            } while (m_validatorMessage.Status != true);

            return m_consoleInput;
        }

        private string GetConsoleMenu()
        {
            string menu = "Select operation: ";

            foreach (var operation in m_operations)
            {
                menu += operation.GetValue(operation) + " \\";
            }
            return menu;
        }

    }//OperationScript
}//namespace
