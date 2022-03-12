using JolidonTests.POM;
using JolidonTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.Tests
{
    class LandingPageTests : BaseTest
    {        

        string url = FrameworkConstants.GetUrl();        

        [Category("Smoke")]
        [Test]
       // [Parallelizable(ParallelScope.Self)]
        public void LoginTest()
        {
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            lp.AcceptCookies();
            lp.LoginNavigate();
            //testName = TestContext.CurrentContext.Test.Name;
           // _test = _extent.CreateTest(testName);
        }

        [Category("Smoke")]
        [Test]
       // [Parallelizable(ParallelScope.Self)]

        public void CreateAccountTest()
        {
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            lp.AcceptCookies();
            lp.CreateAccount();            
        }

        [Category("Smoke")]
        [Test]
        //[Parallelizable(ParallelScope.Self)]

        public void CartTest()
        {
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            lp.AcceptCookies();
            lp.MyCart();
            //  Assert.AreEqual("Cosul meu", lp.CheckCartPage());           
            
        }

        [Category("Smoke")]
        [Test]
       // [Parallelizable(ParallelScope.Self)]
        public void SelectTest()
        {
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            lp.AcceptCookies();
            lp.SearchPage();            
        }        
    }
}
