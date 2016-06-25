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

    class NewStudent : NewPerson
    {
        StudentsValidator studentValidator = ValidatorFactory.CreateValidator<StudentsValidator>();
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

            return float.Parse(consoleInput, CultureInfo.InvariantCulture);
            
        }
    }


}
