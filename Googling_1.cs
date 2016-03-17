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
    public class Googling_1
    {
        IWebDriver driver;

        #region Set up
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        #endregion

        #region Exit
        public void Exit()
        {
            driver.Quit();
        }
        #endregion

        #region Test execution
        public TestResult RunTest()
        {
            string url = "http://google.com";
            string nameElement = "q";
            try
            {
                driver.Navigate().GoToUrl(url);
                IWebElement queryBox = driver.FindElement(By.Name(nameElement));
                queryBox.SendKeys("hello world");
                queryBox.Submit();

                return new TestResult() { Message = "Test successfully completed", IssueId = 0 };
            }
            catch
            {
                return new TestResult() { Message = "Could not find element " + nameElement + " on this page", IssueId = 1 };
            }

        }
        #endregion

        #region Send result to testlink. RunTest calls here.
        public void TestlinkAPISendResult()
        {
            TestResult result = RunTest();
            TestCaseResultStatus status = TestCaseResultStatus.undefined;
            TestLink apiAdapter = new TestLink("33e2581a6ef9393b6b119a5c2d1d95a8", "http://10.91.10.209/lib/api/xmlrpc/v1/xmlrpc.php");
            TestPlan tpList = apiAdapter.getTestPlanByName("GG-Test", "ginger test plan");
            TestCase currentTC = apiAdapter.GetTestCase(apiAdapter.GetTestCaseIDByName("hello")[0].id);
            switch (result.IssueId)
            {
                case 0:
                    status = TestCaseResultStatus.Pass;
                    break;
                case 1:
                    status = TestCaseResultStatus.Fail;
                    break;
                default:
                    status = TestCaseResultStatus.undefined;
                    break;
            }
            apiAdapter.ReportTCResult(currentTC.testcase_id, tpList.id, status, platformId: apiAdapter.GetTestPlanPlatforms(tpList.id)[0].id, overwrite: true, notes: result.Message);

        }
        #endregion
    }
}