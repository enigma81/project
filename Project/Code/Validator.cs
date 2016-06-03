using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public static class Validator
    {
        public static string error = "";

        public static bool ValidateOperation(string operation)
        {

           if (operation == Operations.O_enlist || operation == Operations.O_display)
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
            if (name != "") return true;
            else
            {
                error = "You need to insert value.";
                return false;
            }
        }
    }
}
