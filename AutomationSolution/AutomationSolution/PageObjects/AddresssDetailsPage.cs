using OpenQA.Selenium;

namespace AutomationSolution.PageObjects
{
    public class AddresssDetailsPage
    {
        private IWebDriver driver;

        public AddresssDetailsPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By succesfullyCreated = By.CssSelector("[data-test=notice]");
        private IWebElement LblSuccessfullyCreate => driver.FindElement(succesfullyCreated);

        public string SuccessfullyCreatedText => LblSuccessfullyCreate.Text;
    }
}