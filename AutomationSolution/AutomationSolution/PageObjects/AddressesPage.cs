using OpenQA.Selenium;

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
            BtnNewAddress.Click();
            return new AddAddressPage(driver);
        }
    }
}