using System.Configuration;
using System.Windows.Forms;
using OpenQA.Selenium;
using WebAutomationSimpleSkeleton.Contracts;

namespace WebAutomationSimpleSkeleton.Tests
{
    public class FirstPage : Base, IFirstPage
    {
        public FirstPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        readonly By GoogleIcon = By.CssSelector("#hplogo");
        readonly By SearchTextBox = By.CssSelector(".gLFyf");
        readonly By ButtonSearch = By.CssSelector(".gNO89b");


        public bool SearchText()
        {
            ClearAndFillField(SearchTextBox, "tatata");
            SendKeys.SendWait("{ENTER}");
            return true;
        }

        public void GoToGoogleSite()
        {
            GoToUrl(ConfigurationManager.AppSettings["url"]);
            WaitForElementOnPage(SearchTextBox);
        }
    }
}
