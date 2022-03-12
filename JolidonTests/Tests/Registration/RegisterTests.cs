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

        [Category("RegisterWithDb"),Category("Name")]
        [Test,TestCaseSource("GetCredentialsDataCsv"),Order(1)]
        //[Parallelizable(ParallelScope.Self)]

        public void RegisterTest(string firstName, string lastName, string email, string password)
        {
            _driver.Navigate().GoToUrl(url + "/customer/account/create/");
            RegisterPage rp = new RegisterPage(_driver);

            Assert.AreEqual("CREAZA CONT CLIENT NOU", rp.CheckPage());
            Thread.Sleep(1000);
            rp.AcceptCookies();            
            rp.Register(firstName,lastName,email,password);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }       

    }
}
