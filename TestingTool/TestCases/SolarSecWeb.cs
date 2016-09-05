#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;
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
using System.Text.RegularExpressions;
using Selenium.Automation;
using System.Windows.Forms;
#endregion

namespace TestingTool
{
    [TestCaseIdentifier("g", "web")] //атрибуты, считываемые из csv
    public class SolarSecWeb : TestCaseBase
    {
        #region Test execution
        public override TestResult RunTest()
        {
            string urlMail = "https://mail.ru/";
            string urlYa = "https://mail.yandex.ru";
            var strings = File.ReadAllLines(@"D:\input.csv");
            var item = strings[0].Split(';');

            string loginMail = item[0];
            string passwordMail = item[1];
            string loginYa = item[2];
            string passwordYa = item[3];
            string mailTo = item[4];
            string mailCC = item[5];
            string mailBCC = item[6];
            string mailSubj = item[7];
            string mailText = item[8];
            char stateMail;
            char stateYa;

            File.WriteAllText(@"D:/result.csv", "Resource;Outbox;Inbox" + Environment.NewLine);
            try
            {
                //Driver.Navigate().GoToUrl(urlMail);
                //if (FindElementByXPath(@"//*[@id=""mailbox-auth-login""]").GetAttribute("value") != "" && FindElementByXPath(@"//*[@id=""mailbox__password""]").GetAttribute("value") != "")
                //{
                //    FindElementByXPath(@"//*[@id=""mailbox__auth__button""]").Click();
                //}
                //FindElementByXPath(@"//*[@id=""mailbox__login""]").SendKeys(loginMail);
                //FindElementByXPath(@"//*[@id=""mailbox__password""]").SendKeys(passwordMail);
                //FindElementByXPath(@"//*[@id=""mailbox__auth__button""]").Click();
                //WaitAndClick(() => FindElementByXPath(@"//*[@id=""b-toolbar__left""]/div/div/div[2]/div/a/span"));
                //Wait(() => FindElementByXPath(@"//*[@id=""compose__header__content""]/div[2]/div[2]/div[1]/textarea[2]"));
                //FindElementByXPath(@"//*[@id=""compose__header__content""]/div[2]/div[2]/div[1]/textarea[2]").SendKeys(mailTo);
                //FindElementByXPath(@"//*[@id=""compose__header__content""]/div[3]/div[2]/div[1]/textarea[2]").SendKeys(mailCC);
                //FindElementByXPath(@"//*[@id=""compose__header__content""]/div[4]/div[2]/div[1]/textarea[2]").SendKeys(mailBCC);
                //FindElementByName("Subject").SendKeys(mailSubj);
                //Driver.SwitchTo().Frame(FindElementByXPath(@"//*[contains(@id, '_composeEditor_ifr')]"));
                //FindElementByXPath(@"//*[@id=""tinymce""]").SendKeys(mailText);
                //Driver.SwitchTo().DefaultContent();
                //FindElementByXPath(@"//*[@id=""b-toolbar__right""]/div/div/div[2]/div[1]/div/span").Click();
                //Regex rgx = new Regex(@"^https://e.mail.ru/sendmsgok.*");
                //if (rgx.IsMatch(Driver.Url) != true)
                //{
                //    stateMail = '-';
                //}
                //stateMail = '+';
                //File.AppendAllText(@"D:/result.csv", urlMail + ";" + stateMail + ";" + "" + Environment.NewLine);
                //Wait(() => FindElementByXPath(@"//*[@id=""b-compose__sent""]/div/div[2]/div[1]/span"));
            }
            catch
            {
                stateMail = '-';
                File.AppendAllText(@"D:/result.csv", urlMail + ";" + stateMail + ";" + "" + Environment.NewLine);
            }
            try
            {
                Driver.FindElement(By.CssSelector("body")).SendKeys(OpenQA.Selenium.Keys.Control + "t");
                string newTabInstance = Driver.WindowHandles[Driver.WindowHandles.Count - 1].ToString();
                Driver.SwitchTo().Window(newTabInstance);
                Driver.Navigate().GoToUrl(urlYa);
                if (FindElementByXPath(@"//*[@id=""nb-1""]/span/input").GetAttribute("value") != "" && FindElementByXPath(@"//*[@id=""nb-2""]/span/input").GetAttribute("value") != "")
                {
                    FindElementByXPath(@"//*[@id=""js""]/body/div[1]/div[1]/div[1]/form/div[4]/span/button").Click();
                }
                FindElementByXPath(@"//*[@id=""nb-1""]/span/input").SendKeys(loginYa);
                FindElementByXPath(@"//*[@id=""nb-2""]/span/input").SendKeys(passwordYa);
                FindElementByXPath(@"//*[@id=""js""]/body/div[1]/div[1]/div[1]/form/div[4]/span/button").Click();
                WaitAndClick(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[2]/div/div/div/div[2]/a[2]/img"));
                Wait(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[3]/td[2]/div[2]/input[1]"));
                FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[3]/td[2]/div[2]/div/div").Click();
                Wait(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[3]/td[2]/div[2]/div/div/span[1]/span[2]"));
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("mailTo");
//                FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[3]/td[2]/div[2]/div/div/span[1]/span[2]").SendKeys(mailTo);
                FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[4]/td[2]/div/div/div/span[1]/span[2]").Click();
                FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[3]/td[2]/div[2]/div/div/input").SendKeys(mailCC);
                FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[5]/td[2]/div/div/div/span[1]/span[2]").Click();
                FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[5]/td[2]/div/div/div/span[1]/span[2]").SendKeys(mailBCC);
                FindElementByName("subj").SendKeys(mailSubj);
                Driver.SwitchTo().Frame(FindElementByXPath(@"//*[@id=""compose-send_ifr""]"));
                FindElementByXPath(@"//*[@id=""tinymce""]").SendKeys(mailText);
                Driver.SwitchTo().DefaultContent();
                FindElementByXPath(@"//*[@id=""nb-18""]").Click();
                Regex rgx = new Regex(@".*https://e.mail.ru/sendmsgok$");
                if (rgx.IsMatch(Driver.Url) != true)
                {
                    stateYa = '-';
                }
                stateYa = '+';
                File.AppendAllText(@"D:/result.csv", urlYa + ";" + stateYa + ";" + "" + Environment.NewLine);
                return TestResult.Success("Test successfully completed");
            }
            catch
            {
                stateYa = '-';
                File.AppendAllText(@"D:/result.csv", urlYa + ";" + stateYa + ";" + "" + Environment.NewLine);
                return TestResult.Fail("Test failed");
            }
            finally
            {
            }
        }
        #endregion
    }
}