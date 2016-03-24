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
    public class TestLinkCaseWrapper:IDisposable
    {
        #region конструктор
        private String _apiKey;
        private String _apiUrl;
        private String _projectName;
        private String _testPlanName;
        private String _testPlatformName;
        private String _testCaseName;
        private String _testSuiteName;
        private MyTestCaseBase _wrappedTestCase;
        private TestLink _apiAdapter;
        private TestPlan _testPlan;

        public TestLinkCaseWrapper(MyTestCaseBase wrappedTestCase, String apiKey,
            String apiUrl, String testPlatformName, String projectName, String testPlanName,
            String testSuiteName, String testCaseName)
        {
            _apiKey = apiKey;
            _apiUrl = apiUrl;
            _projectName = projectName;
            _testPlanName = testPlanName;
            _testPlatformName = testPlatformName;
            _testCaseName = testCaseName;
            _testSuiteName = testSuiteName;
            _wrappedTestCase = wrappedTestCase;
        }
        #endregion

        #region применение параметров для работы с testLink api
        public void SetAdapter()
        {
            _apiAdapter = new TestLink(_apiKey, _apiUrl);
        }
        #endregion

        #region применение параметров тестпроекта, тестплана / проверка доступности сервера / проверка девкея
        public TestPlan SetPlan()
        {
            try
            {
                _testPlan = _apiAdapter.getTestPlanByName(_projectName, _testPlanName);
                return _testPlan;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region запись результатов теста в testlink
        public void Run()
        {
            SetAdapter();
            SetPlan();         
            var result = _wrappedTestCase.RunTest();
            TestCase currentTC = _apiAdapter.GetTestCase(_apiAdapter.GetTestCaseIDByName(_testCaseName, _testSuiteName)[0].id);
            Console.WriteLine(String.Format("Result:{0}. Message:{1}", result.Status, result.Message));
            try
            {
                _apiAdapter.ReportTCResult(currentTC.testcase_id, _testPlan.id, result.Status,
                    platformId: _apiAdapter.GetTestPlanPlatforms(_testPlan.id).First(e => e.name == _testPlatformName).id,
                    overwrite: true, notes: result.Message);

                Console.WriteLine("Test results successfully send to TestlinkServer");
            }
            catch (Exception exeption)
            {
                Console.WriteLine("Test result can not be saved because TestCase (" + _testCaseName + "), TestSuit ("
                    + _testSuiteName + ") does not exist for current TestPlan (" + _testPlanName
                    + ") or TestPlatform (" + _testPlatformName + ")." + exeption.Message);
            }
        }
        #endregion

        #region назначение платформ
        public TestLinkCaseWrapper SetPlatform(string platform)
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