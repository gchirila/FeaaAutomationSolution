using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationSolution.PageObjects
{
    public class AddAddressPage
    {
        private IWebDriver driver;

        public AddAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By firstName = By.Name("address[first_name]");
        private IWebElement TxtFirstName => driver.FindElement(firstName);

        private By lastName = By.Id("address_last_name");
        private IWebElement TxtLastName => driver.FindElement(lastName);

        private By address1 = By.Id("address_street_address");
        private IWebElement TxtAddress1 => driver.FindElement(address1);

        private By city = By.Id("address_city");
        private IWebElement TxtCity => driver.FindElement(city);

        private By state = By.XPath("//select[@name='address[state]']");
        private IWebElement DdlState => driver.FindElement(state);

        private By zipCode = By.Id("address_zip_code");
        private IWebElement TxtZipCode => driver.FindElement(zipCode);

        private By country = By.XPath("//input[@name='address[country]']");
        private IList<IWebElement> LstCountry => driver.FindElements(country);

        private By color = By.Id("address_color");
        private IWebElement ClColor => driver.FindElement(color);

        private By createAddress = By.CssSelector("[data-test=submit]");
        private IWebElement BtnCreateAddress => driver.FindElement(createAddress);

        public void CreateAddress()
        {
            TxtFirstName.SendKeys("test george");
            TxtLastName.SendKeys("test george");
            TxtAddress1.SendKeys("test george");
            TxtCity.SendKeys("test george");
            var selectState = new SelectElement(DdlState);
            selectState.SelectByText("District of Columbia");
            TxtZipCode.SendKeys("test george");
            LstCountry[1].Click();
            var js = (IJavaScriptExecutor) driver;
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", ClColor, "#FF0000");
            //BtnCreateAddress.Click();
        }

    }
}