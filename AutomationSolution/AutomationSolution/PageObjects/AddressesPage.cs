using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutomationSolution.PageObjects.AddAdressPage;
using AutomationSolution.PageObjects.AddAdressPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution.PageObjects
{
    public class AddressesPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddressesPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(newAddress));
        }

        private By newAddress = By.XPath("//a[@data-test='create']");
        private IWebElement BtnNewAddress => driver.FindElement(newAddress);

        private By addresses = By.CssSelector("tbody tr");
        private IList<IWebElement> LstAddresses => driver.FindElements(addresses);

        private By destroy = By.CssSelector("[data-method=delete]");
        //firstMethod -- not recomanded
        private IWebElement BtnDestroyV1 => LstAddresses[0].FindElement(destroy);
        //second method -- linq
        private IWebElement BtnDestroyV2(AddAddressBO addAddressBo) => LstAddresses.FirstOrDefault(element => element.Text.Contains(addAddressBo.FirstName))
                                                                                ?.FindElement(destroy);
        //third method
        private IWebElement BtnDestroyV3(AddAddressBO addAddressBo)
        {
            foreach (var element in LstAddresses)
            {
                if (element.Text.Contains(addAddressBo.FirstName))
                {
                    return element;
                }
                break;
            }

            return null;
        }

        private By successfullyDestroyed = By.CssSelector("[data-test=notice]");
        private IWebElement LblSuccessfullyDestroyed => driver.FindElement(successfullyDestroyed);
        
        public void DeleteAddress(AddAddressBO addAddressBo)
        {
            BtnDestroyV2(addAddressBo).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public AddAddressPage NavigateToAddAddressPage()
        {
            BtnNewAddress.Click();
            return new AddAddressPage(driver);
        }

        public string SuccessfullyDestroyedMessage => LblSuccessfullyDestroyed.Text;
    }
}