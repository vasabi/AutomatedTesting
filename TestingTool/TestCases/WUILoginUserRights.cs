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

namespace TestingTool.TestCases
{
    [TestCaseIdentifier("Avalanche-3", "Administration", "Login user rights")] //атрибуты, считываемые из csv
    public class WUILoginUserRights : MyTestCaseBase
    {
        #region Test execution
        public override TestResult RunTest()
        {
            string homeUrl = "http://10.91.5.3:8080/";
            string dstUrl = "http://10.91.5.3:8080/Search";
            try
            {
                Driver.Navigate().GoToUrl(homeUrl);
                FindElementByXPath(@"//*[@id=""Login""]").SendKeys("selenium user");
                FindElementByXPath(@"//*[@id=""Password""]").SendKeys("poiskit");
                FindElementByXPath(@"//*[@id=""wrapper""]/div[2]/section/form/div[5]/div/button").Click();
                try
                {
                    WaitBool(() => Driver.Url.Equals(dstUrl), TimeSpan.FromSeconds(5));
                }
                catch (WebDriverTimeoutException exception)
                {
                    return TestResult.Fail("Не удалось перейти на страницу поиска. " + exception.Message);
                }
                    return TestResult.Success("Test successfully completed");
            }
            catch (Exception exception)
            {
                return TestResult.Fail("Test failed. Message: " + exception.Message);
            }
            finally
            {               
            }
        }
        #endregion
    }
}