using System;
using System.Globalization;

namespace Project.Code
{
    public static class Validator
    {
        static ValidationMessage validation = new ValidationMessage();
        
        public static ValidationMessage OperationValidator(string operation)
        {
            if (!String.IsNullOrEmpty(operation))
            {
                foreach (string str in Enum.GetNames(typeof(Operations.AvailableOperations)))
                {
                    if (str == operation)
                    {
                        validation.Status = true;
                        return validation;
                    }
                }
            }
            validation.Message = ValidatorMessageResource.errorOperation;
            validation.Status = false;
            return validation;
        }

        public static ValidationMessage FirstNameValidator(string firstName)
        {
            float testName;
            if (String.IsNullOrEmpty(firstName) || float.TryParse(firstName, out testName))
            {
                validation.Status = false;
                validation.Message = ValidatorMessageResource.errorFirstName;
            }
            else validation.Status = true;
            return validation;
        }

        public static ValidationMessage LastNameValidator(string lastName)
        {
            float testName;
            if (String.IsNullOrEmpty(lastName) || float.TryParse(lastName, out testName))
            {
                validation.Status = false;
                validation.Message = ValidatorMessageResource.errorLastName;
            }
            else validation.Status = true;
            return validation;
        }

        public static ValidationMessage GpaValidator(string inputGpa)
        {
            float gpa;
            if(float.TryParse(inputGpa,NumberStyles.Number,CultureInfo.InvariantCulture.NumberFormat,out gpa))
            {
                if (gpa >= 1 && gpa <= 5)
                    validation.Status = true;
                else
                {
                    validation.Status = false;
                    validation.Message = ValidatorMessageResource.errorGpa;
                }
            }
            else
            {
                validation.Status = false;
                validation.Message = ValidatorMessageResource.errorGpa;
            }           
            return validation;
        }

        private class ValidatorMessageResource
        {
            public const string errorOperation = "Operation non-existing, please use appropriate operation.";
            public const string errorFirstName = "You need to insert valid string value for FirstName.";
            public const string errorLastName = "You need to insert valid string value for LastName.";
            public const string errorGpa = "You need to insert numerical value.";
        }
    }
}
