using JolidonTests.POM;
using JolidonTests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.Tests.Search
{
    class SearchTests: BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            var csvData = Utils.GetDataTableFromCSV("TestData\\searchcredentials.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }
        [Category("SearchWithDb")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]

        public void SearchTest(string item)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            SearchPage sp = new SearchPage(_driver);
            lp.AcceptCookies();
            //lp.SearchPage();
            sp.Search(item);
        }
    }
}
