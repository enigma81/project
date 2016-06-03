using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public static class Operations
    {
        public const string O_enlist = "ENLIST", O_display = "DISPLAY";

        public static void DisplayStudents(Student student)
        {
            Console.WriteLine(student.Id + "\t" + student.FirstName + "\t" + 
                student.LastName + "\t" + student.GPA);
        }

        public static Student newStudent()
        {
            Console.WriteLine("Student");
            Student newStudent = new Student();

            do
            {
                if (Code.Validator.error != "")
                {
                    Console.WriteLine(Code.Validator.error);
                    Code.Validator.error = "";
                }
                Console.Write("First Name: ");
                newStudent.FirstName = Console.ReadLine();
            } while (Validator.ValidateName(newStudent.FirstName) == false);

            
            Console.Write("Last Name: ");
            newStudent.LastName = Console.ReadLine();
            Console.Write("GPA: ");
            newStudent.GPA = Convert.ToDouble(Console.ReadLine());
            var generateID = StudentIdGenerator.getInstance;
            newStudent.Id = generateID.Id;
            return newStudent;
        }
    }

    
}
