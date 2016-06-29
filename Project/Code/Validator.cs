using System;
using System.Linq;
using System.Globalization;
using System.Reflection;
using Project.Resources;
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
        //protected void SetValidatorMessage(ValidatorMessage messageInstance,bool status, [Optional]string error)
        //{
        //    messageInstance.Status = status;
        //    if(error != null)
        //        messageInstance.Message = error;
        //}        
        protected void SetValidatorMessage(ValidatorMessage MessageInstance, bool status)
        {
            MessageInstance.Status = status;
        }
        protected void SetValidatorMessage(ValidatorMessage MessageInstance, bool status, string error)
        {
            MessageInstance.Status = status;
            MessageInstance.Message = error;
        }
    }

    #region Validator child classes
    class OperationValidator : Validator
    {
        ValidatorMessage validatorMessage = new ValidatorMessage();
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
            SetValidatorMessage(validatorMessage, false, ErrorText.ValidatorOperationError);
            
            return validatorMessage;
        }
    }

    class PersonValidator : Validator
    {
        ValidatorMessage validatorMessage = new ValidatorMessage();
        public ValidatorMessage ValidateName(string name)
        {
            if (String.IsNullOrEmpty(name) || !name.All(Char.IsLetter))
                SetValidatorMessage(validatorMessage, false, ErrorText.ValidatorNameError);
            else
                SetValidatorMessage(validatorMessage, true);

            return validatorMessage;
        }
    }
    class StudentsValidator : Validator
    {
        ValidatorMessage validatorMessage = new ValidatorMessage();
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

            SetValidatorMessage(validatorMessage, false, ErrorText.ValidatorGpaError);
            return validatorMessage;
        }
    }
    #endregion
    class ValidatorFactory
    {
        internal static TValidatorType CreateValidator<TValidatorType>()
            where TValidatorType : IValidator, new()
        {
            return new TValidatorType();
        }
    }
}
