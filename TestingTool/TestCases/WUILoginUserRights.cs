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
    [TestCaseIdentifier("Avalanche-3", "Administration")] //атрибуты, считываемые из csv
    public class WUILoginUserRights : TestCaseBase
    {
        #region Test execution
        public override TestResult RunTest()
        {
            try
            {
                WUIHelper.LoginToServer(this);
                return TestResult.Success("Test successfully completed");
            }
            catch (TestCaseException exception)
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