using JolidonTests.POM;
using JolidonTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Linq;

namespace JolidonTests.Tests
{

    class RegisterTests : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            var csvData = Utils.GetDataTableFromCSV("TestData\\regcredentials.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Category("RegisterWithDb")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]        

        public void RegisterTest(string firstName, string lastName, string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url); 
            LandingPage lp = new LandingPage(_driver);
            RegisterPage rp = new RegisterPage(_driver);

            lp.AcceptCookies();            
            lp.CreateAccount();
            Assert.AreEqual("CREAZA CONT CLIENT NOU", rp.CheckPage());

            rp.Register(firstName, lastName, email, password);
            Assert.AreEqual("Prenume", rp.CheckFirstName());

            if (firstName.Length == 0)
            {
                Assert.AreEqual("Acesta este un camp obligatoriu.", rp.FirstNameErrMsg());
            }

            if (lastName.Length == 0)
            {
                Assert.AreEqual("Acesta este un camp obligatoriu.", rp.LastNameErrMsg());
            }

            if (!isValidEmailAdress(email))
            {
                Assert.AreEqual("Introduceti o adresa email valida (Ex: johndoe@domain.com).", rp.EmailErrMsg());
            }
           
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChArray = specialCh.ToCharArray();
             bool specialChar = true;

            foreach (char ch in specialChArray)
            {
                if (password.Contains(ch))
                    specialChar = true;
            }

            if (password.Length < 8)
            {
                Assert.AreEqual("Minimum length of this field must be equal or greater than 8 symbols. Leading and trailing spaces will be ignored.", rp.PasswordErrMsg());
            }

            else if (specialChar == true && password.Any(char.IsUpper) && password.Any(char.IsLower)&&password.Any(char.IsDigit))
            {
                Console.WriteLine("The password is STRONG !!!");
            }            
            else
            {
                Assert.AreEqual("Minimum of different classes of characters in password is 3. Classes of characters: Lower Case, Upper Case, Digits, Special Characters.", rp.PasswordErrMsg());
            }            
        }              
        
        private bool isValidEmailAdress(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
 

