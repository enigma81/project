namespace Project.Code
{
    public sealed class StudentIdGenerator
    {
        private static readonly StudentIdGenerator instance = new StudentIdGenerator();
        public int Id;

        private StudentIdGenerator() { Id = 0; }

        public static StudentIdGenerator getInstance
        {
            get
            {
                instance.Id++;
                return instance;
            }
        }
    }
}
