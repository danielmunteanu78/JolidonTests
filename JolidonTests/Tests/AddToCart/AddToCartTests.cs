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
        [Order(1), Category("Add to cart")]
        //[Parallelizable(ParallelScope.All)]
    public void AddToCartTest1() // add a product and then delet it from the cart
        {            
            _driver.Navigate().GoToUrl(url);
            AddToCartPage1 atc = new AddToCartPage1(_driver);                        
            atc.AcceptCookies();
            atc.AddToCartMen();           
           Assert.AreEqual("NU AVETI NICI UN ARTICOL ÎN COSUL DE CUMPARATURI", atc.EmptyCartCheck());
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }

        [Test]
        [Order(2), Category("Add to cart")]
        //[Parallelizable(ParallelScope.All)]
        public void AddToCartTest2() // login to a valid account and adding 1 product to cart
        {           
            _driver.Navigate().GoToUrl(url);
            LandingPage lp = new LandingPage(_driver);
            LoginPage lg = new LoginPage(_driver);
            AddToCartPage2 add2 = new AddToCartPage2(_driver);
            lp.AcceptCookies();
            
            lp.LoginNavigate();
            lg.Login("anca.bratu@yahoo.com", "Ab234567$");
            add2.AddToCartWomen();
            add2.EndOrder("Micsunelelor 2",280, "Braila", "78000", "0755112233", "This is just a test !");
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }
    }   
}
