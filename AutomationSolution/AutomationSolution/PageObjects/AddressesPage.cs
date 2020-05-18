using System;
using AutomationSolution.PageObjects.AddAdressPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution.PageObjects
{
    public class AddressesPage
    {
        private IWebDriver driver;

        public AddressesPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By newAddress = By.XPath("//a[@data-test='create']");
        private IWebElement BtnNewAddress => driver.FindElement(newAddress);

        public AddAddressPage NavigateToAddAddressPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(newAddress));
            BtnNewAddress.Click();
            return new AddAddressPage(driver);
        }
    }
}