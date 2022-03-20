using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.POM
{
    public class LandingPage : BasePage
    {
        const string homeButtonSelector = "logo";//class
        const string authButtonSelector = "#html-body > div.page-wrapper > div.header-placeholder > div.page-header.page-header-v4 > header > div.panel.wrapper > div > ul.header.links > li.link.authorization-link > a"; // css
        const string createAccButtonSelector = "#html-body > div.page-wrapper > div.header-placeholder > div.page-header.page-header-v4 > header > div.panel.wrapper > div > ul.header.links > li:nth-child(3)"; //css
        const string myCartSelector = "#html-body > div.page-wrapper > div.header-placeholder > div.page-header.page-header-v4 > header > div.panel.wrapper > div > div > div.minicart-wrapper.quickcart-wrapper.minicart-weltpixel > a"; // css
        const string myCartAreaSelector = "quickcart-top"; // class
        const string searchSelector = "#html-body > div.page-wrapper > div.header-placeholder > div.page-header.page-header-v4 > header > div.panel.wrapper > div > div > div.block.block-search.search-visible-md.minisearch-v2 > div > i"; // css
        const string cookieAcceptSelector = "#html-body > div.amgdprcookie-bar-template > div > div > div > button.amgdprcookie-button.-allow"; //css
        const string closeSearchSelector = "#search-mod > div.close-sec.search-visible-md > a";//css

        public LandingPage(IWebDriver driver) : base(driver)
        {
        }
        public void AcceptCookies()
        {
            driver.FindElement(By.CssSelector(cookieAcceptSelector)).Click();
        }

        public void HomeButton()
        {
            driver.FindElement(By.ClassName(homeButtonSelector)).Click();           
        }

        public void LoginNavigate()
        {
            driver.FindElement(By.CssSelector(authButtonSelector)).Click();            
        }

        public void CreateAccount()
        {
          driver.FindElement(By.CssSelector(createAccButtonSelector)).Click();          
        }

        public void MyCart()
        {
            driver.FindElement(By.CssSelector(myCartSelector)).Click();          
        }
        public string CheckCartPage()
        {
            return driver.FindElement(By.ClassName(myCartAreaSelector)).Text;
        }

        public void SearchPage()
        {
            driver.FindElement(By.CssSelector(searchSelector)).Click();
            Utils.WaitForElement(driver, 10, By.CssSelector(closeSearchSelector)).Click();
        }
    }

    
}
