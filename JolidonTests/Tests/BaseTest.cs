using JolidonTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.Tests
{
    class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = Browsers.GetDriver(WebBrowsers.Edge);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
