namespace Project.Code
{
    public class StudentScript
    {
        private Student m_student;          

        public StudentScript()
        {
            m_student = new Student();
        }

        public void SetFirstName(string NameVal)
        {
            m_student.FirstName = NameVal;
        }

        public void SetLastName(string NameVal)
        {
            m_student.LastName = NameVal;
        }
        public void SetGpa(float GpaVal)
        {
            m_student.Gpa = GpaVal;
        }

        public void SetId()
        {
            m_student.Id = StudentIdGenerator.GetInstance.GenerateId();
        }

        public void EnlistStudent()
        {
            // Enlist student
        }
    }
}
