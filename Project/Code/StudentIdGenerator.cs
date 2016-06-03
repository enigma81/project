using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
