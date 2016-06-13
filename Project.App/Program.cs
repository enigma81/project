using System;
using System.Collections.Generic;
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
                operation = SelectOperation();

                switch (operation)
                {
                    case "ENLIST":
                        AddNewStudent();
                        break;
                    case "DISPLAY":
                        DisplayStudents();
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
      
            Console.ReadKey();
        }

        //Funkcija za Display studenata
        static void DisplayStudents()
        {
            List<Students> sortedStudents = StudentContainer.SortStudentList();
            int i = 1;
            Console.WriteLine("Students in a system:\n");
            foreach (Students s in sortedStudents)
            {
                Console.WriteLine(i++.ToString() + "." + "  " + s.Id + "  " + s.FirstName + ", " +
                s.LastName + " - " + s.Gpa);
            }
        }

        //Funkcija za Enlist novog studenta
        static void AddNewStudent()
        {
            Console.WriteLine("Student");
            Students newStudent = new Students();
            string input;

            do
            {
                DisplayError();
                Console.Write("First Name: ");
                input = Console.ReadLine();
            } while (Validator.ValidateName(input) == false);
            newStudent.FirstName = input;

            do
            {
                DisplayError();
                Console.Write("Last Name: ");
                input = Console.ReadLine();
            } while (Validator.ValidateName(input) == false);
            newStudent.LastName = input;

            bool testGpa = false;
            float gpa;
            /*System.Globalization.NumberStyles style;
            System.Globalization.CultureInfo culture;

            style = System.Globalization.NumberStyles.AllowDecimalPoint;
            culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            */
            do
            {
                Console.Write("GPA: ");
                try
                {
                    //gpa = (float)Convert.ToDecimal(Console.ReadLine());
                    //float.TryParse(Console.ReadLine(),style,culture,out gpa);
                    //gpa = string.Format("{0:0.#}", Console.ReadLine());
                    /*float.TryParse(Console.ReadLine(), 
                        System.Globalization.NumberStyles.Any, 
                        System.Globalization.NumberFormatInfo.InvariantInfo, out gpa);
                        */
                    gpa = float.Parse(Console.ReadLine());
                    newStudent.Gpa = gpa;
                    Console.WriteLine(gpa);
                    testGpa = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to insert numerical value.");
                    testGpa = false;
                }
            } while (testGpa == false);

            var generateID = StudentIdGenerator.GetInstance;
            newStudent.Id = generateID.Id;
            StudentContainer.AddStudentToList(newStudent);
        }

        static string SelectOperation()
        {
            string operation;

            do
            {
                DisplayError();
                Console.WriteLine("Select operation: ENLIST/DISPLAY");
                operation = Console.ReadLine().ToUpper();

            } while (Validator.ValidateOperation(operation) == false);

            return operation;
        }

        static void DisplayError()
        {
            if (Validator.error != "")
            {
                Console.WriteLine(Validator.error);
                Validator.error = "";
            }
        }
    }
}

