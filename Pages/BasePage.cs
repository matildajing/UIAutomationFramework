using System;
using BuggyUITest.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;

namespace BuggyUITest.Pages
{
    public class BasePage
    {
        public readonly IWebDriver _webDriver;
        protected readonly ConfigurationDriver _configurationDriver;
        protected readonly ScenarioContext _scenarioContext;

        public BasePage(IWebDriver driver)
        {
            _configurationDriver = new ConfigurationDriver();
            _webDriver = driver;
        }

        public void goToPage(string pageUrl)
        {
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl($"{pageUrl}/");
        }

        public IWebElement FindElement(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return _webDriver.FindElement(by);
        }
    }
}
