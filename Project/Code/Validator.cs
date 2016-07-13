using System;
using System.Linq;
using System.Globalization;
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
        private byte m_minFirstNameLength = 2;
        private byte m_maxFirstNameLength = 30;
        private byte m_minLastNameLength = 2;
        private byte m_maxLastNameLength = 30;
                
        public ValidatorMessage ValidateOperation(string InputOperation)
        {
            if (Enum.IsDefined(typeof(Operation.AvailableOperations), InputOperation))
                return GetValidatorMessage(true);            

            return GetValidatorMessage(false, ErrorText.ValidatorOperationError);
        }

        public ValidatorMessage ValidateFirstName(string FirstName)
        {
            if (String.IsNullOrEmpty(FirstName) || !FirstName.All(Char.IsLetter) || FirstName.Length < m_minFirstNameLength || FirstName.Length > m_maxFirstNameLength)
                return GetValidatorMessage(false, ErrorText.ValidatorNameError);
            else
                return GetValidatorMessage(true);
        }

        public ValidatorMessage ValidateLastName(string LastName)
        {
            if (String.IsNullOrEmpty(LastName) || !LastName.All(Char.IsLetter) || LastName.Length < m_minLastNameLength || LastName.Length > m_maxLastNameLength)
                return GetValidatorMessage(false, ErrorText.ValidatorNameError);
            else
                return GetValidatorMessage(true);
        }

        public ValidatorMessage ValidateGpa(string Gpa)
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

        private ValidatorMessage GetValidatorMessage(bool status, [Optional]string error)
        {
            if (error != null)
                return new ValidatorMessage(status, error);

            return new ValidatorMessage(status);
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
