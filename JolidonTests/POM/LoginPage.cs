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
        const string passwordRembBtn = "remember_meK3kT0BGMAh"; //id
        const string submitButton = "#send2 > span"; // css
        const string cookieAcceptSelector = "#html-body > div.amgdprcookie-bar-template > div > div > div > button.amgdprcookie-button.-allow"; //css

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public string CheckPage()
        {
            var authPageEl = driver.FindElement(By.CssSelector(authPageText));
            return authPageEl.Text;
        }

        public void AcceptCookies()
        {
            driver.FindElement(By.CssSelector(cookieAcceptSelector)).Click();
        }

        public void Login(string user, string passw)
        {
            var usernameInputElement = driver.FindElement(By.CssSelector(emailadressInput));
            usernameInputElement.Clear();
            usernameInputElement.SendKeys(user);
            var passwordInputElement = driver.FindElement(By.CssSelector(passwordInput));
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(passw);
            var submitButtonElement = driver.FindElement(By.CssSelector(submitButton));
            submitButtonElement.Submit();
        }
    }
}
