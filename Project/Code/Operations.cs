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

        //Funkcija za Display studenata
        public static void DisplayStudents()
        {
             List<Student> sortedStudent = StudentContainer.sortStudentList();
            int i = 1;
            Console.WriteLine("Students in a system:\n");
            foreach (Student s in sortedStudent)
            {
                Console.WriteLine(i++.ToString()+"." + "  " + s.Id + "  " + s.FirstName + ", " +
                s.LastName + " - " + s.GPA);
            }
        }

        //Funkcija za Enlist novog studenta
        public static Student newStudent()
        {
            Console.WriteLine("Student");
            Student newStudent = new Student();
            string input;
            
            do
            {
                Validator.displayError();
                Console.Write("First Name: ");
                input = Console.ReadLine();                
            } while (Validator.ValidateName(input) == false);
            newStudent.FirstName = input;

            do
            {
                Validator.displayError();
                Console.Write("Last Name: ");
                input = Console.ReadLine();
            } while (Validator.ValidateName(input) == false);
            newStudent.LastName = input;

            bool testGpa = false;
            float gpa;
            do {
                Console.Write("GPA: ");
                if (float.TryParse(Console.ReadLine(), out gpa))
                {
                    //Console.WriteLine(gpa);
                    newStudent.GPA = gpa;
                    testGpa = true;
                }else
                {
                    Console.WriteLine("You need to insert numerical value.");
                    testGpa = false;
                }
            } while (testGpa == false);
            
            var generateID = StudentIdGenerator.getInstance;
            newStudent.Id = generateID.Id;
            return newStudent;
        }

        public static string selectOperation()
        {
            string operation;

            do
            {
                Validator.displayError();
                Console.WriteLine("Select operation: ENLIST/DISPLAY");
                operation = Console.ReadLine().ToUpper();

            } while (Validator.ValidateOperation(operation) == false);

            return operation;
        }
    }

    
}
