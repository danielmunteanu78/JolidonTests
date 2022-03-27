using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.POM
{
    public class SearchPage : BasePage
    {
        const string searchIconSelector = "#html-body > div.page-wrapper > div.header-placeholder > div.page-header.page-header-v4 > header > div.panel.wrapper > div > div > div.block.block-search.search-visible-md.minisearch-v2 > div > i"; //Css
        const string searchBarSelector = "search"; //id
        const string searchButtonSelector = "//*[@id='search_mini_form']/div/div/div[1]/button"; // Xpath

        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        public void Search(string item)
        {
            Utils.WaitForElement(driver, 2, By.CssSelector(searchIconSelector)).Click();
            var searchBarSel = driver.FindElement(By.Id(searchBarSelector));
            searchBarSel.Clear();
            searchBarSel.SendKeys(item);
            driver.FindElement(By.XPath(searchButtonSelector)).Submit();
        }
    }
}
