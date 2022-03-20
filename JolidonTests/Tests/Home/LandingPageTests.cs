using JolidonTests.POM;
using JolidonTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JolidonTests.Tests
{
    class LandingPageTests : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        [Test]

        public void HomeTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage hb = new LandingPage(_driver);
            hb.AcceptCookies();
            hb.HomeButton();
        }

        [Category("Smoke")]
        [Test]
       // [Parallelizable(ParallelScope.Self)]
        public void LoginTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);            
            lp.AcceptCookies();
            lp.LoginNavigate();            
        }

        [Category("Smoke")]
        [Test]       

        public void CreateAccountTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);            
            lp.AcceptCookies();            
            lp.CreateAccount();           
        }

        [Category("Smoke")]
        [Test]       

        public void CartTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            lp.AcceptCookies();
            lp.MyCart();          

        }

        [Category("Smoke")]
        [Test]
       // [Parallelizable(ParallelScope.Self)]
        public void SearchTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            lp.AcceptCookies();
            lp.SearchPage();            
        }   
        
        [Test]

        public void AllInOneHPTests()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            lp.AcceptCookies();
            lp.LoginNavigate();
            lp.HomeButton();
            lp.CreateAccount();
            lp.HomeButton();
            lp.MyCart();
            lp.HomeButton();
            lp.SearchPage();
        }
    }
}
