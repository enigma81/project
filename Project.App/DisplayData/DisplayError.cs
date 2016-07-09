using System;

namespace Project.App
{
    class DisplayError
    {
        public static void Display(string Message)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Message);
            Console.ResetColor();
        }
    }
}
