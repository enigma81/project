namespace Project.Code
{
    public abstract class Person
    {
        protected int Id;
        protected string FirstName;
        protected string LastName;

        public abstract int getId();
        public abstract void setId(int id);
        public abstract string getFirstname();
        public abstract void setFirstname(string FirstName);
        public abstract string getLastname();
        public abstract void setLastname(string LastName);

    }
}
