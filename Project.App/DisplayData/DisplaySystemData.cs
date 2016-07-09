using System;

namespace Project.App
{   
    public class DisplaySystemData
    {
        private static DisplayFacade m_display = new DisplayFacade();  
              
        public static void Display()
        {
            Console.WriteLine("Select to display - (1) Students / (2) somethingelse");
            SByte userInput = Convert.ToSByte(Console.ReadLine());
            if (userInput == 1)
            {
                Console.WriteLine("Sort by (1) First Name / (2) Last Name");
                userInput = Convert.ToSByte(Console.ReadLine());

                // Switch int userInput
                switch (userInput)
                {
                    case 1:
                        m_display.DisplayStudents(1);
                        break;

                    case 2:
                        m_display.DisplayStudents(2);
                        break;

                    default:
                        break;
                }                
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
            public void DisplayStudents(int SortByVal)
            {
                m_displayStudents.Display(SortByVal);
            }
        }
    }// DisplaySystemData    
}// Namespace Project.App.Code
