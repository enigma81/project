using System;
using Project.Resources;
using System.Linq;
using System.Globalization;
using System.Reflection;

namespace Project.Code
{
    public sealed class ValidatorClass
    {
        internal interface IValidator { }

        internal class ValidatorMessage
        {
            internal string Message { get; set; }
            internal bool Status { get; set; }
        }

        internal abstract class Validator : IValidator
        {
            internal ValidatorMessage validatorMessage = new ValidatorMessage();

            internal const string errorOperation = "Operation non-existing, please use appropriate operation.";
            internal const string errorName = "You need to insert valid string value.";
            internal const string errorGpa = "You need to insert numerical value.";
        }

        internal class OperationValidator : Validator
        {
            public ValidatorMessage Validate (string operation, FieldInfo[] operationFields)
            {
                if (!String.IsNullOrEmpty(operation))
                {
                    foreach (var field in operationFields)
                    {
                        if (operation == field.GetValue(field).ToString())
                        {
                            validatorMessage.Status = true;
                            return validatorMessage;
                        }
                    }
                }
                validatorMessage.Message = errorOperation;
                validatorMessage.Status = false;
                return validatorMessage;
            }
        }

        internal interface IPersonValidator
        {
            ValidatorMessage ValidateName(string name);
        }

        internal class PersonValidator : Validator, IPersonValidator
        {
            public ValidatorMessage ValidateName(string name)
            {
                if (String.IsNullOrEmpty(name) || !name.All(Char.IsLetter))
                {
                    validatorMessage.Status = false;
                    validatorMessage.Message = errorName;
                }
                else validatorMessage.Status = true;
                return validatorMessage;
            }
        }

        internal class StudentsValidator : Validator, IPersonValidator
        {
            public ValidatorMessage ValidateName(string name)
            {
                if (String.IsNullOrEmpty(name) || !name.All(Char.IsLetter))
                {
                    validatorMessage.Status = false;
                    validatorMessage.Message = errorName;
                }
                else validatorMessage.Status = true;
                return validatorMessage;
            }

            public ValidatorMessage ValidateGpa(string inputGpa)
            {
                float gpa;
                if (float.TryParse(inputGpa, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out gpa))
                {
                    if (gpa >= 1 && gpa <= 5)
                        validatorMessage.Status = true;
                    else
                    {
                        validatorMessage.Status = false;
                        validatorMessage.Message = errorGpa;
                    }
                }
                else
                {
                    validatorMessage.Status = false;
                    validatorMessage.Message = errorGpa;
                }
                return validatorMessage;
            }
        }

        internal class ValidatorFactory
        {
            internal static TValidatorType CreateValidator<TValidatorType>()
                where TValidatorType : IValidator, new()
            {
                return new TValidatorType();
            }
        }
    }
}
