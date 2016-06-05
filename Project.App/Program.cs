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
            
            operation = Operations.selectOperation();

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
