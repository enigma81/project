using Project.Code;
using Project.Resources;
using System;
using System.Reflection;

namespace Project.App.Code
{
    class OperationScript
    {
        private FieldInfo[] operations = typeof(Operations).GetFields();
        private Validator validator = new Validator();
        private ValidatorMessage validatorMessage;

        private string consoleInput;

        // Build string output for console menu
        
        public string SelectOperation()
        { 
            do
            {
                Console.WriteLine(ConsoleMenu());
                consoleInput = Console.ReadLine().ToUpper();
                validatorMessage = validator.ValidateOperation(consoleInput, operations);

                if (!validatorMessage.Status)
                {
                    ErrorDisplay.DisplayError(validatorMessage.Message);
                }

            } while (validatorMessage.Status != true);

            return consoleInput;
        }

        private string ConsoleMenu()
        {
            string menu = "Select operation: ";

            foreach (var operation in operations)
            {
                menu += operation.GetValue(operation) + " \\";
            }
            return menu;
        }

    }//OperationScript
}//namespace
