using System;

namespace Project.App
{   
    public class DisplaySystemData
    {
        private static DisplayFacade m_display = new DisplayFacade();  
              
        public static void Display()
        {
            Console.WriteLine("Select to display - (1) Students / (2) somethingelse");
            Byte userInput = Convert.ToByte(Console.ReadLine());
            if (userInput == 1)
            {
                Console.WriteLine("Sort by (1) First Name / (2) Last Name");
                Byte sortInput = Convert.ToByte(Console.ReadLine());

                m_display.DisplayStudents(sortInput);                           
            }                
        }

        private class DisplayFacade
        {
            private DisplayStudentData m_displayStudents;

            public DisplayFacade()
            {
                m_displayStudents = new DisplayStudentData();
            }

            // Method to call subsystem DisplayStudents
            public void DisplayStudents(byte SortByVal)
            {
                m_displayStudents.Display(SortByVal);
            }
        }
    }// DisplaySystemData    
}// Namespace Project.App.Code
