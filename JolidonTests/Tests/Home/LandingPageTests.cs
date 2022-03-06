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

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(driver);
            lp.AcceptCookies();
            lp.LoginNavigate();
        }

        [Test]

        public void CreateAccountTest()
        {
            driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(driver);
            lp.AcceptCookies();
            lp.CreateAccount();
        }

        [Test]

        public void CartTest()
        {
            driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(driver);
            lp.AcceptCookies();
            lp.MyCart();
          //  Assert.AreEqual("Cosul meu", lp.CheckCartPage());
        }
        [Test]
        public void SelectTest()
        {
            driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(driver);
            lp.AcceptCookies();
            lp.SearchPage();
        }        
    }
}
