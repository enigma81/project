using System;

namespace Project.Code
{
    public static class Validator
    {
        public static string error = "";

        public static bool ValidateOperation(string operation)
        {
            foreach (string str in Enum.GetNames(typeof(Operations.AvailableOperations)))
            {
                if (str == operation)
                {
                   return true;
                }
                else
                {
                    continue;
                }
            }
            error = "Operation non-existing, please use appropriate operation.";
            return false;
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
