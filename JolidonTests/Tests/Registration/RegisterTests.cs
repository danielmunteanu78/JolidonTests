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
    class RegisterTests : BaseTest
    {
        
        string url = FrameworkConstants.GetUrl();       

        [Test]

        public void RegisterTest()
        {
            driver.Navigate().GoToUrl(url + "/customer/account/create/");
            RegisterPage rp = new RegisterPage(driver);
            Assert.AreEqual("CREAZA CONT CLIENT NOU", rp.CheckPage());
            rp.AcceptCookies();
            rp.Register("aaaa","bbbb" ,"aaaa@bbbb.com","1234");
        }       

    }
}
