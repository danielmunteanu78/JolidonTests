using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.POM
{
    public class LandingPage : BasePage
    {
        const string authButtonSelector = "#html-body > div.page-wrapper > div.header-placeholder > div.page-header.page-header-v4 > header > div.panel.wrapper > div > ul.header.links > li.link.authorization-link > a"; // css
        const string createAccButtonSelector = "authorization-link"; //class
        const string myCartSelector = "#html-body > div.page-wrapper > div.header-placeholder > div.page-header.page-header-v4 > header > div.panel.wrapper > div > div > div.minicart-wrapper.quickcart-wrapper.minicart-weltpixel > a"; // css
        const string myCartAreaSelector = "quickcart-top"; // class
        const string searchSelector = "#html-body > div.page-wrapper > div.header-placeholder > div.page-header.page-header-v4 > header > div.panel.wrapper > div > div > div.block.block-search.search-visible-md.minisearch-v2 > div > i"; // css
        const string cookieAcceptSelector = "#html-body > div.amgdprcookie-bar-template > div > div > div > button.amgdprcookie-button.-allow"; //css

        public LandingPage(IWebDriver driver) : base(driver)
        {
        }
        public void AcceptCookies()
        {
            driver.FindElement(By.CssSelector(cookieAcceptSelector)).Click();
        }

        public void LoginNavigate()
        {
            var authButton = driver.FindElement(By.CssSelector(authButtonSelector));
            authButton.Click();
        }

        public void CreateAccount()
        {
            var createAccButton = driver.FindElement(By.ClassName(createAccButtonSelector));
            createAccButton.Click();
        }

        public void MyCart()
        {
            var cartBtnSelector = driver.FindElement(By.CssSelector(myCartSelector));
            cartBtnSelector.Click();
        }
        public string CheckCartPage()
        {
            return driver.FindElement(By.ClassName(myCartAreaSelector)).Text;
        }

        public void SearchPage()
        {
            var searchBtnSelector = driver.FindElement(By.CssSelector(searchSelector));
            searchBtnSelector.Click();            
        }
    }

    
}
