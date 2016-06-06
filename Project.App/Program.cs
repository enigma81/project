using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Code;

namespace Project.App
{
    class Program
    {
        static void Main(string[] args)
        {
           // List<Student> StudentContainer = new List<Student>();
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
