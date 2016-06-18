using System;
using Project.Resources;
using System.Linq;
using System.Globalization;
using System.Reflection;

namespace Project.Code
{
    public class Validator
    {
        ValidationStatus validationStatus = new ValidationStatus();
        
        public ValidationStatus OperationValidator(string operation, FieldInfo[] operationFields)
        {
            if (!String.IsNullOrEmpty(operation))
            {
                foreach (var field in operationFields)
                {
                    if (operation == field.GetValue(field).ToString())
                    {
                        validationStatus.Status = true;
                        return validationStatus;
                    }
                }
                if (operation == Operations.enlist || operation == Operations.display)
                {
                    validationStatus.Status = true;
                    return validationStatus;
                }
            }
            validationStatus.Message = ValidatonMessageText.errorOperation;
            validationStatus.Status = false;
            return validationStatus;
        }

        public ValidationStatus NameValidator(string name)
        {
            if (String.IsNullOrEmpty(name) || !name.All(Char.IsLetter))
            {
                validationStatus.Status = false;
                validationStatus.Message = ValidatonMessageText.errorName;
            }
            else validationStatus.Status = true;
            return validationStatus;
        }

        public ValidationStatus GpaValidator(string inputGpa)
        {
            float gpa;
            if (float.TryParse(inputGpa, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out gpa))
            {
                if (gpa >= 1 && gpa <= 5)
                    validationStatus.Status = true;
                else
                {
                    validationStatus.Status = false;
                    validationStatus.Message = ValidatonMessageText.errorGpa;
                }
            }
            else
            {
                validationStatus.Status = false;
                validationStatus.Message = ValidatonMessageText.errorGpa;
            }
            return validationStatus;
        }

    }
}
