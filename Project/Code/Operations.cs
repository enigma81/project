using System;
using System.Collections.Generic;


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
                Console.WriteLine(i++.ToString()+"." + "  " + s.getId() + "  " + s.getFirstname() + ", " +
                s.getLastname() + " - " + s.GPA);
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
            newStudent.setFirstname(input);

            do
            {
                Validator.displayError();
                Console.Write("Last Name: ");
                input = Console.ReadLine();
            } while (Validator.ValidateName(input) == false);
            newStudent.setLastname(input);

            bool testGpa = false;
            float gpa;
            /*System.Globalization.NumberStyles style;
            System.Globalization.CultureInfo culture;

            style = System.Globalization.NumberStyles.AllowDecimalPoint;
            culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            */
            do {
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
                    newStudent.GPA = gpa;
                    Console.WriteLine(gpa);
                    testGpa = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to insert numerical value.");
                    testGpa = false;

                }
            } while (testGpa == false);
            
            var generateID = StudentIdGenerator.getInstance;
            newStudent.setId(generateID.Id);
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
