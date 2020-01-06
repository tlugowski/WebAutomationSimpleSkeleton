using NUnit.Framework;
using WebAutomationSimpleSkeleton.Contracts;
using WebAutomationSimpleSkeleton.PageObjects;

namespace WebAutomationSimpleSkeleton.Tests
{
    [TestFixture]
    public class WebPageTest : BaseTests
    {
        [Test]
        public void GoogleWebPageTest()
        {
            IFirstPage testFirstPage = new FirstPage(webDriver);
            ISecondPage testSecondPage = new SecondPage(webDriver);
            testFirstPage.GoToGoogleSite();
            testFirstPage.SearchText();
            testSecondPage.CheckSearchResult();
        }
    }
}
