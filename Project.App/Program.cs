using System;
using Project.Code;
using Project.Resources;


namespace Project.App
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool exit = false;
            OperationController operationController = new OperationController();
            
            while (!exit)
            {
                switch (operationController.SelectOperation())
                {
                    case Operations.enlist:
                        operationController.AddNewStudent();
                        break;
                    case Operations.display:
                        operationController.DisplayStudents();
                        break;
                    case Operations.exit:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

