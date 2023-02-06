using System;
using BuggyUITest.Drivers;
using BuggyUITest.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BuggyUITest.Hook
{
    [Binding]
    internal class TestInitialize
	{
        private readonly ScenarioContext _scenarioContext;

        public TestInitialize(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;

        }

		[BeforeScenario]
		public void StartWebDriver()
		{
			WebDriverLibrary webDriverLibrary = new WebDriverLibrary(_scenarioContext);
			_scenarioContext.Set(webDriverLibrary, "WebDriverLibrary"); 

        }

        [AfterScenario]
        public void KillDriver()
        {
            IWebDriver driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            TakeScreenShot.takeScreenShot(driver, _scenarioContext.ScenarioInfo.Title);
            driver.Quit();
        }

    }
}

