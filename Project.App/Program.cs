using Project.Code;
using Project.Resources;
using System;
using System.Text;

namespace Project.App
{
    class StudentProgram
    {
        static void Main()
        {
            var runProgram       = true;
            string consoleMenu   = GetConsoleMenu();
            var validator        = new Validator();
            var studentScript    = new StudentScript();

            string userInput;
            ValidatorMessage validation;

            // Run program while runProgram is true 
            while (runProgram)
            {                
                do
                {
                    // Display Console Menu
                    Console.WriteLine(consoleMenu);
                    
                    userInput = Console.ReadLine().ToUpper();

                    // Validate user input against available operations and get ValidatorMessage
                    validation = validator.ValidateOperation(userInput);

                    if (validation.Status)
                    {
                        switch (userInput)
                        {
                            case "ENLIST":
                                studentScript.EnlistStudent(validator);
                                break;
                            case "DISPLAY":
                                studentScript.Display();
                                break;
                            case "EXIT":
                                runProgram = false;
                                break;
                        }
                    }
                    else
                    {
                        DisplayError.Display(validation.Message);
                    }                        

                } while (validation.Status != true);
            }            
        }

        // Build a string for the Console Menu
        private static string GetConsoleMenu()
        {
            StringBuilder menu = new StringBuilder();
            string [] availableOperations = Enum.GetNames(typeof(Operation.AvailableOperations));

            menu.Append("Select operation: ");
            
            foreach (var operation in availableOperations)
            {
                menu.Append(operation).Append(" \\");
            }
            return menu.ToString();
        }
    }//Program
}//Namespace Project.App