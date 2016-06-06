namespace Project.Code
{
    public class Student : Person
    {
        public float GPA { get; set; }

        public override int getId ()
        {
            return this.Id;
        }
        public override void setId(int id)
        {
            this.Id = id;
        }
        public override string getFirstname()
        {
            return this.FirstName; 
        }
        public override void setFirstname(string inputFirstName)
        {
            this.FirstName = inputFirstName;
        }

        public override string getLastname()
        {
            return this.LastName;
        }
        public override void setLastname(string inputLastName)
        {
            this.LastName = inputLastName;
        }
    }
}
