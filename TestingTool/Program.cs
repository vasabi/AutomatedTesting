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
    public class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "33e2581a6ef9393b6b119a5c2d1d95a8";
            var apiUrl = "http://10.91.10.209/lib/api/xmlrpc/v1/xmlrpc.php";
            var chromePlatformName = "Google Chrome";
            var firefoxPlatformName = "Firefox";
            var iePlatformName = "IE"; 


            // Для запуска тестов передаются параметы в класс TestLinkCaseWrapper (new TestclassName.DriverMethodName(), apiKey, apiUrl, testProjectName, testPlanName, testPlatdormName, testCaseName)
            var cases = new List<TestLinkCaseWrapper>() 
            {
               new TestLinkCaseWrapper(new Googling_1().SetupChrome(),apiKey, apiUrl, "GG-Test", "ginger test plan", chromePlatformName, "hello"),
                new TestLinkCaseWrapper(new WUICreateNewUser().SetupChrome(),apiKey, apiUrl, "Avalanche-3", "WUI Testing", chromePlatformName, "Create New User")
            };

            #region RunTests
            foreach (var thisCase in cases)
            {
                thisCase.Run();
            }

            #endregion
        }

      
    }
}