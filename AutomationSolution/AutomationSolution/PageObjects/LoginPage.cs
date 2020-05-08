using System.CodeDom;
using OpenQA.Selenium;

namespace AutomationSolution.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By email = By.CssSelector("input[data-test='email']");
        private IWebElement TxtEmail => driver.FindElement(email);

        private By password = By.CssSelector("input[type='password']");
        private IWebElement TxtPassword => driver.FindElement(password);

        private By login => By.XPath("//input[@value='Sign in']");
        private IWebElement BtnLogin => driver.FindElement(login);

        public HomePage LoginApplication(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
            return new HomePage(driver);
        }
    }
}