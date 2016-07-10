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

        public static List<Student> SortStudentList(byte SortByVal)
        {
            IOrderedEnumerable<Student> sortedStudents = students as IOrderedEnumerable<Student>;

            switch (SortByVal)
            {
                case 1:
                    sortedStudents = students.OrderBy(o => o.FirstName);
                    break;
                case 2:
                    sortedStudents = students.OrderBy(o => o.LastName);
                    break;
                default:
                    break;
            }              

            return sortedStudents.ToList();
        }
    }
}
