using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.Linq;

namespace WebAutomationSimpleSkeleton.Tests
{
    [TestFixture]
    public class BaseTests
    {
        protected IWebDriver webDriver { get; set; }

        [SetUp]
        public void Initalize()
        {
            string browser = ConfigurationManager.AppSettings["Browser"];
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseTest()
        {
            String mainWindow = webDriver.CurrentWindowHandle;
            webDriver.WindowHandles.Where(w => w != mainWindow).ToList()
           .ForEach(w =>
           {
               webDriver.SwitchTo().Window(w);
               webDriver.Close();
           });
            webDriver.SwitchTo().Window(mainWindow).Close();
        }
    }
}
