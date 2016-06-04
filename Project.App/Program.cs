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
            List<Student> StudentContainer = new List<Student>();
            string operation;

            start:
            do
            {
                Validator.displayError();
                Console.WriteLine("Select operation: ENLIST/DISPLAY");
                operation = Console.ReadLine().ToUpper();                

            } while (Validator.ValidateOperation(operation) == false);

            switch (operation)
            {
                case "ENLIST":
                    StudentContainer.Add(Operations.newStudent());
                    goto start;
                case "DISPLAY":
                    Operations.DisplayStudents(StudentContainer);
                    break;
            }
      
            Console.ReadKey();
        }
    }
}
