using System;

namespace Project.Code
{
    public static class Validator
    {
        public static string error = "";

        public static bool ValidateOperation(string operation)
        {

           if (operation == Operations.enlist || operation == Operations.display)
            {
                return true;
            }
            else
            {
                error = "Operation non-existing, please use appropriate operation.";
                return false;
            }
        }

        public static bool ValidateName(string name)
        {
           
            if (name != "" && name != null) return true;
            else
            {
                error = "You need to insert value.";
                return false;
            }
        }        
    }
}
