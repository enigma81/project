using Project.Resources;
using Project.App.Code;

namespace Project.App
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool exit = false;
            StudentScript studentScript = new StudentScript();
            OperationScript operationScript = new OperationScript();
                        
            // Loop program until exit is set to true
            while (!exit)
            {

                // Switch SelectOperation against available operations
                switch (operationScript.SelectOperation())
                {
                    case Operations.enlist:
                        studentScript.EnlistStudent();
                        break;
                    case Operations.display:
                        studentScript.DisplayStudents();
                        break;
                    case Operations.exit :
                        exit = true;
                        break;
                }
            }
        }        
    }//Program
}//Namespace Project.App

