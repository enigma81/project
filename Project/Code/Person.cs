using System;

namespace Project.Code
{
    public abstract class Person
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion
    }

    abstract class NewPerson
    {
        #region Fields
        protected string consoleInput;
        protected ValidatorMessage validation;
        PersonValidator personValidator = ValidatorFactory.CreateValidator<PersonValidator>();
        #endregion

        #region NewPerson functions
        public string AddFirstName()
        {
            do
            {
                ValidateInput("First Name");

            } while (validation.Status != true);

            return consoleInput;
        }
        public string AddLastName()
        {
            do
            {
                ValidateInput("Last Name");

            } while (validation.Status != true);

            return consoleInput;
        }

        void ValidateInput(string input)
        {
            Console.Write("{0}: ", input);
            consoleInput = Console.ReadLine();
            validation = personValidator.ValidateName(consoleInput);
            
            if (!validation.Status)
                Console.WriteLine(validation.Message);
        }
        #endregion
    }
}
