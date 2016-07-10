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
        {}

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

    public class Validator
    {
        private static FieldInfo[] m_operationFields = typeof(Operations).GetFields();
        private static byte m_minNameLength = 2;
        private static byte m_maxNameLength = 30;


        public static ValidatorMessage IsValid(object Sender, object Input)
        {
            switch (Sender.GetType().Name)
            {
                case "OperationScript":
                    return ValidateOperation(Input as String);

                case "StudentScript":
                    switch (Input.GetType().Name)
                    {
                        case "String":
                            return ValidateName(Input as String);

                      //case "Float":

                    }
                    break;
                default:
                    break;
            }

            return null;
        }

        public static ValidatorMessage ValidateGpa(string Gpa)
        {
            float gpa;
            if (float.TryParse(Gpa, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out gpa))
            {
                if (gpa >= 1 && gpa <= 5)
                {
                    return GetValidatorMessage(true);
                }
            }

            return GetValidatorMessage(false, ErrorText.ValidatorGpaError);
        }

        private static ValidatorMessage GetValidatorMessage(bool status, [Optional]string error)
        {
            if (error != null)
                return new ValidatorMessage(status, error);               
            
            return new ValidatorMessage(status);
        }
        
        private static ValidatorMessage ValidateOperation(string Operation)
        {
            if (!String.IsNullOrEmpty(Operation))
            {
                foreach (var field in m_operationFields)
                {
                    if (Operation == field.GetValue(field).ToString())
                    {
                        return GetValidatorMessage(true);
                    }
                }
            }

            return GetValidatorMessage(false, ErrorText.ValidatorOperationError);
        }

        private static ValidatorMessage ValidateName(string Name)
        {
            if ((String.IsNullOrEmpty(Name) || !Name.All(Char.IsLetter)) || (Name.Length < m_minNameLength || Name.Length > m_maxNameLength))
                return GetValidatorMessage(false, ErrorText.ValidatorNameError);
            else
                return GetValidatorMessage(true);
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
