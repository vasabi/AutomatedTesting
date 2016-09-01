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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Support.Events;
using Selenium.Automation.Framework.Constants;
using Selenium.Automation.Framework.Factories;
using Selenium.Internal.SeleniumEmulation;
#endregion

namespace TestingTool
{
    [TestCaseIdentifier("g", "web")] //атрибуты, считываемые из csv
    public class Googling_1 : TestCaseBase
    {
        #region Test execution
        public override TestResult RunTest()
        {
            string url = "https://mail.ru/";
            string login = "vasabi-jaj@mail.ru";
            string password = "Vesserbroner1";
            string mailTo = "i.aleshin@itgrp.ru";

            try
            {
                Driver.Navigate().GoToUrl(url);
                if (FindElementByXPath(@"//*[@id=""mailbox-auth-login""]").GetAttribute("value") != "" && FindElementByXPath(@"//*[@id=""mailbox__password""]").GetAttribute("value") != "")
                {
                    FindElementByXPath(@"//*[@id=""mailbox__auth__button""]").Click();
                }
                FindElementByXPath(@"//*[@id=""mailbox__login""]").SendKeys(login);
                FindElementByXPath(@"//*[@id=""mailbox__password""]").SendKeys(password);
                FindElementByXPath(@"//*[@id=""mailbox__auth__button""]").Click();

                WaitAndClick(() => FindElementByXPath(@"//*[@id=""b-toolbar__left""]/div/div/div[2]/div/a/span"));

                
                //try
                //{
                //    FindElementByXPath(@"//*[@id=""compose__header__content""]/div[3]/div[2]/div[1]/textarea[2]");
                //    return true;
                //}
                //catch
                //{

                //}

                    WaitAndClick(() => FindElementByXPath(@"//*[@id=""dropdown-select-fields""]/div[1]"));
                    FindElementByXPath(@"//*[@id=""dropdown-select-fields""]/div[2]/div[1]/span/span").Click();
                    FindElementByXPath(@"//*[@id=""compose__header__content""]/div[4]/div[2]/div[1]/textarea[2]");
                    WaitAndClick(() => FindElementByXPath(@"//*[@id=""dropdown-select-fields""]/div[1]"));
                    FindElementByXPath(@"//*[@id=""compose__header__content""]/div[4]/div[2]/div[1]/textarea[2]").Click();

                


                //String userXpath = "//*[@id=\"administrationForm:administrationTab:users:j_idt70_data\"]/tr[ ./td/span[text()='Admin User'] and  ./td/span[text()='Администратор']]";
                //try
                //{
                //    Wait(() => FindElementByXPath(userXpath), TimeSpan.FromSeconds(2));
                //    WaitOverlay(() => FindElementByClassName("blockUI blockOverlay ui-widget-overlay"));
                //    FindElementByXPath(userXpath + "/td[5]/div[2]/a").Click();
                //}
                //catch (WebDriverTimeoutException)
                //{
                //}
                //WaitOverlay(() => FindElementByClassName("blockUI blockOverlay ui-widget-overlay"));
                //WaitAndClick(() => FindElementByName("administrationForm:administrationTab:users:j_idt67"));
                //WaitOverlay(() => FindElementByClassName("blockUI blockOverlay ui-widget-overlay"));
                //WaitAndClick(() => FindElementByXPath(@"//*[@id=""administrationForm:administrationTab:users:authority""]/div[3]/span"));
                //FindElementByXPath(@"//*[@id=""administrationForm:administrationTab:users:authority_panel""]/div/ul/li[2]").Click();
                //FindElementByName("administrationForm:administrationTab:users:username").SendKeys("Admin User");
                //FindElementByName("administrationForm:administrationTab:users:password").SendKeys("poiskitpoiskit");
                //FindElementByName("administrationForm:administrationTab:users:accountExpirationDate_input").SendKeys("29.11.2024 00:00:00");
                //FindElementByName("administrationForm:administrationTab:users:saveUserAccountButton").Click();
                //WaitOverlay(() => FindElementByClassName("blockUI blockOverlay ui-widget-overlay"));
                //WaitAndClick(() => FindElementById("administrationForm:administrationTab:users:j_idt88"));
                //IWebElement checkResult = Wait(() => FindElementByXPath(userXpath));
                //if (checkResult != null)
                //{
                //    return TestResult.Success("Test successfully completed");
                //}
                //else
                //{
                //    throw new TestCaseException("User was not created");
                //}

                return TestResult.Success("Test successfully completed");
            }
            catch
            {
                return TestResult.Fail("Could not find element " + login + " on this page");
            }
            finally
            {
            }
        }
        #endregion
    }
}