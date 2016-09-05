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
    public class TestCaseBase : IDisposable
    {
        protected IWebDriver Driver;

        #region конструктор
        public TestCaseBase()
        {

        }
        #endregion

        #region Set up Driver
        public TestCaseBase SetupDriver(String value)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SeleniumDrivers");
            switch (value)
            {
                case "Google Chrome":
                    Driver = new ChromeDriver(path);
                    return this;
                case "Firefox":
                    Driver = new FirefoxDriver();
                    return this;
                case "IE":
                    Driver = new InternetExplorerDriver(path);
                    return this;
                default:
                    throw new Exception("User was not created");
            }
        }
        #endregion

        #region Wait

        public IWebElement Wait(Func<IWebElement> whatToWait)
        {
            return Wait(whatToWait, TimeSpan.FromSeconds(60));
        }
        public IWebElement Wait(Func<IWebElement> whatToWait, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(Driver, timeout);
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
                {
                    try
                    {
                        return whatToWait();
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                    catch (ElementNotVisibleException)
                    {
                        return null;
                    }
                });
            return myDynamicElement;
        }

        public Boolean WaitBool(Func<Boolean> whatToWait)
        {
            return WaitBool(whatToWait, TimeSpan.FromSeconds(60));
        }
        public Boolean WaitBool(Func<Boolean> whatToWait, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(Driver, timeout);
            Boolean check = wait.Until<Boolean>((d) =>
            {
                try
                {
                    return whatToWait();
                }
                catch (NotFoundException)
                {
                    return true;
                }
            });
            return check;
        }

        public void WaitOverlay(Func<IWebElement> whatToWait)
        {
            try
            {
                Wait(whatToWait, TimeSpan.FromSeconds(1));
            }
            catch (WebDriverTimeoutException)
            {
            }

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                try
                {
                    whatToWait();
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return new MockWebElement();
                }
                catch (ElementNotVisibleException)
                {
                    return new MockWebElement();
                }
            });
        }

        public void WaitAndClick(Func<IWebElement> whatToWait)
        {
            WaitAndClick(whatToWait, TimeSpan.FromSeconds(60));
        }
        public void WaitAndClick(Func<IWebElement> whatToWait, TimeSpan timeout)
        {

            IWebElement elem = null;
            Boolean isClicked = false;
            while (!isClicked)
            {
                try
                {
                    elem = Wait(whatToWait, timeout);
                    elem.Click();
                    isClicked = true;
                }
                catch (InvalidOperationException)
                {
                    Task.Delay(100).Wait();
                }
                catch (StaleElementReferenceException)
                {
                    Task.Delay(100).Wait();
                }
            }
        }
        #endregion

        #region FindElementByName
        public IWebElement FindElementByName(String value)
        {
            IWebElement elementOnPage = Driver.FindElement(By.Name(value));
            return elementOnPage;
        }
        #endregion

        #region FindElementByClassName
        public IWebElement FindElementByClassName(String value)
        {
            IWebElement elementOnPage = Driver.FindElement(By.ClassName(value));
            return elementOnPage;
        }
        #endregion

        #region FindElementByXPath
        public IWebElement FindElementByXPath(String value)
        {
            IWebElement elementOnPage = Driver.FindElement(By.XPath(value));
            return elementOnPage;
        }
        #endregion

        #region FindElementById
        public IWebElement FindElementById(String value)
        {
            IWebElement elementOnPage = Driver.FindElement(By.Id(value));
            return elementOnPage;
        }
        #endregion

        #region FindElementByLinkText
        public IWebElement FindElementByLinkText(String value)
        {
            IWebElement elementOnPage = Driver.FindElement(By.LinkText(value));
            return elementOnPage;
        }
        #endregion

        #region SelectElement
        public SelectElement SelectElementBySmth(IWebElement value)
        {
            SelectElement select = new SelectElement(value);
            var options = select.Options;
            return select;
        }
        #endregion

        #region IsElementPresentByXPath
        public Boolean IsElementPresentByXPath(String value)
        {
            try
            {
                Driver.FindElement(By.XPath(value));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion

        #region запуск теста
        public virtual TestResult RunTest()
        {
            return TestResult.Fail("Run test not realized");
        }
        #endregion

        #region Dispose
        public virtual void Dispose()
        {
            Driver.Dispose();
        }
        #endregion

        #region DriverMethods
        internal void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        internal string GetUrl()
        {
            return Driver.Url;
        }
        #endregion
    }
}