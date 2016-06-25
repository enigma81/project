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
               ValidateInput("First Name");

            } while (validation.Status != true);

            return consoleInput;
        }
        public string AddLastName()
        {
            do
            {
                ValidateInput("Last Name");

            } while (validation.Status != true);

            return consoleInput;
        }
        public float AddGpa()
        {
            do
            {
                ValidateInput("GPA");

            } while (validation.Status != true);

            return float.Parse(consoleInput, CultureInfo.InvariantCulture);
            
        }

        void ValidateInput(string input)
        {
            Console.Write("{0}: ",input);
            consoleInput = Console.ReadLine();

            switch (input)
            {
                case "First Name":
                    validation = studentValidator.ValidateName(consoleInput);
                    break;
                case "Last Name":
                    validation = studentValidator.ValidateName(consoleInput);
                    break;
                case "GPA":
                    validation = studentValidator.ValidateGpa(consoleInput);
                    break;
                default:
                    break;
            }            

            if (!validation.Status)
                Console.WriteLine(validation.Message);
        }

    }


}
