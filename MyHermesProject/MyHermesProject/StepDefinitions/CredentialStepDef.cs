using MyHermesProject.PageObjects;
using MyHermesProject.UtilityHelper;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace MyHermesProject.StepDefinitions
{
    [Binding]
    public sealed class CredentialStepDef
    {
        BasePage basePage = new BasePage();
        HomePage homePage = new HomePage();
        LoginPage loginPage = new LoginPage();
        MyAccountPage myAccountPage = new MyAccountPage();


        [Given(@"I navigate to myHermes site")]
        public void GivenINavigateToMyHermesSite()
        {
            homePage = basePage.NavigateToSite();
        }

        [When(@"I choose to login with '(.*)' user '(.*)' details")]
        public void WhenIChooseToLoginWithUserDetails(string credential, string emailAddress)
        {
            switch (credential)
            {
                case "Valid":
                    loginPage = homePage.ChooseToNavigateToLoginPage();
                    myAccountPage = (MyAccountPage) loginPage.IChooseToLogin(emailAddress);
                    break;

                case "Invalid":
                    loginPage = homePage.ChooseToNavigateToLoginPage();
                    loginPage = loginPage.IChooseToLoginAsAnInvalidUser(emailAddress);
                    break;

                default:
                    Assert.Fail("Wrong credential specified");
                    break;
            }

        }

        [Then(@"I should see '(.*)' page")]
        public void ThenIShouldSeePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see '(.*)' for user with '(.*)'")]
        public void ThenIShouldSeeForUserWith(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I choose to login with")]
        public void WhenIChooseToLoginWith(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
