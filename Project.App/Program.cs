using System;
using Project.Code;
using System.Reflection;
using Project.Resources;
using Project.App.Code;

namespace Project.App
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool exit = false;
            StudentScript m_studentScript = new StudentScript();
            OperationScript m_operationScript = new OperationScript();
                        
            // Loop program until exit is set to true
            while (!exit)
            {

                // Switch SelectOperation against available operations
                switch (m_operationScript.SelectOperation())
                {
                    case Operations.enlist:
                        m_studentScript.EnlistStudent();
                        break;
                    case Operations.display:
                        m_studentScript.DisplayStudents();
                        break;
                    case Operations.exit :
                        exit = true;
                        break;
                }
            }
        }        
    }//Program
}//Namespace Project.App

