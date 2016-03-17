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
    public class Googling_1 : MyTestCaseBase
    {
        #region Test execution
        public override TestResult RunTest()
        {
            SetupChrome();
            string url = "http://google.com";
            string nameElement = "q";
            try
            {
                driver.Navigate().GoToUrl(url);
                IWebElement queryBox = driver.FindElement(By.Name(nameElement));
                queryBox.SendKeys("hello world");
                queryBox.Submit();

                return TestResult.Success("Test successfully completed");
            }
            catch
            {
                return TestResult.Fail("Could not find element " + nameElement + " on this page");
            }
            finally
            {
                Exit();
            }
        }
        #endregion
    }
}