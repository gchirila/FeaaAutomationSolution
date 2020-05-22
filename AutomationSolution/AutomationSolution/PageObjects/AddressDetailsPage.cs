using OpenQA.Selenium;

namespace AutomationSolution.PageObjects
{
    public class AddressDetailsPage
    {
        private IWebDriver driver;

        public AddressDetailsPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By succesfullyCreated = By.CssSelector("[data-test=notice]");
        private IWebElement LblSuccessfullyCreate => driver.FindElement(succesfullyCreated);

        private By list = By.CssSelector("[data-test=list]");
        private IWebElement BtnList => driver.FindElement(list);

        public AddressesPage NavigateToAddressesPage()
        {
            BtnList.Click();
            return new AddressesPage(driver);
        }

        public string SuccessfullyCreatedText => LblSuccessfullyCreate.Text;
    }
}