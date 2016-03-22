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
using System.Reflection;
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

            //var asseblyPath = "";
            //var assembly = Assembly.LoadFile(asseblyPath);
            var caseId = "Гуглование";
            var assembly = Assembly.GetEntryAssembly();
            var caseType = assembly.GetTypes().First(t => {
                var attr = t.GetCustomAttribute<TestCaseIdentifierAttribute>();
                if (attr != null)
                    return attr.Id == caseId;
                return false;
            });


            var caseObject = (MyTestCaseBase)Activator.CreateInstance(caseType);
            foreach (var platform in platforms)
            {

                var tests = new List<TestLinkCaseWrapper>()
                {
                    new TestLinkCaseWrapper(caseObject, apiKey, apiUrl, platform, "GG-Test", "ginger test plan", "googling", "hello"),
                    //new TestLinkCaseWrapper(new Googling_1(), apiKey, apiUrl, platform, "GG-Test", "ginger test plan", "googling", "hello"),
                    new TestLinkCaseWrapper(new WUICreateNewUser(), apiKey, apiUrl, platform, "Avalanche-3", "WUI Testing", "Administration", "Create New User")
                };
                foreach (var test in tests)
                {
                    try
                    {
                        using (test)
                        {
                            test.SetPlatform(platform).Run();
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Exception message:" + exception.Message);
                    }
                }
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