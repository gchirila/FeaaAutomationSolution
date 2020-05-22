using System;
using System.Collections.Generic;
using System.Drawing.Text;
using AutomationSolution.PageObjects.AddAdressPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution.PageObjects.AddAdressPage
{
    public class AddAddressPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddAddressPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
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

        public AddressDetailsPage CreateAddress(AddAddressBO addAddressBo)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(firstName));
            TxtFirstName.SendKeys(addAddressBo.FirstName);
            TxtLastName.SendKeys(addAddressBo.LastName);
            TxtAddress1.SendKeys(addAddressBo.Address1);
            TxtCity.SendKeys(addAddressBo.City);
            var selectState = new SelectElement(DdlState);
            selectState.SelectByText(addAddressBo.State);
            TxtZipCode.SendKeys(addAddressBo.ZipCode);
            LstCountry[addAddressBo.Country].Click();
            var js = (IJavaScriptExecutor) driver;
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", ClColor, addAddressBo.Color);
            BtnCreateAddress.Click();
            return new AddressDetailsPage(driver);
        }

    }
}