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

public class MyTestCaseBase
{
    public MyTestCaseBase()
    {
    }

    public IWebDriver driver;

    #region Set up Chrome Driver
    public void SetupChrome()
    {
        driver = new ChromeDriver();
    }
    #endregion

    #region Set up Firefox Driver
    public void SetupFirefox()
    {
        driver = new FirefoxDriver();
    }
    #endregion

    #region Set up IE Driver
    public void SetupIEDriver()
    {
        driver = new InternetExplorerDriver();
    }
    #endregion

    #region Exit
    public void Exit()
    {
        driver.Close();
        driver.Quit();
    }
    #endregion

    #region Wait
    public void Wait(Int32 value)
    {
        System.Threading.Thread.Sleep(value);
    }
    #endregion

    #region FindElementByName
    public IWebElement FindElementByName(String value)
    {
        IWebElement elementOnPage = driver.FindElement(By.Name(value));
        return elementOnPage;
    }
    #endregion

    #region FindElementByXPath
    public IWebElement FindElementByXPath(String value)
    {
        IWebElement elementOnPage = driver.FindElement(By.XPath(value));
        return elementOnPage;
    }
    #endregion

    #region FindElementById
    public IWebElement FindElementById(String value)
    {
        IWebElement elementOnPage = driver.FindElement(By.Id(value));
        return elementOnPage;
    }
    #endregion

    #region FindElementByLinkText
    public IWebElement FindElementByLinkText(String value)
    {
        IWebElement elementOnPage = driver.FindElement(By.LinkText(value));
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

    public virtual TestResult RunTest()
    {
       return TestResult.Fail("Run test not realized");
    }
}