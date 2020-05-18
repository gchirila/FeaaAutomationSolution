using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(login));
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