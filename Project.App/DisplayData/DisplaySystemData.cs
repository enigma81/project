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
                m_display.DisplayStudents();
            }
            else
                return;               
        }

        private class DisplayFacade
        {
            private DisplayStudentData m_displayStudents;

            public DisplayFacade()
            {
                m_displayStudents = new DisplayStudentData();
            }

            // Method to call subsystem DisplayStudents
            public void DisplayStudents()
            {
                m_displayStudents.Display();
            }
        }
    }// DisplaySystemData    
}// Namespace Project.App.Code
