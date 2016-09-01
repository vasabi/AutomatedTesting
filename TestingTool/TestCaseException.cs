using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool
{
    class TestCaseException : Exception
    {
        private string p;

        public TestCaseException(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
    }
}
