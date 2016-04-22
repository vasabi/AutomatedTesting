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
    [TestCaseIdentifier("Avalanche-3", "BasicTestGroup", "ElementPresent check Autorization page")] //атрибуты, считываемые из csv
    public class WUIElementPresentAutorization : MyTestCaseBase
    {
        #region Test execution
        public override TestResult RunTest()
        {
            string homeUrl = "http://10.91.5.3:8080/";
            try
            {
                Driver.Navigate().GoToUrl(homeUrl);
                FindElementByXPath(@"/html/body/div[1]"); //найти панель навигации
                FindElementByXPath(@"/html/body/div[1]/div/div[1]/button"); //найти кнопку "спрятать панель навигации"
                FindElementByXPath(@"/html/body/div[1]/div/div[1]/a"); //найти заголовок панели навигации
                FindElementByXPath(@"//*[@id=""wrapper""]"); //найти основной контейнер
                FindElementByXPath(@"//*[@id=""wrapper""]/div[1]/div"); //найти титульный текст
                FindElementByXPath(@"//*[@id=""wrapper""]/div[2]/section"); //найти блок ввода логина/пароля
                FindElementByXPath(@"//*[@id=""wrapper""]/div[2]/section/form/div[2]/label"); //найти заголовок логин
                FindElementByXPath(@"//*[@id=""Login""]"); //найти поле ввода логина
                FindElementByXPath(@"//*[@id=""wrapper""]/div[2]/section/form/div[3]/label"); //найти заголовок пароль
                FindElementByXPath(@"//*[@id=""Password""]"); //найти поле ввода пароля
                FindElementByXPath(@"//*[@id=""wrapper""]/div[2]/section/form/div[4]/div/div"); //найти чекбокс запомнить меня
                FindElementByXPath(@"//*[@id=""wrapper""]/div[2]/section/form/div[4]/div/div/label"); //найти заголовок запомнить меня
                FindElementByXPath(@"//*[@id=""wrapper""]/div[2]/section/form/div[5]/div/button"); //найти кнопку логин
                FindElementByXPath(@"/html/body/footer/p"); //найти футер
                return TestResult.Success("Test successfully completed");
            }
            catch (Exception exception)
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
