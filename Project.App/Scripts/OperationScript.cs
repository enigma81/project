using Project.Code;
using Project.Resources;
using System;
using System.Reflection;

namespace Project.App
{
    class OperationScript
    {
        private ValidatorMessage m_validatorMessage;

        private string m_consoleInput;
        private string m_menu;

        public OperationScript()
        {
            m_menu = GetConsoleMenu();
        }        
        
        public string SelectOperation()
        { 
            do
            {
                Console.WriteLine(m_menu);
                m_consoleInput = Console.ReadLine().ToUpper();
                m_validatorMessage = Validator.IsValid(this, m_consoleInput);
                
                if (!m_validatorMessage.Status)
                {
                    DisplayError.Display(m_validatorMessage.Message);
                }

            } while (m_validatorMessage.Status != true);

            return m_consoleInput;
        }

        private string GetConsoleMenu()
        {
            FieldInfo[] operations = typeof(Operations).GetFields();
            string menu = "Select operation: ";

            foreach (var operation in operations)
            {
                menu += operation.GetValue(operation) + " \\";
            }
            return menu;
        }

    }//OperationScript
}//namespace
