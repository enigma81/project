namespace Project.Code
{
    public class Students : Person
    {
        // Person implementation
        override public int Id { get; set; }
        override public string FirstName { get; set; }
        override public string LastName { get; set; }
        
        public float Gpa { get; set; }
    }
}
