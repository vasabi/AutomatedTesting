#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CookComputing.XmlRpc;
using Meyn.TestLink.NUnitExport;
using Meyn.TestLink;
#endregion

namespace TestingTool
{
    public class TestCaseWrapper:IDisposable
    {
        #region конструктор
        private TestCaseBase _wrappedTestCase;
        private String _testCaseName;
        private String _testCaseType;

        public TestCaseWrapper(TestCaseBase wrappedTestCase, String testCaseName, String testCaseType)
        {
            _testCaseType = testCaseType;
            _testCaseName = testCaseName;
            _wrappedTestCase = wrappedTestCase;
        }
        #endregion



        #region вызов методов тесткейса
        public void Run()
        {
            var result = _wrappedTestCase.RunTest();
        }
        #endregion

        #region назначение web платформ
        public TestCaseWrapper SetPlatform(string platform)
        {
            _wrappedTestCase.SetupDriver(platform);
            return this;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _wrappedTestCase.Dispose();
        }
        #endregion
    }
}