using System;
using System.Threading;
using AutomationSolution.PageObjects;
using AutomationSolution.PageObjects.AddAdressPage;
using AutomationSolution.PageObjects.AddAdressPage.InputData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationSolution
{
    [TestClass]
    public class AddAddressTest
    {
        private IWebDriver driver;
        private AddAddressPage addAddressPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            driver.FindElement(By.Id("sign-in")).Click();
            var loginPage = new LoginPage(driver);
            var homePage = loginPage.LoginApplication("asd@asd.asd", "asd");
            var addressesPage = homePage.NavigateToAddressesPage();
            addAddressPage = addressesPage.NavigateToAddAddressPage();
        }

        [TestMethod]
        public void Should_Add_Address_Successfully()
        {
            var addAddressBo = new AddAddressBO
            {
                LastName = "George Changed"
            };
            var addressDetailsPage = addAddressPage.CreateAddress(addAddressBo);
            Assert.AreEqual("Address was successfully created.", addressDetailsPage.SuccessfullyCreatedText);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}