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

public class MyTestCaseBase:IDisposable
{
    protected IWebDriver Driver;

    public MyTestCaseBase()
    {

    }

    #region Set up Driver
    public MyTestCaseBase SetupDriver(String value)
    {
        switch (value)
        {
            case "Google Chrome":

                Driver = new ChromeDriver();
                return this;
            case "Firefox":
                Driver = new FirefoxDriver();
                return this;
            case "IE":
                Driver = new InternetExplorerDriver();
                return this;
            default:
                throw new Exception("User was not created");
        }
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
        IWebElement elementOnPage = Driver.FindElement(By.Name(value));
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

    public virtual TestResult RunTest()
    {
        return TestResult.Fail("Run test not realized");
    }

    public virtual void Dispose()
    {
        Driver.Dispose();
    }
}