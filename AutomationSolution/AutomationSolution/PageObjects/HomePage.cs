

using System.Security.AccessControl;
using AutomationSolution.Controls;
using OpenQA.Selenium;

namespace AutomationSolution.PageObjects
{
    public class HomePage
    {
        private static IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public LoggedInMenuItemControl loggedInMenuItemControl => new LoggedInMenuItemControl(driver);
    }
}
