using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Code.Student> StudentContainer = new List<Code.Student>();
            string operation;

            start:
            do
            {
                if (Code.Validator.error != "")
                {
                    Console.WriteLine(Code.Validator.error);
                    Code.Validator.error = "";
                }
                Console.WriteLine("Select operation: ENLIST/DISPLAY");
                operation = Console.ReadLine().ToUpper();                

            } while (Code.Validator.ValidateOperation(operation) == false);

            switch (operation)
            {
                case "ENLIST":
                    StudentContainer.Add(Code.Operations.newStudent());
                    goto start;
                    
                case "DISPLAY":
                    foreach (Code.Student student in StudentContainer)
                    {
                        Code.Operations.DisplayStudents(student);                        
                    }
                    break;
            }
      
            Console.ReadKey();
        }
    }
}
