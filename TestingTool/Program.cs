#region using
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
    public class Program
    {
        static void Main(string[] args)
        {
            String apiUrl = ConfigurationManager.AppSettings["testLinkUrl"];
            String apiKey = ConfigurationManager.AppSettings["testLinkApiKey"];

            var platforms = new List<String>()
            {
                "Google Chrome",
                "Firefox",
                "IE"
            };

            // Для запуска тестов передаются параметы в класс TestLinkCaseWrapper (new TestclassName.DriverMethodName(), apiKey, apiUrl, testProjectName, testPlanName, testPlatdormName, testCaseName)
            foreach (var platform in platforms)
            {
                new TestLinkCaseWrapper(new Googling_1().SetupDriver(platform), apiKey, apiUrl, platform, "GG-Test", "ginger test plan", "googling", "hello").Run();
//                new TestLinkCaseWrapper(new WUICreateNewUser().SetupDriver(platform), apiKey, apiUrl, platform, "Avalanche-3", "WUI Testing", "Administration", "Create New User").Run();
            }

            ConsoleKeyInfo OnExit;
            do
            {
                Console.WriteLine("Press Esc to exit");
                OnExit = Console.ReadKey();
            }
            while (OnExit.Key != ConsoleKey.Escape);
        }
    }
}