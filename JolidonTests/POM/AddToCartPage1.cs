using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JolidonTests.POM
{
    public class AddToCartPage1 : BasePage
    {
        const string menPageLabel = "#ui-id-5 > span.mm-subcategory-title.underline-megamenu"; // css
        const string menTshirtLabel = "#layer-product-list > div.products.wrapper.grid.products-grid > ol > li:nth-child(1) > div > div.product_image > a > span > span > img"; //css
        const string sizeXLButton = "option-label-marime-178-item-24070";//id
        const string addToCartButton = "product-addtocart-button";//id
        const string cookieAcceptSelector = "#html-body > div.amgdprcookie-bar-template > div > div > div > button.amgdprcookie-button.-allow"; //css
        const string cartPage = "#minicart-content-wrapper > div.block-content.block-content-quickcart";//css
        const string topCartPage = "quickcart-top";//class
        const string closeCartButton = "btn-minicart-close"; //id
        const string myCartSelector = "#html-body > div.page-wrapper > div.page-header.page-header-v4.sticky-header > header > div.panel.wrapper > div > div > div.minicart-wrapper.quickcart-wrapper.minicart-weltpixel > a"; // css
        const string deleteButton = "#mini-cart > li > div > div > div.product.actions > div > a > span"; //css
        const string okDeleteButton = "#html-body > div.modals-wrapper > aside.modal-popup.confirm._show > div.modal-inner-wrap > footer > button.action-primary.action-accept";//css
        const string emptyCartMsg = "#minicart-content-wrapper > div.block-content.block-content-quickcart > strong.subtitle.empty.no-items-position";//css

        public AddToCartPage1(IWebDriver driver) : base(driver)
        {
        }
        public void AcceptCookies()
        {
            driver.FindElement(By.CssSelector(cookieAcceptSelector)).Click();
        }
        public void AddToCartMen()
        {
            var menPgLabel = driver.FindElement(By.CssSelector(menPageLabel));
            menPgLabel.Click();
            var menTsLabel = driver.FindElement(By.CssSelector(menTshirtLabel));
            menTsLabel.Click();
            var sizeXLBtn = Utils.WaitForElement(driver,1, By.Id(sizeXLButton));
            sizeXLBtn.Click();
            var addToCartBtn = driver.FindElement(By.Id(addToCartButton));
            addToCartBtn.Submit();           
            var delBtn = Utils.WaitForElement(driver,2,By.CssSelector(deleteButton));
             delBtn.Click();          

            var okDelBtn = Utils.WaitForElement( driver,2,By.CssSelector(okDeleteButton));
            okDelBtn.Click();
        }       

        public string EmptyCartCheck()
        {
            return Utils.WaitForElement(driver,2,By.CssSelector(emptyCartMsg)).Text;
        }
    }
}
