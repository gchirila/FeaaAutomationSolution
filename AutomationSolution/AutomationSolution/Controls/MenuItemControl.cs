using System;
using AutomationSolution.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution.Controls
{
    public class MenuItemControl
    {
        public IWebDriver driver;

        public MenuItemControl(IWebDriver browser)
        {
            driver = browser;
        }

        private By home = By.CssSelector("");
        private IWebElement BtnHome => driver.FindElement(home);
    }

    public class LoggedOutMenuItemControl: MenuItemControl
    {
        private By signIn = By.Id("sign-in");
        private IWebElement BtnSignIn => driver.FindElement(signIn);

        public LoggedOutMenuItemControl(IWebDriver browser) : base(browser)
        {
        }

        public LoginPage NavigateToLoginPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(signIn));
            BtnSignIn.Click();
            return new LoginPage(driver);
        }
    }

    public class LoggedInMenuItemControl : MenuItemControl
    {
        private By addreesses = By.CssSelector("");
        private IWebElement BtnAddresses => driver.FindElement(addreesses);

        private By signOut = By.CssSelector("");
        private IWebElement BtnSignOut => driver.FindElement(signOut);

        private By userEmail = By.CssSelector("span[data-test='current-user']");
        private IWebElement LblUserEmail => driver.FindElement(userEmail);

        public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
        {
        }

        public AddressesPage NavigateToAddressesPage()
        {
            BtnAddresses.Click();
            return new AddressesPage(driver);
        }

        public string UserEmail => LblUserEmail.Text;
    }
}