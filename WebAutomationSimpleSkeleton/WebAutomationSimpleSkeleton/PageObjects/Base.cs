using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebAutomationSimpleSkeleton
{
    public class Base
    {
        protected IWebDriver webDriver;

        public Base(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void ClickOn(By selectorType)
        {
            FindElement(selectorType).Click();
        }

        public void WaitForElementOnPage(By selectorType, int timeout = 15)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => webDriver.FindElement(selectorType));
        }

        public void ClearAndFillField(By selectorType, string keys)
        {
            ClearField(selectorType);
            SendKeys(selectorType, keys);
        }

        public void AssertTextFieldEqualTo(By selectorType, string expectedText)
        {
            Assert.AreEqual(expectedText, FindElement(selectorType).Text);
        }

        public void SelectElement(By selectorType, string elementToSelect)
        {
            new SelectElement(FindElement(selectorType)).SelectByText(elementToSelect);
        }

        public void SetCheckboxChecked(By selectorType, bool isChecked)
        {
            if (FindElement(selectorType).Selected != isChecked)
            {
                FindElement(selectorType).Click();
            }
        }

        public void GoToUrl(string urlAddress)
        {
            webDriver.Navigate().GoToUrl(urlAddress);
        }

        public void Hover(By locator)
        {
            Actions action = new Actions(webDriver);
            action.MoveToElement(FindElement(locator)).Perform();
        }

        public void ScrollTo(By locator)
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);",
                webDriver.FindElement(locator));
        }

        private IWebElement FindElement(By selectorType)
        {
            WaitForElementOnPage(selectorType);
            return webDriver.FindElement(selectorType);
        }

        private void ClearField(By selectorType)
        {
            webDriver.FindElement(selectorType).Clear();
        }

        private void SendKeys(By selectorType, String keys)
        {
            webDriver.FindElement(selectorType).SendKeys(keys);
        }
    }
}
