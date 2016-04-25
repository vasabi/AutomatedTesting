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
    class WUIHelper
    {
        public static void LoginToServer(MyTestCaseBase testCase)
        {
            String testServer = ConfigurationManager.AppSettings["testServer"];
            string homeUrl = "http://" + testServer +"/";
            string dstUrl = "http://" + testServer + "/Search";
            testCase.GoToUrl(homeUrl);
            testCase.FindElementByXPath(@"//*[@id=""Login""]").SendKeys("selenium user");
            testCase.FindElementByXPath(@"//*[@id=""Password""]").SendKeys("poiskit");
            testCase.FindElementByXPath(@"//*[@id=""wrapper""]/div[2]/section/form/div[5]/div/button").Click();
            try
            {
                testCase.WaitBool(() => testCase.GetUrl().Equals(dstUrl), TimeSpan.FromSeconds(5));
            }
            catch (WebDriverTimeoutException exception)
            {
                throw new WebDriverTimeoutException("Не удалось перейти на страницу поиска. " + exception.Message);
            }
        }
    }
}
