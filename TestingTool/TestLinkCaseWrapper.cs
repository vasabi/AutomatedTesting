#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
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
        private String _testSuiteName;
        private MyTestCaseBase _wrappedTestCase;

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

        public TestLink SetAdapter()
        {
            TestLink apiAdapter = new TestLink(_apiKey, _apiUrl);
            return apiAdapter;
        }

        public TestPlan TryConnection()
        {
            TestLink apiAdapter = SetAdapter();
            try
            {
                TestPlan testPlan = apiAdapter.getTestPlanByName(_projectName, _testPlanName);
                return testPlan;
            }
            catch (Exception exeption)
            {
                Console.WriteLine("Exeption message:" + exeption.Message);
                return null;
            }
        }

        public void Run()
        {
            TestLink apiAdapter = SetAdapter();
            TestPlan testPlan = TryConnection();         
            //List<int> tcList = apiAdapter.GetTestCaseIdsForTestSuite(apiAdapter.GetTestSuitesForTestPlan(testPlan.id).First(e => e.name == _testSuiteName).id, true);
            //foreach (int index in tcList)
            //{
            //TestCase currentTC = apiAdapter.GetTestCase(index);
            //}
            var result = _wrappedTestCase.RunTest();
            TestCase currentTC = apiAdapter.GetTestCase(apiAdapter.GetTestCaseIDByName(_testCaseName, _testSuiteName)[0].id);
            Console.WriteLine(String.Format("Result:{0}. Message:{1}", result.Status, result.Message));
            try
            {
                apiAdapter.ReportTCResult(currentTC.testcase_id, testPlan.id, result.Status,
                    platformId: apiAdapter.GetTestPlanPlatforms(testPlan.id).First(e => e.name == _testPlatformName).id,
                    overwrite: true, notes: result.Message);

                Console.Write("{0}", Environment.NewLine);
                Console.WriteLine("Test results successfully send to TestlinkServer");
                Console.Write("{0}", Environment.NewLine);
            }
            catch (Exception exeption)
            {
                Console.Write("{0}", Environment.NewLine);
                Console.WriteLine("Test result can not be saved because TestCase (" + _testCaseName + "), TestSuit ("
                    + _testSuiteName + ") does not exist for current TestPlan (" + _testPlanName
                    + ") or TestPlatform (" + _testPlatformName + "). Please read the exeption message");
                Console.Write("{0}", Environment.NewLine);
                Console.WriteLine("Exeption message:" + exeption.Message);
                Console.Write("{0}", Environment.NewLine);
            }
        }
    }
}