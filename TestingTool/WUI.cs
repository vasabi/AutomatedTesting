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
    public class WUICreateNewUser
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

        #region Wait
        public void Wait(Int32 value)
        {
            System.Threading.Thread.Sleep(value);
        }
        #endregion

        #region FindElementByName
        public IWebElement FindElementByName(String value)
        {
            IWebElement elementOnPage = driver.FindElement(By.Name(value));
            return elementOnPage;
        }
        #endregion

        #region FindElementById
        public IWebElement FindElementById(String value)
        {
            IWebElement elementOnPage = driver.FindElement(By.Id(value));
            return elementOnPage;
        }
        #endregion

        #region FindElementByLinkText
        public IWebElement FindElementByLinkText(String value)
        {
            IWebElement elementOnPage = driver.FindElement(By.LinkText(value));
            return elementOnPage;
        }
        #endregion

        #region SelectElement
        public SelectElement SelectElementBySmth(IWebElement value)
        {
            SelectElement select = new SelectElement(value);
            var options = select.Options;
            return select;
        }
        #endregion

        #region Test execution
        public TestResult RunTest()
        {
            string url = "http://10.91.5.35:8082/WebInterfaceApp/";
            try
            {
                driver.Navigate().GoToUrl(url);
                FindElementByName("j_username").SendKeys("selenium");
                FindElementByName("j_password").SendKeys("poiskitpoiskit");
                FindElementByName("loginButton").Click();
                Wait(2000);
                FindElementById("j_idt13:j_idt23").Click();
                Wait(2000);
                FindElementByLinkText("Управление пользователями").Click();
                Wait(1000);
                FindElementByName("administrationForm:administrationTab:users:j_idt67").Click();
                Wait(1000);
                FindElementByName("administrationForm:administrationTab:users:username").SendKeys("NewUser");
                FindElementByName("administrationForm:administrationTab:users:password").SendKeys("poiskitpoiskit");
                SelectElementBySmth(FindElementByName("administrationForm:administrationTab:users:authority_input")).SelectByText("Администратор");
                FindElementByLinkText("Администратор").Click();
                FindElementByName("administrationForm:administrationTab:users:accountExpirationDate_input").SendKeys("29.11.2024 00:00:00");
                FindElementByName("administrationForm:administrationTab:users:saveUserAccountButton").Click();
                Wait(3000);

 //               FindElementByLinkText("NewUser");

                return new TestResult() { Message = "Test successfully completed", IssueId = 0 };
            }
            catch
            {
                return new TestResult() { Message = "Could not find element " + "" + " on this page", IssueId = 1 };
            }

        }
        #endregion

        #region Send result to testlink. RunTest calls here.
        public void TestlinkAPISendResult()
        {
            TestResult result = RunTest();
            //TestCaseResultStatus status = TestCaseResultStatus.undefined;
            //TestLink apiAdapter = new TestLink("33e2581a6ef9393b6b119a5c2d1d95a8", "http://10.91.10.209/lib/api/xmlrpc/v1/xmlrpc.php");
            //TestPlan tpList = apiAdapter.getTestPlanByName("GG-Test", "ginger test plan");
            //TestCase currentTC = apiAdapter.GetTestCase(apiAdapter.GetTestCaseIDByName("hello")[0].id);
            //switch (result.IssueId)
            //{
            //    case 0:
            //        status = TestCaseResultStatus.Pass;
            //        break;
            //    case 1:
            //        status = TestCaseResultStatus.Fail;
            //        break;
            //    default:
            //        status = TestCaseResultStatus.undefined;
            //        break;
            //}
            //apiAdapter.ReportTCResult(currentTC.testcase_id, tpList.id, status, platformId: apiAdapter.GetTestPlanPlatforms(tpList.id)[0].id, overwrite: true, notes: result.Message);

        }
        #endregion
    }

}