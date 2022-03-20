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
            AddToCartPage atc = new AddToCartPage(_driver);
            Thread.Sleep(500);            
            atc.AcceptCookies();
            atc.AddToCartMen();
            Thread.Sleep(1000);
           Assert.AreEqual("NU AVETI NICI UN ARTICOL ÎN COSUL DE CUMPARATURI", atc.EmptyCartCheck());           
        }       
    }
}
