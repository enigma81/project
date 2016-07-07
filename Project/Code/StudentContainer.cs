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

        public static List<Student> SortStudentList()
        {
            IOrderedEnumerable<Student> orderByLastName = 
                students.OrderBy(o => o.LastName);

            return orderByLastName.ToList();
        }
    }
}
