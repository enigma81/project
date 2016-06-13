namespace Project.Code
{
    public abstract class Person
    {
        private int id;
        private string firstName;
        private string lastName;

        public int Id {
            set { id = value; }
            get { return id; }            
        }

        public string FirstName {
            set{ firstName = value; }
            get { return firstName; }
        }

        public string LastName
        {
            set { lastName = value; }
            get { return lastName; }
        }
    }
}
