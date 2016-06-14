namespace Project.Code
{
    public sealed class StudentIdGenerator
    {
        private static readonly StudentIdGenerator instance = new StudentIdGenerator();
        
        public int Id { get; set; }

        private StudentIdGenerator() { Id = 0; }

        public static StudentIdGenerator GetInstance
        {
            get
            {
               return instance;
            }
        }
    }
}
