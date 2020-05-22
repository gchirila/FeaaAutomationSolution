using AutomationSolution.Controls;
using AutomationSolution.PageObjects;
using AutomationSolution.PageObjects.AddAdressPage;
using AutomationSolution.PageObjects.AddAdressPage.InputData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationSolution
{
    [TestClass]
    public class DestroyAddressTests
    {
        private IWebDriver driver;
        private AddressesPage addressesPage;
        private AddAddressBO addAddressBo = new AddAddressBO();

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            var menuItem = new LoggedOutMenuItemControl(driver);
            var loginPage = menuItem.NavigateToLoginPage();
            var homePage = loginPage.LoginApplication("asd@asd.asd", "asd");
            addressesPage = homePage.loggedInMenuItemControl.NavigateToAddressesPage();
            var addAddressPage = addressesPage.NavigateToAddAddressPage();
            var addressDetailsPage = addAddressPage.CreateAddress(addAddressBo);
            addressesPage = addressDetailsPage.NavigateToAddressesPage();
        }

        [TestMethod]
        public void Should_Delete_Address()
        {
            addressesPage.DeleteAddress(addAddressBo);
            Assert.AreEqual("Address was successfully destroyed.", addressesPage.SuccessfullyDestroyedMessage);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}