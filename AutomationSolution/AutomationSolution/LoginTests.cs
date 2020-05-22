using System.Threading;
using AutomationSolution.Controls;
using AutomationSolution.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationSolution
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            var menuItem = new LoggedOutMenuItemControl(driver);
            loginPage = menuItem.NavigateToLoginPage();
            loginPage = new LoginPage(driver);
        }

        [TestMethod]
        public void Login_CorrectEmail_CorrectPassword()
        {
            var homePage = loginPage.LoginApplication("asd@asd.asd", "asd");

            var expectedResult = "asd@asd.asd";
            var actualResult = homePage.loggedInMenuItemControl.UserEmail;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Login_IncorrectEmail_CorrectPassword()
        {
            var homePage = loginPage.LoginApplication("asd12321414@asd12321.asd312", "asd");

            var expectedResult = "Bad email or password.";
            var actualResults = loginPage.IncorrectCredentialsMessage; 

            Assert.AreEqual(expectedResult, actualResults);
        }

        [TestMethod]
        public void Login_CorrectEmail_IncorrectPassword()
        {
            loginPage.LoginApplication("asd@asd.asd", "asd1234");

            var expectedResult = "Bad email or password.";
            var actualResults = loginPage.IncorrectCredentialsMessage;

            Assert.AreEqual(expectedResult, actualResults);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}