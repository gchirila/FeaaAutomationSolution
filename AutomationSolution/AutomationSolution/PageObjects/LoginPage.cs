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

        private IWebElement TxtEmail()
        {
            return driver.FindElement(By.CssSelector("input[data-test='email']"));
        }

        private IWebElement TxtPassword()
        {
            return driver.FindElement(By.CssSelector("input[type='password']"));
        }

        private IWebElement BtnLogin()
        {
            return driver.FindElement(By.XPath("//input[@value='Sign in']"));
        }

        public void LoginApplication(string email, string password)
        {
            TxtEmail().SendKeys(email);
            TxtPassword().SendKeys(password);
            BtnLogin().Click();
        }
    }
}