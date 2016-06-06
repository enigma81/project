using System;
using Project.Code;

namespace Project.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation;
            bool exit = false;

            while (!exit)
            {
                operation = Operations.selectOperation();

                switch (operation)
                {
                    case "ENLIST":
                        StudentContainer.addStudentToList();
                        break;
                    case "DISPLAY":
                        Operations.DisplayStudents();
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
      
            Console.ReadKey();
        }
    }
}
