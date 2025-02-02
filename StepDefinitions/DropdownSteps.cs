using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UIAutomationTests.Pages;
using UIAutomationTests.Utils;

namespace UIAutomationTests.StepDefinitions
{
    [Binding]
    public sealed class DropdownSteps : BaseSteps
    {
        DropdownPage dropdownPage;
        public DropdownSteps(IWebDriver driver)
        {
            dropdownPage = new DropdownPage(driver);
        }

        [Given(@"the user navigates to the dropwdown page")]
        public void GivenTheUserNavigatedToDropwdownPage()
        {
            dropdownPage.Navigate();
            Assert.AreEqual(dropdownPage.Title, "DropDown Menu - GlobalSQA");
            Util.Log.Info("DropDown page page has opened");
        }

        [When(@"the user select ""([^""]*)"" from country dropdown")]
        public void WhenTheUserSelectFromCountryDropdown(string country)
        {
            dropdownPage.SelectCountry(country);
            Util.Log.Info("User has selected from country dropdown");
        }

        [Then(@"the user should see the ""([^""]*)"" selected in country dropdown")]
        public void ThenTheUserShouldSeeTheSelectedInCountryDropdown(string country)
        {
            Assert.AreEqual(dropdownPage.GetSelectedCountry(), country);
            Util.Log.Info("User has seen the selected value in country dropdown");
        }
    }
}
