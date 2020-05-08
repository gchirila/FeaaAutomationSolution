

using System.Security.AccessControl;
using OpenQA.Selenium;

namespace AutomationSolution.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }



        private By addresses = By.CssSelector("[data-test=addresses]");
        private IWebElement BtnAddresses => driver.FindElement(addresses);

        public AddressesPage NavigateToAddressesPage()
        {
            BtnAddresses.Click();
            return new AddressesPage(driver);
        }

    }
}
