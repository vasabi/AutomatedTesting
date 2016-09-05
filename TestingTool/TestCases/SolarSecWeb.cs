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
#endregion

namespace TestingTool
{
    [TestCaseIdentifier("SCW", "web")] //атрибуты, считываемые из csv в папке TestInitCSV
    public class SolarSecWeb : TestCaseBaseWeb
    {
        #region Test execution
        public override TestResult RunTestWeb()
        {
            string urlMail = "https://mail.ru/";
            string urlYa = "https://mail.yandex.ru";
            var outFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "result.csv");
            char stateMail;
            char stateYa;
            String[] mass = GetConfig();

            File.WriteAllText(outFilePath, "Resource;Outbox;Inbox" + Environment.NewLine);
            try
            {
                Driver.Navigate().GoToUrl(urlMail);
                if (FindElementByXPath(@"//*[@id=""mailbox-auth-login""]").GetAttribute("value") != "" && FindElementByXPath(@"//*[@id=""mailbox__password""]").GetAttribute("value") != "")
                {
                    FindElementByXPath(@"//*[@id=""mailbox__auth__button""]").Click();
                }
                FindElementByXPath(@"//*[@id=""mailbox__login""]").SendKeys(mass[0]);
                FindElementByXPath(@"//*[@id=""mailbox__password""]").SendKeys(mass[1]);
                FindElementByXPath(@"//*[@id=""mailbox__auth__button""]").Click();
                try
                {
                    WaitAndClick(() => FindElementByXPath(@"//*[@id=""b-toolbar__left""]/div/div/div[2]/div/a/span"), TimeSpan.FromSeconds(5));
                }
                catch
                {
                    Console.WriteLine("incorrect login or password to " + urlMail + "      " + Driver.Url);
                    throw;
                }
                Wait(() => FindElementByXPath(@"//*[@id=""compose__header__content""]/div[2]/div[2]/div[1]/textarea[2]"), TimeSpan.FromSeconds(5));
                FindElementByXPath(@"//*[@id=""compose__header__content""]/div[2]/div[2]/div[1]/textarea[2]").SendKeys(mass[4]);
                FindElementByXPath(@"//*[@id=""compose__header__content""]/div[3]/div[2]/div[1]/textarea[2]").SendKeys(mass[5]);
                FindElementByXPath(@"//*[@id=""compose__header__content""]/div[4]/div[2]/div[1]/textarea[2]").SendKeys(mass[6]);
                FindElementByName("Subject").SendKeys(mass[7]);
                Driver.SwitchTo().Frame(FindElementByXPath(@"//*[contains(@id, '_composeEditor_ifr')]"));
                FindElementByXPath(@"//*[@id=""tinymce""]").SendKeys(mass[8]);
                Driver.SwitchTo().DefaultContent();
                FindElementByXPath(@"//*[@id=""b-toolbar__right""]/div/div/div[2]/div[1]/div/span").Click();
                Wait(() => FindElementByXPath(@"//*[@id=""b-compose__sent""]/div/div[2]/div[1]/span"), TimeSpan.FromSeconds(5));

                Regex rgx = new Regex(@"^https://e.mail.ru/sendmsgok.*");
                stateMail = '+';
                if (rgx.IsMatch(Driver.Url) != true)
                {
                    stateMail = '-';
                }
                Console.WriteLine(urlMail + " - ok");
                File.AppendAllText(outFilePath, urlMail + ";" + stateMail + ";" + "" + Environment.NewLine);
            }
            catch
            {
                stateMail = '-';
                Console.WriteLine(urlMail + " - fail");
                File.AppendAllText(outFilePath, urlMail + ";" + stateMail + ";" + "" + Environment.NewLine);
            }
            try
            {
                Driver.FindElement(By.CssSelector("body")).SendKeys(OpenQA.Selenium.Keys.Control + "t");
                string newTabInstance = Driver.WindowHandles[Driver.WindowHandles.Count - 1].ToString();
                Driver.SwitchTo().Window(newTabInstance);
                Driver.Navigate().GoToUrl(urlYa);
                Wait(() => FindElementByXPath(@"//*[@id=""nb-1""]/span/input"), TimeSpan.FromSeconds(5));
                if (FindElementByXPath(@"//*[@id=""nb-1""]/span/input").GetAttribute("value") != "" && FindElementByXPath(@"//*[@id=""nb-2""]/span/input").GetAttribute("value") != "")
                {
                    FindElementByXPath(@"//*[@id=""js""]/body/div[1]/div[1]/div[1]/form/div[4]/span/button").Click();
                }
                FindElementByXPath(@"//*[@id=""nb-1""]/span/input").SendKeys(mass[2]);
                FindElementByXPath(@"//*[@id=""nb-2""]/span/input").SendKeys(mass[3]);
                FindElementByXPath(@"//*[@id=""js""]/body/div[1]/div[1]/div[1]/form/div[4]/span/button").Click();
                try
                {
                    WaitAndClick(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[2]/div/div/div/div[2]/a[2]/img"), TimeSpan.FromSeconds(5));
                }
                catch
                {
                    Console.WriteLine("incorrect login or password to " + urlYa + "      " + Driver.Url);
                    throw; ;
                }
                WaitAndClick(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[3]/td[2]/div[2]/div"), TimeSpan.FromSeconds(5));
                FindElementByCssSelector("#js-page > div > div.block-app > div > div.b-layout__right > div > div.block-right-box > div > div > div > div.block-compose > div > div > form > table > tbody > tr.b-compose-head__field.b-compose-head__field_to.js-compose-field-wrapper__to > td.b-compose-head__field__value > div.b-mail-input.b-mail-input_yabbles.js-compose-mail-input.js-compose-mail-compose-input.js-compose-mail-input_to > div > div > input").SendKeys(mass[4]);
                WaitAndClick(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div/div/div/form/table/tbody/tr[3]/td[2]/div[1]/span[2]"), TimeSpan.FromSeconds(5));
                WaitAndClick(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[4]/td[2]/div/div"), TimeSpan.FromSeconds(5));
                FindElementByCssSelector("#js-page > div > div.block-app > div > div.b-layout__right > div > div.block-right-box > div > div > div > div.block-compose > div > div > form > table > tbody > tr.b-compose-head__field.b-compose-head__field_cc.js-compose-field-wrapper__cc.js-compose-type > td.b-compose-head__field__value > div > div > div > input").SendKeys(mass[5]);
                WaitAndClick(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div/div/div/form/table/tbody/tr[3]/td[2]/div[1]/span[3]"), TimeSpan.FromSeconds(5));
                WaitAndClick(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[2]/div/div/form/table/tbody/tr[5]/td[2]/div/div"), TimeSpan.FromSeconds(5));
                FindElementByCssSelector("#js-page > div > div.block-app > div > div.b-layout__right > div > div.block-right-box > div > div > div > div.block-compose > div > div > form > table > tbody > tr.b-compose-head__field.b-compose-head__field_bcc.js-compose-field-wrapper__bcc.js-compose-type > td.b-compose-head__field__value > div > div > div > input").SendKeys(mass[6]);
                FindElementByXPath(@"//*[@id=""compose-subj""]").SendKeys(mass[7]);
                Driver.SwitchTo().Frame(FindElementByXPath(@"//*[@id=""compose-send_ifr""]"));
                FindElementByXPath(@"//*[@id=""tinymce""]").SendKeys(mass[8]);
                Driver.SwitchTo().DefaultContent();
                FindElementByXPath(@"//*[@id=""nb-18""]").Click();

                Regex rgx = new Regex(@".*#done$");
                Wait(() => FindElementByXPath(@"//*[@id=""js-page""]/div/div[5]/div/div[3]/div/div[3]/div/div/div/div[3]/div/div/div[1]"), TimeSpan.FromSeconds(5));
                stateYa = '+';
                if (rgx.IsMatch(Driver.Url) != true)
                {
                    stateYa = '-';
                }
                Console.WriteLine(urlYa + " - ok");
                File.AppendAllText(outFilePath, urlYa + ";" + stateYa + ";" + "" + Environment.NewLine);
                return TestResult.Success("Test successfully completed");
            }
            catch
            {
                stateYa = '-';
                Console.WriteLine(urlYa + " - fail");
                File.AppendAllText(outFilePath, urlYa + ";" + stateYa + ";" + "" + Environment.NewLine);
                return TestResult.Fail("Test failed");
            }
            finally
            {
            }
        }
        #endregion

        public String[] GetConfig()
        {
            String[] strings = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.csv"));
            try
            {
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
                return new String[] { loginMail, passwordMail, loginYa, passwordYa, mailTo, mailCC, mailBCC, mailSubj, mailText };
            }
            catch
            {
                throw new Exception("input.csv file is not valid");
            }
        }
    }
}