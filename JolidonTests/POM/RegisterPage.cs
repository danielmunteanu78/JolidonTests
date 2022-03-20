using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JolidonTests.POM
{
    class RegisterPage : BasePage
    {
                   
        const string registerTextSelector = "#maincontent > div.page-title-wrapper > h1 > span"; //css;
        const string firstNameLabelSelector = "#form-validate > fieldset.fieldset.create.info > div.field.field-name-firstname.required > label";//css
        const string firstNameInputSelector = "firstname"; //id
        const string firstNameErrorSelector = "firstname-error";//id
        const string lastNameInputSelector = "lastname"; //id
        const string lastNameErrorSelector = "lastname-error";//id
        const string emailInputSelector = "email_address"; // id
        const string emailErrorSelector = "email_address-error"; //id
        const string passInputSelector = "password"; // id
        const string passStrengthMsgSelector = "password-strength-meter-label";//id
        const string passErrorMsgSelector = "password-error";//id
        const string passRepeatInputSelector = "password-confirmation"; //id
        const string newsletterSelector = "is_subscribed"; //id
        const string showPassSelector = "show-password"; //id
        const string rememberPassSelector = "remember_meLEGWAfWXsV"; // id
        const string createAccountBtn = "#form-validate > div > div.primary > button > span"; //css
        const string cookieAcceptSelector = "#html-body > div.amgdprcookie-bar-template > div > div > div > button.amgdprcookie-button.-allow"; //css
        const string duplicateAccountErrMsgSelector = "#maincontent > div.page.messages > div:nth-child(2) > div > div > div";//css



        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }
        public string CheckPage()
        {
            return driver.FindElement(By.CssSelector(registerTextSelector)).Text;
        }
        public string CheckFirstName()
        {
            return driver.FindElement(By.CssSelector(firstNameLabelSelector)).Text;
        }
        public string FirstNameErrMsg()
        {
            return driver.FindElement(By.Id(firstNameErrorSelector)).Text;
        }
        public string LastNameErrMsg()
        {
            return driver.FindElement(By.Id(lastNameErrorSelector)).Text;
        }
        public string EmailErrMsg()
        {
            return driver.FindElement(By.Id(emailErrorSelector)).Text;
        }
        public string PasswordErrMsg()
        {
            return driver.FindElement(By.Id(passErrorMsgSelector)).Text;
        }

        public string DuplicateAccountErrorMsg()
        {
            return driver.FindElement(By.CssSelector(duplicateAccountErrMsgSelector)).Text;
        }

        public void AcceptCookies()
        {
            driver.FindElement(By.CssSelector(cookieAcceptSelector)).Click();
        }       

        public void Register(string fName, string lName, string email, string pass, string confirmPass = null)
        {
            
            var firstNameInput = driver.FindElement(By.Id(firstNameInputSelector));
            firstNameInput.Clear();
            firstNameInput.SendKeys(fName);            
            var lastNameInput = driver.FindElement(By.Id(lastNameInputSelector));
            lastNameInput.Clear();
            lastNameInput.SendKeys(lName);
            var newsLetter = driver.FindElement(By.Id(newsletterSelector));
            newsLetter.Submit();
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passInput = driver.FindElement(By.Id(passInputSelector));
            passInput.Clear();
            passInput.SendKeys(pass);
            var passRepeat = driver.FindElement(By.Id(passRepeatInputSelector));
            passRepeat.Clear();
            passRepeat.SendKeys(pass);
            var showPass = driver.FindElement(By.Id(showPassSelector));
            showPass.Click();
            Thread.Sleep(1000);
            var createAccount = driver.FindElement(By.CssSelector(createAccountBtn));
            createAccount.Submit();
           /* if (fName.Length == 0)
            {
                Assert.AreEqual("Acesta este un camp obligatoriu.", driver.FindElement(By.Id(firstNameErrorSelector)).Text);
            }*/            
        }           
       
    }
}
