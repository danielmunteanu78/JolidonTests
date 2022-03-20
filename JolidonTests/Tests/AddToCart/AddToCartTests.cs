using JolidonTests.POM;
using JolidonTests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JolidonTests.Tests.AddToCart
{
    class AddToCartTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test]
    public void AddToCartTest1() // add a product and then delet it from the cart
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            AddToCartPage1 atc = new AddToCartPage1(_driver);
            Thread.Sleep(500);            
            atc.AcceptCookies();
            atc.AddToCartMen();
            Thread.Sleep(1000);
           Assert.AreEqual("NU AVETI NICI UN ARTICOL ÎN COSUL DE CUMPARATURI", atc.EmptyCartCheck());           
        }

        [Test]
        public void AddToCartTest2() // login to a valid account and adding 1 product to cart
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            LoginPage lg = new LoginPage(_driver);
            AddToCartPage2 add2 = new AddToCartPage2(_driver);
            lp.AcceptCookies();
            Thread.Sleep(500);
            lp.LoginNavigate();
            lg.Login("anca.bratu@yahoo.com", "Ab234567$");
            add2.AddToCartWomen();
            add2.EndOrder("Micsunelelor 2",280, "Bucuresti", "78000", "0755112233", "This is just a test !");
        }
    }   
}
