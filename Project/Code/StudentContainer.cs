using System.Collections.Generic;
using System.Linq;


namespace Project.Code
{
    public static class StudentContainer
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
}
