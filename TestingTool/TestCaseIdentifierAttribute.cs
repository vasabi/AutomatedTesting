#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TestingTool
{
    #region атрибуты классов тесткейсов
    public class TestCaseIdentifierAttribute:Attribute
    {
        public TestCaseIdentifierAttribute(String testCaseName, String testCaseType)
        {
            TestCaseName = testCaseName;
            TestCaseType = testCaseType;
        }

        public string TestCaseName { get; set; }

        public string TestCaseType { get; set; }
    }
    #endregion
}
