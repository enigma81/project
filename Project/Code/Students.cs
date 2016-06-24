using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Project.Code
{
    public class Students : Person
    {
        public float Gpa { get; set; }
    }

    public sealed class StudentIdGenerator
    {
        private static readonly StudentIdGenerator _instance = new StudentIdGenerator();
        private int _id;

        public int GenerateId()
        {
            _id++;
            return _id;
        }

        private StudentIdGenerator() { _id = 0; }

        public static StudentIdGenerator GetInstance
        {
            get
            {
                return _instance;
            }
        }
    }

    public static class StudentsContainer
    {
        static List<Students> students = new List<Students>();

        public static void AddStudentToList(Students student)
        {
            students.Add(student);
        }

        public static List<Students> SortStudentList()
        {
            return students.OrderBy(o => o.LastName).ToList();
        }
    }

    class NewStudent
    {
        ValidatorMessage validation;
        StudentsValidator studentValidator = ValidatorFactory.CreateValidator<StudentsValidator>();
        string consoleInput;
        public string AddFirstName()
        {
            do
            {
                Console.Write("First Name: ");
                ValidateNameInput();

            } while (validation.Status != true);

            return consoleInput;
        }
        public string AddLastName()
        {
            do
            {
                Console.Write("Last Name: ");
                ValidateNameInput();

            } while (validation.Status != true);

            return consoleInput;
        }
        public float AddGpa()
        {
            do
            {
                Console.Write("GPA: ");
                consoleInput = Console.ReadLine();
                validation = studentValidator.ValidateGpa(consoleInput);

                if (!validation.Status)
                    Console.WriteLine(validation.Message);

            } while (validation.Status != true);


            return float.Parse(consoleInput, CultureInfo.InvariantCulture.NumberFormat);
        }

        void ValidateNameInput()
        {
            consoleInput = Console.ReadLine();
            validation = studentValidator.ValidateName(consoleInput);

            if (!validation.Status)
                Console.WriteLine(validation.Message);
        }

    }


}
