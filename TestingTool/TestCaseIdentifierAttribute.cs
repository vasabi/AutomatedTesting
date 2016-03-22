using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool
{
    public class TestCaseIdentifierAttribute:Attribute
    {
        public TestCaseIdentifierAttribute(String id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
