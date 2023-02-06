using System;
using BuggyUITest.Drivers;
using BuggyUITest.Pages;
using BuggyUITest.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyUITest.Steps
{
    [Binding]
    public class HomeSteps : BaseStep
    {

        private ScenarioContext _scenarioContext;

        public HomeSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on the base page of buggy")]
        public void GivenIAmOnTheHomePage()
        {
            homePage.GoToBasePage();
        }

        [When(@"I click Register button")]
        public void WhenISearchFor() => homePage.btnRegister().Click();

        [Then(@"I should login properly")]
        public void ThenCheckHi()
        {
            Assert.AreEqual(homePage.waitLogin(_scenarioContext.Get<string>("firstname")), true);
        }


        [When(@"I login with just username and (.*)")]
        public void ThenLogin(string password)
        {
            
            homePage.textboxLogin().SendKeys(_scenarioContext.Get<string>("username"));
            homePage.textboxPassword().SendKeys(password);
            homePage.btnLogin().Submit();

        }

        [Then(@"I should be directed to home page")]
        public void ThenRedirectToHomePage()
        {
            Assert.AreEqual(homePage.isHomePage(), true);
        }

        [Then(@"I should get error message in home page: (.*)")]
        public void ThenGetHome(string message)
        {
            Assert.AreEqual(homePage.loginFailMessage().Text, message);
        }
    }
}

