using JolidonTests.POM;
using JolidonTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace JolidonTests.Tests
{
    class AuthTest : BaseTest
    {       
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable <TestCaseData> GetCredentialsData()
            {
                 yield return new TestCaseData(" user1", "pass1");
                 yield return new TestCaseData(" user2", "pass2");
                 yield return new TestCaseData(" user3", "pass3");
                 yield return new TestCaseData(" user4", "pass4");
            }

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\credentials.csv"))
            {
                yield return new TestCaseData(values);
            }

        }

    [Test, TestCaseSource("GetCredentialsDataCsv")]
        
        public void BasicAuth(string email, string password)
        {
            driver.Navigate().GoToUrl(url + "/customer/account/login/referer/aHR0cHM6Ly9zaG9wLmpvbGlkb24ucm8v/");
            LoginPage lp = new LoginPage(driver);
            
            Assert.AreEqual("CONECTARE CLIENT", lp.CheckPage());
            Thread.Sleep(1000);
            lp.AcceptCookies();
            lp.Login(email,password);
        }
    }
}
