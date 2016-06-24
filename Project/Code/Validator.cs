using System;
using System.Linq;
using System.Globalization;
using System.Reflection;
//using System.Runtime.InteropServices;

namespace Project.Code
{
    interface IValidator { }

    class ValidatorMessage
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }

    abstract class Validator : IValidator
    {
        ValidatorMessage validatorMessage;
        //protected void SetValidatorMessage(ValidatorMessage messageInstance,bool status, [Optional]string error)
        //{
        //    validatorMessage.Status = status;
        //    if(error != null)
        //        validatorMessage.Message = error;
        //}
        protected void SetValidatorMessage(ValidatorMessage messageInstance, bool status)
        {
            messageInstance.Status = status;
        }
        protected void SetValidatorMessage(ValidatorMessage messageInstance, bool status, string error)
        {
            SetValidatorMessage(messageInstance, status);
            if (error != null)
                messageInstance.Message = error;
        }
    }

    class OperationValidator : Validator
    {
        ValidatorMessage validatorMessage = new ValidatorMessage();
        const string OperationError = "Operation non-existing, please use appropriate operation.";

        public ValidatorMessage ValidateOperation(string operation, FieldInfo[] operationFields)
        {
            if (!String.IsNullOrEmpty(operation))
            {
                foreach (var field in operationFields)
                {
                    if (operation == field.GetValue(field).ToString())
                    {
                        SetValidatorMessage(validatorMessage, true);
                        return validatorMessage;
                    }
                }
            }
            SetValidatorMessage(validatorMessage, false, OperationError);
            return validatorMessage;
        }
    }

    class StudentsValidator : Validator
    {
        const string NameError = "You need to insert valid string value.";
        const string GpaError = "You need to insert numerical value.";
        ValidatorMessage validatorMessage = new ValidatorMessage();
        public ValidatorMessage ValidateName(string name)
        {
            if (String.IsNullOrEmpty(name) || !name.All(Char.IsLetter))
                SetValidatorMessage(validatorMessage, false, NameError);
            else
                SetValidatorMessage(validatorMessage, true);

            return validatorMessage;
        }

        public ValidatorMessage ValidateGpa(string inputGpa)
        {
            float gpa;

            if (float.TryParse(inputGpa, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out gpa))
            {
                if (gpa >= 1 && gpa <= 5)
                {
                    SetValidatorMessage(validatorMessage, true);
                    return validatorMessage;
                }
            }

            SetValidatorMessage(validatorMessage, false, GpaError);
            return validatorMessage;
        }
    }

    class ValidatorFactory
    {
        internal static TValidatorType CreateValidator<TValidatorType>()
            where TValidatorType : IValidator, new()
        {
            return new TValidatorType();
        }
    }
}
