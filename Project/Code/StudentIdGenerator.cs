namespace Project.Code
{
    public sealed class StudentIdGenerator
    {
        private static readonly StudentIdGenerator instance = new StudentIdGenerator();
        private int id;

        public int Id
        {
            get
            {
                setId();
                return id;
            }
        }

        private void setId() { id++; }

        private StudentIdGenerator() { id = 0; }

        public static StudentIdGenerator GetInstance
        {
            get
            {
               return instance;
            }
        }
    }
}
