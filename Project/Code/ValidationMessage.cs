using System.Collections.Generic;

namespace Project.Code
{
    public class ValidationMessage
    {
        private static ValidationMessage _instance;
        Dictionary<string, string> errors = new Dictionary<string, string>();

        private ValidationMessage()
        {
            errors.Add("Operation", "Operation non-existing, please use appropriate operation.");
            errors.Add("FirstName", "You need to insert valid string value for FirstName.");
            errors.Add("LastName", "You need to insert valid string value for LastName.");
            errors.Add("Gpa", "You need to insert numerical value.");
        }

        public bool ValidationSuccess { get; set; }
        public string GetError(string error) { return errors [error]; }

        public static ValidationMessage GetInstance()
        {
            if(_instance == null) { _instance = new ValidationMessage(); }

            return _instance;
        }
    }
}
