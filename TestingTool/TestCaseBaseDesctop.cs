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
using System.IO;
using System.Reflection;
#endregion

namespace TestingTool
{
    public class TestCaseBaseDesctop
    {
                #region конструктор
        public TestCaseBaseDesctop()
        {

        }
        #endregion

        #region запуск теста
        public virtual TestResult RunTestDesctop()
        {
            return TestResult.Fail("Run test not realized");
        }
        #endregion
    }
}