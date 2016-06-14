using System;

namespace Project.Code
{
    public static class Validator
    {
        public static ValidationMessage OperationValidator(string operation)
        {
            var validation = ValidationMessage.GetInstance();

            foreach (string str in Enum.GetNames(typeof(Operations.AvailableOperations)))
            {
                if (str == operation)
                {
                    validation.ValidationSuccess = true;
                    return validation;
                }
            }
            validation.ValidationSuccess = false;
            return validation;
        }

        public static ValidationMessage FirstNameValidator(string firstName)
        {
            var validation = ValidationMessage.GetInstance();
            if (String.IsNullOrEmpty(firstName))
            {
                validation.ValidationSuccess = false;
                return validation;
            }
            validation.ValidationSuccess = true;
            return validation;
        }

        public static ValidationMessage LastNameValidator(string lastName)
        {
            var validation = ValidationMessage.GetInstance();
            if (String.IsNullOrEmpty(lastName))
            {
                validation.ValidationSuccess = false;
                return validation;
            }
            validation.ValidationSuccess = true;
            return validation;
        }
    }
}
