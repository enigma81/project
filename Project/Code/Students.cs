namespace Project.Code
{
    public class Students : Person
    {
        private float gpa;
        
        public float Gpa {
            set { gpa = value; }
            get { return gpa;  }            
        }        
    }
}
