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
    class AuthTest : BaseTest
    {       

        string url = FrameworkConstants.GetUrl();        

        [Test]
        public void BasicAuth()
        {
            driver.Navigate().GoToUrl(url + "/customer/account/login/referer/aHR0cHM6Ly9zaG9wLmpvbGlkb24ucm8v/");
            LoginPage lp = new LoginPage(driver);
            
            Assert.AreEqual("CONECTARE CLIENT", lp.CheckPage());
            lp.AcceptCookies();
            lp.Login("user1", "pass1");
        }
    }
}
