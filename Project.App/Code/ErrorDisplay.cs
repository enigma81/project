using System;

namespace Project.App.Code
{
    class ErrorDisplay
    {
        public static void DisplayError(string Message)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Message);
            Console.ResetColor();
        }
    }
}
