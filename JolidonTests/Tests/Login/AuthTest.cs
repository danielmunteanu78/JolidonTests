using JolidonTests.POM;
using JolidonTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace JolidonTests.Tests
{
    class AuthTest : BaseTest
    {       
        string url = FrameworkConstants.GetUrl();       

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            var csvData = Utils.GetDataTableFromCSV("TestData\\credentials.csv");
            for (int i=0; i<csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

    [Category("AuthWithDb"),Category("Name")]
    [Test, TestCaseSource("GetCredentialsDataCsv")]    

        public void BasicAuth(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LoginPage lp = new LoginPage(_driver);
            LandingPage ldp = new LandingPage(_driver);

            ldp.LoginNavigate();
            Assert.AreEqual("CONECTARE CLIENT", lp.CheckPage());            
            lp.AcceptCookies();
            lp.Login(email,password);            

            if (email.Length == 0) // check if the email field has been filled in
            {
                Assert.AreEqual("Acesta este un camp obligatoriu.", lp.EmailAdressError());
            }

            else if (!isValidEmailAdress(email)) // check if the email adress is valid
            {
                Assert.AreEqual("Introduceti o adresa email valida (Ex: johndoe@domain.com).", lp.EmailAdressError());
            }   
            
            if (password.Length == 0) // check if the password field has been filled in
            {
                Assert.AreEqual("Acesta este un camp obligatoriu.", lp.PasswordErrorMsg());
            }

            /*if(isValidEmailAdress(email)&&password.Length != 0) 
            {
                Thread.Sleep(200);
                Assert.AreEqual("CAPTCHA incorect", lp.AccountLoginErrMsg());
            }*/
        }
        private bool isValidEmailAdress(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
