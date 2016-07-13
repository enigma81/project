using System.Collections.Generic;
using System.Linq;

namespace Project.Code
{
    public class StudentContainer
    {
        private static List<Student> students = new List<Student>();
        
        public static void AddStudentToList(Student student)
        {
            students.Add(student);
        }

        public static List<Student> GetStudents()
        {
            return students;
        }

        public static List<Student> SortByFirstName()
        { 
            return students.OrderBy(o => o.FirstName).ToList();
        }

        public static List<Student> SortByLastName()
        {
            return students.OrderBy(o => o.LastName).ToList();
        }
    }
}
