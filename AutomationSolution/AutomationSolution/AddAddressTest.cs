using System.Threading;
using AutomationSolution.PageObjects;
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
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            driver.FindElement(By.Id("sign-in")).Click();
            Thread.Sleep(1000);
            var homePage = loginPage.LoginApplication("asd@asd.asd", "asd");
            Thread.Sleep(1000);
            var addressesPage = homePage.NavigateToAddressesPage();
            Thread.Sleep(1000);
            addAddressPage = addressesPage.NavigateToAddAddressPage();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void Should_Add_Address_Successfully()
        {
            addAddressPage.CreateAddress();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}