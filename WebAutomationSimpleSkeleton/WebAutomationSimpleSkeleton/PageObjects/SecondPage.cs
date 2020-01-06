using OpenQA.Selenium;
using WebAutomationSimpleSkeleton.Contracts;

namespace WebAutomationSimpleSkeleton.PageObjects
{
    public class SecondPage : Base, ISecondPage
    {
        public SecondPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        readonly By ButtonAll = By.CssSelector(".hdtb-imb");

        public void CheckSearchResult()
        {
            WaitForElementOnPage(ButtonAll);
        }
    }
}
