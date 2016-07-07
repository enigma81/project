namespace Project.Code
{
    public sealed class StudentIdGenerator
    {
        private static readonly StudentIdGenerator _instance = new StudentIdGenerator();
        private int _id;

        private StudentIdGenerator() { _id = 0; }

        public static StudentIdGenerator GetInstance
        {
            get
            {
                return _instance;
            }
        }

        public int GenerateId()
        {
            _id++;
            return _id;
        }
    }
}
