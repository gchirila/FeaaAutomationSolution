using System;
using System.Threading;
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
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            driver.FindElement(By.Id("sign-in")).Click();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void Login_CorrectEmail_CorrectPassword()
        {
            loginPage.LoginApplication("asd@asd.asd", "asd");

            var expectedResult = "asd@asd.asd";
            var actualResult = driver.FindElement(By.CssSelector("span[data-test='current-user']")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Login_IncorrectEmail_CorrectPassword()
        {
            loginPage.LoginApplication("asd12321414@asd12321.asd312", "asd");

            var expectedResult = "Bad email or password.";
            var actualResults = driver.FindElement(By.XPath("//div[contains(@class,'alert')]")).Text;

            Assert.AreEqual(expectedResult, actualResults);
        }

        [TestMethod]
        public void Login_CorrectEmail_IncorrectPassword()
        {
            loginPage.LoginApplication("asd@asd.asd", "asd1234");

            var expectedResult = "Bad email or password.";
            var actualResults = driver.FindElement(By.XPath("//div[contains(@class,'alert')]")).Text;

            Assert.AreEqual(expectedResult, actualResults);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}