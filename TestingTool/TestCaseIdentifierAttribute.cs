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
        public TestCaseIdentifierAttribute(String projectName, 
            String testSuiteName, String testCaseName)
        {
            ProjectName = projectName;
            TestSuiteName = testSuiteName;
            TestCaseName = testCaseName;
        }

        public string ProjectName { get; set; }

        public string TestSuiteName { get; set; }

        public string TestCaseName { get; set; }
    }
    #endregion
}
