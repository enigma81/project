using System.Collections.Generic;
using System.Linq;

namespace Project.Code
{
    public sealed class StudentContainer
    {
        private static readonly StudentContainer instance = new StudentContainer();
        private List<Student> students;

        private StudentContainer()
        {
            students = new List<Student>();
        }

        public static StudentContainer GetInstance
        {
            get
            {
                return instance;
            }
        }
        
        public void AddStudentToList(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public List<Student> SortByFirstName()
        { 
            return students.OrderBy(o => o.FirstName).ToList();
        }

        public List<Student> SortByLastName()
        {
            return students.OrderBy(o => o.LastName).ToList();
        }
    }
}
