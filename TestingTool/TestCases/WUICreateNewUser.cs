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
    [TestCaseIdentifier("Avalanche-3", "Administration", "Create New User")] //атрибуты, считываемые из csv
    public class WUICreateNewUser : MyTestCaseBase
    {

        #region Test execution
        public override TestResult RunTest()
        {
            string url = "http://10.91.5.35:8082/WebInterfaceApp/";
            try
            {
                Driver.Navigate().GoToUrl(url);
                FindElementByName("j_username").SendKeys("selenium");
                FindElementByName("j_password").SendKeys("poiskitpoiskit");
                FindElementByName("loginButton").Click();
                Wait(2000);
                FindElementById("j_idt13:j_idt23").Click();
                Wait(2000);
                FindElementByLinkText("Управление пользователями").Click();
                String userXpath = "//*[@id=\"administrationForm:administrationTab:users:j_idt70_data\"]/tr[ ./td/span[text()='Admin User'] and  ./td/span[text()='Администратор']]";
                try
                {
                    Wait(2000);
                    IWebElement checkUsers = FindElementByXPath(userXpath);
                    FindElementByXPath(userXpath + "/td[5]/div[2]/a").Click();
                }
                catch (NoSuchElementException)
                {
                }
                Wait(1000);
                FindElementByName("administrationForm:administrationTab:users:j_idt67").Click();
                Wait(1000);
                FindElementByXPath(@"//*[@id=""administrationForm:administrationTab:users:authority""]/div[3]/span").Click();
                FindElementByXPath(@"//*[@id=""administrationForm:administrationTab:users:authority_panel""]/div/ul/li[2]").Click();
                FindElementByName("administrationForm:administrationTab:users:username").SendKeys("Admin User");
                FindElementByName("administrationForm:administrationTab:users:password").SendKeys("poiskitpoiskit");
                FindElementByName("administrationForm:administrationTab:users:accountExpirationDate_input").SendKeys("29.11.2024 00:00:00");
                FindElementByName("administrationForm:administrationTab:users:saveUserAccountButton").Click();
                Wait(1000);
                FindElementById("administrationForm:administrationTab:users:j_idt88").Click();
                Wait(3000);
                IWebElement checkResult = FindElementByXPath(userXpath);
                if (checkResult != null)
                {
                    return TestResult.Success("Test successfully completed");
                }
                else
                {
                    throw new Exception("User was not created");
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