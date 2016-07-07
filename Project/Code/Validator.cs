using System;
using System.Linq;
using System.Globalization;
using System.Reflection;
using Project.Resources;
using System.Runtime.InteropServices;

namespace Project.Code
{
    interface IValidator { }

    public class ValidatorMessage
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public ValidatorMessage()
        { }

        public ValidatorMessage(bool Status)
        {
            this.Status = Status;
        }

        public ValidatorMessage(bool Status, string Error)
        {
            this.Status = Status;
            Message = Error;
        }
    }

    public class Validator : IValidator
    {
        private ValidatorMessage GetValidatorMessage(bool status, [Optional]string error)
        {
            if (error != null)
                return new ValidatorMessage(status, error);               

            return new ValidatorMessage(status);
        }

        public ValidatorMessage ValidateOperation(string operation, FieldInfo[] operationFields)
        {
            if (!String.IsNullOrEmpty(operation))
            {
                foreach (var field in operationFields)
                {
                    if (operation == field.GetValue(field).ToString())
                    {
                        return GetValidatorMessage(true);
                    }
                }
            }

            return GetValidatorMessage(false, ErrorText.ValidatorOperationError);
        }

        public ValidatorMessage ValidateName(string name)
        {
            if (String.IsNullOrEmpty(name) || !name.All(Char.IsLetter))
                return GetValidatorMessage(false, ErrorText.ValidatorNameError);
            else
                return GetValidatorMessage(true);
        }

        public ValidatorMessage ValidateGpa(string inputGpa)
        {
            float gpa;

            if (float.TryParse(inputGpa, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out gpa))
            {
                if (gpa >= 1 && gpa <= 5)
                {
                    return GetValidatorMessage(true);
                }
            }

            return GetValidatorMessage(false, ErrorText.ValidatorGpaError);
        }
    }
    
    public class ValidatorFactory
    {
        internal static TValidatorType CreateValidator<TValidatorType>()
            where TValidatorType : IValidator, new()
        {
            return new TValidatorType();
        }
    }
}
