using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using TechTalk.SpecFlow;

namespace BuggyUITest.Drivers
{
	internal class WebDriverLibrary
	{
        private readonly ScenarioContext _scenarioContext;

        public WebDriverLibrary(ScenarioContext scenarioContext) => this._scenarioContext = scenarioContext;

        public IWebDriver Setup(string browserName)
        {
            dynamic capability = GetBrowserOptions(browserName);
            //var driver = new RemoteWebDriver(new Uri("https://buggy.justtestit.org"), capability.ToCapabilities());
            var driver = GetLocalWebDriver(browserName);

            _scenarioContext.Set(driver, "WebDriver");

            return driver;
        }


        private dynamic GetBrowserOptions(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return new ChromeOptions();
                case "firefox":
                    return new FirefoxOptions();
                default:
                    break;
            }
            if (browserName == "MirosoftEdge")
                return new EdgeOptions();
            if (browserName == "Safari")
                return new SafariOptions();

            return null;
        }

        private dynamic GetLocalWebDriver(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                default:
                    break;
            }
            if (browserName == "MirosoftEdge")
                return new EdgeDriver();
            if (browserName == "Safari")
                return new SafariDriver();

            return null;
        }
    }
}

