using Project.Code;
using System;
using System.Collections.Generic;

namespace Project.App
{
    class DisplayStudentData
    {
        private List<Student> m_sortedStudents;

        public void Display()
        {
            Console.WriteLine("Sort by (1) First Name / (2) Last Name");
            Byte sortInput = Convert.ToByte(Console.ReadLine());

            m_sortedStudents = StudentContainer.SortStudentList(sortInput);
            View1(m_sortedStudents);
        }

        #region Views
        private void View1(List<Student> Students)
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine("Students in a system:\n");
            Console.WriteLine("{0,-10}{1,-5}{2,-20}{3,-20}{4,5}\n", "Red.br.", "ID", "First name", "Last name", "Gpa");
            foreach (Student student in Students)
            {
                Console.WriteLine(String.Format("{0}.         {1,-5}{2,-20}{3,-20}{4,-5}"
                        , i++, student.Id, student.FirstName, student.LastName, student.Gpa.ToString()));
            }
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
    }
}
