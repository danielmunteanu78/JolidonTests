using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JolidonTests.POM
{
    public class AddToCartPage2 : BasePage
    {
        public AddToCartPage2(IWebDriver driver) : base(driver)
        {
        }

        const string womenLabelSelector = "//*[@id='ui-id-4']/span[2]"; //Xpath
        const string bathingSuitLabelSelector = "#layer-product-list > div.products.wrapper.grid.products-grid > ol > li:nth-child(17) > div > div.product.details.product-item-details > h2 > a"; //Css
        const string sizeLabelSelecor = "#option-label-marime-178-item-24120";//Css
        const string addToCartButtonSelector = "product-addtocart-button";//Id
        const string checkoutButtonSelector = "top-cart-btn-checkout"; //Id
        const string firstNameFieldSelector = "#D6AKGE8"; //Css
        const string lastNameFieldSelector = "#WGFGY77"; //Css
        const string adressAreaSelector = "#shipping-new-address-form > fieldset > div > div > div"; //css
        const string adressFieldSelector = "input-text";//Class
        const string countyAreaSelector = "#shipping-new-address-form > div:nth-child(5) > div";//css
        const string countyFieldSelector = "select";//Class
        const string townAreaSelector = "#shipping-new-address-form > div:nth-child(7) > div"; //css
        const string townFieldSelector = "input-text"; //Class
        const string postalCodeAreaSelector = "#shipping-new-address-form > div:nth-child(8) > div"; //css
        const string postaCodeFieldSelector = "input-text"; //Class
        const string phoneAreaSelector = "#shipping-new-address-form > div:nth-child(9) > div";//css
        const string phoneFieldSelector = "input-text"; //Class
        const string messageAreaSelector = "#co-payment-form > fieldset > div.fieldset.swissup-checkout-fields > div.fieldset > div > div"; //css
        const string messageFieldSelector = "admin__control-textarea"; //Class
        const string agrrementCheckButton = "#agreement_checkmo_1"; //Css


        public void AddToCartWomen()
        {
            driver.FindElement(By.XPath(womenLabelSelector)).Click();
            Utils.WaitForElement(driver, 2, By.CssSelector(bathingSuitLabelSelector)).Click();
            Utils.WaitForElement(driver,2, By.CssSelector(sizeLabelSelecor)).Click();
            driver.FindElement(By.Id(addToCartButtonSelector)).Click();
            Utils.WaitForElement(driver, 2, By.Id(checkoutButtonSelector)).Click();           
        }

        public void EndOrder(string adress, int countyIndex, string town, string postalCode, string phone, string message)
        {
            var shipAreaSel = Utils.WaitForElement(driver, 5, By.CssSelector(adressAreaSelector));
            var adressFldSel = shipAreaSel.FindElement(By.ClassName(adressFieldSelector));           
            adressFldSel.Clear();
            adressFldSel.SendKeys(adress);
            var countyAreaSel = driver.FindElement(By.CssSelector(countyAreaSelector));
            var countyFieldSel = countyAreaSel.FindElement(By.ClassName(countyFieldSelector));
            countyFieldSel.Click();
            var townAreaSel = driver.FindElement(By.CssSelector(townAreaSelector));
            var townFieldSel = townAreaSel.FindElement(By.ClassName(townFieldSelector));
            townFieldSel.Clear();
            townFieldSel.SendKeys(town);
            var postCodAreaSel = driver.FindElement(By.CssSelector(postalCodeAreaSelector));
            var postCodFieldSel = postCodAreaSel.FindElement(By.ClassName(postaCodeFieldSelector));
            postCodFieldSel.Clear();
            postCodFieldSel.SendKeys(postalCode);
            var phoneAreaSel = driver.FindElement(By.CssSelector(phoneAreaSelector));
            var phoneFieldSel = phoneAreaSel.FindElement(By.ClassName(phoneFieldSelector));
            phoneFieldSel.Clear();
            phoneFieldSel.SendKeys(phone);
            var messageAreaSel = driver.FindElement(By.CssSelector(messageAreaSelector));
            var messageFieldSel = messageAreaSel.FindElement(By.ClassName(messageFieldSelector));
            messageFieldSel.Clear();
            messageFieldSel.SendKeys(message);
            var agreementCheckBtn = driver.FindElement(By.CssSelector(agrrementCheckButton));
            agreementCheckBtn.Submit();

        }        
    }
}
