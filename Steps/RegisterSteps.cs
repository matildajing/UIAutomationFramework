using BuggyUITest.Pages;
using BuggyUITest.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyUITest.Steps
{
    [Binding]
    public class RegisterSteps : BaseStep
    {

        private ScenarioContext _scenarioContext;

        public RegisterSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Then(@"I should see the page contain Register with Buggy Cars Rating")]
        public void ThenIShouldSeeTitle()
        {
            Assert.AreEqual(registerPage.waitPageLoad(), true);
        }

        [Then(@"I could not click Register button as no info is filled")]
        public void ThenRegisterButtonStatus()
        {
            Assert.AreEqual(registerPage.btnRegisterDown().Enabled, false);
        }

        [When(@"I fill fields Login: (.*), First Name: (.*), Last Name: (.*), Password: (.*)")]
        public void WhenFillRegistrationFields(string loginName, string firstName, string lastName, string password)
        {
            string username = loginName + StringConvert.GetRandomString(10, true, true, true, false, null);
            _scenarioContext.Set<string>(username, "username");

            string firstname = firstName + StringConvert.GetRandomString(10, true, true, true, false, null);
            _scenarioContext.Set<string>(firstname, "firstname");

            registerPage.fillRegisterFields(username, firstname, lastName, password, password);
        }

        [Then(@"I could click Register button")]
        public void ThenRegisterButtonStatusTrue()
        {
            Assert.AreEqual(registerPage.btnRegisterDown().Enabled, true);
        }

        [When(@"I click Register submit button")]
        public void WhenIClickRegister()
        {
            registerPage.btnRegisterDown().Click();

        }

        [Then(@"I should get success message: (.*)")]
        public void ThenGetRegisterSuccessMessage(string message)
        {
            Assert.AreEqual(registerPage.messageSuccess().Text, message);
        }


        //register page 
        [Given(@"I am on the register page")]
        public void GivenIAmOnTheRegisterPage()
        {
            registerPage.GoToRegisterPage();
        }

        [When(@"I fill all fields except with improper password requirement, length: (.*), hasUpper: (.*), hasLower: (.*), hasSpecial: (.*)")]
        public void WhenFillRegistrationFieldsRightExceptPassword(int length, string hasUpper, string hasLower, string hasSpecial)
        {
            string username = "auto_test" + StringConvert.GetRandomString(10, true, true, true, false, null);
            _scenarioContext.Set<string>(username, "username");

            string firstname = "firstname_" + StringConvert.GetRandomString(10, true, true, true, false, null);
            _scenarioContext.Set<string>(firstname, "firstname");

            string password = StringConvert.GetRandomString(
                length, true,
                StringConvert.StringToBool(hasLower),
                StringConvert.StringToBool(hasUpper), StringConvert.StringToBool(hasSpecial), null);

            registerPage.fillRegisterFields(username, firstname, "last_name", password, password);

        }

        [Then(@"I should get error message: (.*)")]
        public void ThenGetRegisterErrorMessage(string message)
        {
            System.Console.WriteLine("error message is: {0}", registerPage.messageFail().Text);
            Assert.AreEqual(registerPage.messageFail().Text, message);
        }

        [When(@"I fill all fields except with existed user_name: (.*)")]
        public void WhenFillExistedUsername(string username)
        {

            string password = StringConvert.GetRandomString(10, true, true, true, true, null);

            registerPage.fillRegisterFields(username, "first_name", "last_name", password, password);

        }


        [When(@"I click Cancel button")]
        public void WhenClickCancel()
        {
            registerPage.btnCancel().Click();

        }


    }
}


