using Project.Code;
using System;
using System.Collections.Generic;

namespace Project.App
{
    class DisplayStudentData
    {
        private List<Student> m_sortedStudents;

        public void Display(int SortByVal)
        {
            switch (SortByVal)
            {
                case 1:
                    // Sort by First Name
                    break;
                case 2:
                    // Sort by Last Name
                    m_sortedStudents = StudentContainer.SortStudentList();
                    View1(m_sortedStudents);
                    break;
                default:
                    break;
            }
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
