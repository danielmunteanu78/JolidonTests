using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.POM
{
    class LoginPage:BasePage
    {
        const string authPageText = "#maincontent > div.page-title-wrapper > h1 > span"; // css
        const string emailadressLabel = "#login-form > fieldset > div.field.email.required > label > span"; // css
        const string emailadressInput = "#email"; //css
        const string emailadressError = "email-error"; // id
        const string passwordLabel = "#login-form > fieldset > div.field.password.required > label > span"; // css
        const string passwordInput = "#pass"; //css
        const string passwordError = "pass-error"; // id
        const string passwordShowBtn = "show-password"; //id
        const string passwordAreaButton = "remember-me-box";//id
        const string passwordRembBtn = "checkbox"; // class
        const string submitButton = "#send2 > span"; // css
        const string cookieAcceptSelector = "#html-body > div.amgdprcookie-bar-template > div > div > div > button.amgdprcookie-button.-allow"; //css
        const string accountLoginErrorMsg = "#maincontent > div.page.messages > div:nth-child(2) > div > div > div";//css

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public string CheckPage()
        {
            return driver.FindElement(By.CssSelector(authPageText)).Text;            
        }

        public string EmailAdressError()
        {
            return driver.FindElement(By.Id(emailadressError)).Text;
        }

        public string PasswordErrorMsg()
        {
            return driver.FindElement(By.Id(passwordError)).Text;
        }

        public string AccountLoginErrMsg()
        {
            return driver.FindElement(By.CssSelector(accountLoginErrorMsg)).Text;
        }

        public void AcceptCookies()
        {
           Utils.WaitForElement(driver,1,By.CssSelector(cookieAcceptSelector)).Click();
        }

        public void Login(string user, string passw)
        {
            var usernameInputElement = driver.FindElement(By.CssSelector(emailadressInput));
            usernameInputElement.Clear();
            usernameInputElement.SendKeys(user);
            var passwordInputElement = driver.FindElement(By.CssSelector(passwordInput));
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(passw);
            driver.FindElement(By.Id(passwordShowBtn)).Click();
            var passAreaBtn = driver.FindElement(By.Id(passwordAreaButton));
            var passRembBtn = passAreaBtn.FindElement(By.ClassName(passwordRembBtn));
            passRembBtn.Click();
            var submitButtonElement = driver.FindElement(By.CssSelector(submitButton));
            submitButtonElement.Submit();
        }
    }
}
