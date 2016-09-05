#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Meyn.TestLink;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Microsoft;
using Microsoft.Office;
using Microsoft.Office.Interop;
#endregion

namespace TestingTool
{
    public class TestCaseWrapperWeb:IDisposable
    {
        #region конструктор
        private TestCaseBaseWeb _wrappedTestCase;
        private String _testCaseName;
        private String _testCaseType;

        public TestCaseWrapperWeb(TestCaseBaseWeb wrappedTestCase, String testCaseName, String testCaseType)
        {
            _testCaseType = testCaseType;
            _testCaseName = testCaseName;
            _wrappedTestCase = wrappedTestCase;
        }
        #endregion



        #region вызов методов тесткейса
        public void Run()
        {
            var result = _wrappedTestCase.RunTestWeb();
            Console.WriteLine(String.Format("Result: {0}. Message: {1}", result.Status, result.Message));
        }
        #endregion

        #region назначение web платформ
        public TestCaseWrapperWeb SetPlatform(string platform)
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