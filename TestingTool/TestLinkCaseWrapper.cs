#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CookComputing.XmlRpc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Meyn.TestLink.NUnitExport;
using Meyn.TestLink;
using Gallio;
using Gallio.Framework;
using Gallio.Runtime;
#endregion

namespace TestingTool
{
    public class TestLinkCaseWrapper
    {
        private String _apiKey;
        private String _apiUrl;
        private String _projectName;
        private String _testPlanName;
        private String _testPlatformName;
        private String _testCaseName;
        private MyTestCaseBase _wrappedTestCase;

        public TestLinkCaseWrapper( MyTestCaseBase wrappedTestCase, String apiKey, String apiUrl, String projectName, String testPlanName, String testPlatformName, String testCaseName)
        {
            _apiKey = apiKey;
            _apiUrl = apiUrl;
            _projectName = projectName;
            _testPlanName = testPlanName;
            _testPlatformName = testPlatformName;
            _testCaseName = testCaseName;
            _wrappedTestCase = wrappedTestCase;
        }

        public void Run()
        {
            var result = _wrappedTestCase.RunTest();
            Console.WriteLine(String.Format("Result:{0}. Message:{1}", result.Status, result.Message));
            TestLink apiAdapter = new TestLink(_apiKey, _apiUrl);
            TestPlan testPlan = apiAdapter.getTestPlanByName(_projectName, _testPlanName);
            TestCase currentTC = apiAdapter.GetTestCase(apiAdapter.GetTestCaseIDByName(_testCaseName)[0].id);
            apiAdapter.ReportTCResult(currentTC.testcase_id, testPlan.id, result.Status,
            platformId: apiAdapter.GetTestPlanPlatforms(testPlan.id).First(e => e.name == _testPlatformName).id, overwrite: true, notes: result.Message);
        }
    }
}