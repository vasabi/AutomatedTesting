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

public class TestResult
{
    public String Message { get; set; }
    public TestCaseResultStatus Status { get; set; }

    public static TestResult Success(String message)
    {
        return new TestResult()
        {
            Message = message,
            Status = TestCaseResultStatus.Pass
        };
    }

    public static TestResult Block(String message)
    {
        return new TestResult()
        {
            Message = message,
            Status = TestCaseResultStatus.Blocked
        };
    }

    public static TestResult Fail(String message)
    {
        return new TestResult()
        {
            Message = message,
            Status = TestCaseResultStatus.Fail
        };
    }

    public static TestResult Other(String message)
    {
        return new TestResult()
        {
            Message = message,
            Status = TestCaseResultStatus.undefined
        };
    }
}
