using BuggyUITest.Drivers;
using BuggyUITest.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BuggyUITest.Steps
{
    [Binding]
    public class BaseStep
    {
        protected IWebDriver _driver;
        protected HomePage homePage;
        protected RegisterPage registerPage;

        private readonly ScenarioContext _scenarioContext;

        public BaseStep(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            IWebDriver driver;
            if (_scenarioContext.ContainsKey("WebDriver"))
                driver = _scenarioContext.Get<WebDriver>("WebDriver");
            else
            {
                string browser = (string)_scenarioContext.ScenarioInfo.Arguments["Browsers"];
                if (browser == null)
                    browser = "chrome";

                driver = _scenarioContext.Get<WebDriverLibrary>("WebDriverLibrary").Setup(browser);
            }
            _driver = driver;
            homePage = new HomePage(driver);
            registerPage = new RegisterPage(driver);

        }
    }
}
