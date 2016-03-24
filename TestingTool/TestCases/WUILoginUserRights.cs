#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
#endregion

namespace TestingTool
{
    [TestCaseIdentifier("Avalanche-3", "Administration", "Login user rights")] //атрибуты, считываемые из csv
    public class WUILoginUserRights : MyTestCaseBase
    {
        #region Test execution
        public override TestResult RunTest()
        {
            string url = "http://10.91.5.35:8082/WebInterfaceApp/";
            try
            {
                Driver.Navigate().GoToUrl(url);
                FindElementByName("j_username").SendKeys("selenium user");
                FindElementByName("j_password").SendKeys("poiskit");
                FindElementByName("loginButton").Click();
                WaitOverlay(() => FindElementByClassName("blockUI blockOverlay ui-widget-overlay"));
                try
                {
                    FindElementByLinkText("Администрирование");
                    return TestResult.Fail("Test failed. Message: User with user rights can administrate system");                    
                }
                catch 
                {
                    return TestResult.Success("Test successfully completed");
                }
            }
            catch (Exception exception)
            {
                return TestResult.Fail("Test failed. Message:" + exception.Message);
            }
            finally
            {               
            }
        }
        #endregion
    }
}