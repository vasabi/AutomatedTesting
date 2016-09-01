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
    [TestCaseIdentifier("Avalanche-3", "BasicTestGroup")] //атрибуты, считываемые из csv
    public class WUIElementPresentSearch : TestCaseBase
    {
        #region Test execution
        public override TestResult RunTest()
        {
            try
            {
                WUIHelper.LoginToServer(this);

                FindElementByXPath(@"/html/body/div[1]/div/div[2]"); //найти панель навигации
                FindElementByXPath(@"/html/body/div[1]/div/div[2]/button"); //найти кнопку "спрятать панель навигации"
                FindElementByXPath(@"/html/body/div[1]/div/div[2]/a"); //найти заголовок панели навигации
                FindElementByXPath(@"//*[@id=""menu-toggle-2""]"); //кнопка "задания"
                FindElementByXPath(@"/html/body/div[1]/div/div[3]/ul[2]/li[2]/a"); //выпадающий список действий

                FindElementByXPath(@"//*[@id=""page-content-wrapper""]/div[1]/div/div[1]"); //панель заголовка запрос
                FindElementByXPath(@"//*[@id=""basic-addon1""]"); //заголовок поля запрос
                FindElementByXPath(@"//*[@id=""Query""]"); //поле запрос
                FindElementByXPath(@"//*[@id=""page-content-wrapper""]/div[1]/div/div[2]/form/div[1]/div[2]/div/span"); //заголовок поля язык
                FindElementByXPath(@"//*[@id=""Language""]"); //селектор языка
                FindElementByXPath(@"//*[@id=""page-content-wrapper""]/div[1]/div/div[2]/form/div[1]/div[3]/button"); //кнопка поиска
                FindElementByXPath(@"//*[@id=""page-content-wrapper""]/div[2]"); //результаты запроса (без выполнения запроса)
                FindElementByXPath(@"/html/body/footer"); //найти футер
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
