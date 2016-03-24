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
    internal class MockWebElement : IWebElement
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public bool Displayed
        {
            get { throw new NotImplementedException(); }
        }

        public bool Enabled
        {
            get { throw new NotImplementedException(); }
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public System.Drawing.Point Location
        {
            get { throw new NotImplementedException(); }
        }

        public bool Selected
        {
            get { throw new NotImplementedException(); }
        }

        public void SendKeys(string text)
        {
            throw new NotImplementedException();
        }

        public System.Drawing.Size Size
        {
            get { throw new NotImplementedException(); }
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public string TagName
        {
            get { throw new NotImplementedException(); }
        }

        public string Text
        {
            get { throw new NotImplementedException(); }
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
    }
}
