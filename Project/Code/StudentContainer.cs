using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public static class StudentContainer
    {
        static List<Student> students = new List<Student>();

        public static void addStudentToList()
        {
            students.Add(Operations.newStudent());
        }

        public static List<Student> sortStudentList()
        {
            return students.OrderBy(o => o.LastName).ToList();
        }
    }
}
