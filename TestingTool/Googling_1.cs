﻿#region using
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
    public class Googling_1 : MyTestCaseBase
    {
        
        #region Test execution
        public override TestResult RunTest()
        {
            string url = "http://google.com";
            string nameElement = "q";
            try
            {
                Driver.Navigate().GoToUrl(url);
                IWebElement queryBox = Driver.FindElement(By.Name(nameElement));
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