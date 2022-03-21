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

        public void HomeTest() // Tests the Home button "JOLIDON"
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
       
        public void LoginTest() // Tests "Autentificare" button
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

        public void CreateAccountTest() // Tests "Creaza cont" button
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

        public void CartTest() // Tests " Cosul meu" button
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
        public void SearchTest() // Tests "Cauta" button
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            lp.AcceptCookies();
            lp.SearchPage();            
        }   
        
        [Test]
        /// This is a tests where all above buttons are tested
        /// After one button is pressed we return to the manin page
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
