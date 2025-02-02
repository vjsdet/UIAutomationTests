using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlow.Selenium.Models;
using TechTalk.SpecFlow;
using UIAutomationTests.Models;
using UIAutomationTests.Pages;
using UIAutomationTests.Utils;

namespace UIAutomationTests.StepDefinitions
{
    [Binding]
    public sealed class SamplePageTestSteps : BaseSteps
    {
        SamplePageTest samplePageTest;
        SamplePageTestPage samplePageTestPage;

        public SamplePageTestSteps(IWebDriver driver, TestData testData)
        {
            samplePageTestPage = new SamplePageTestPage(driver);
            this.samplePageTest = testData.SamplePageTest;
        }

        [Given(@"the user navigates to the sample page test page")]
        public void GivenTheUserNavigatedToSamplePageTestPage()
        {
            samplePageTestPage.Navigate();
            Assert.AreEqual(samplePageTestPage.Title, "Sample Page Test - GlobalSQA");
            Util.Log.Info("sample page test page has opened");
        }

        [When(@"the user selects the profile image")]
        public void GivenTheUserSelectProfileImage()
        {
            string imagePath = $"{Util.GetRootPath}\\TestData\\{EnvVar.ENV}\\Images\\ProfileImages\\{samplePageTest.ProfileImage}";
            samplePageTestPage.SelectImage(imagePath);
        }

        [When(@"the user enters the name")]
        public void WhenTheUserEntersName()
        {
            samplePageTestPage.EnterName(samplePageTest.Name);
            Util.Log.Info("User has entered the name");
        }

        [When(@"the user presses the TAB key on name field")]
        public void WhenTheUserPressesTabKey()
        {
            samplePageTestPage.PressTabOnElement(samplePageTestPage.InputName);
            Util.Log.Info("User has pressed the TAB key on Name field");
        }

        [When(@"the user enters the email")]
        public void WhenTheUserEntersEmail()
        {
            Assert.IsTrue(Util.IsValidEmail(samplePageTest.Email), "Invalid email pattern");
            samplePageTestPage.EnterEmail(samplePageTest.Email);
            Util.Log.Info("User has entered the email");
        }

        [When(@"the user enters the website")]
        public void WhenTheUserEntersWebsite()
        {
            samplePageTestPage.EnterWebsite(samplePageTest.Website);
            Util.Log.Info("User has entered the website");
        }

        [When(@"the user selects the experience")]
        public void WhenTheUserSelectsExperience()
        {
            samplePageTestPage.SelectExperience(samplePageTest.Experience);
            Util.Log.Info("User has selected the experience");
        }

        [When(@"the user selects the expertise")]
        public void WhenTheUserSelectsExpertise()
        {
            foreach (var item in samplePageTest.Expertise)
            {
                samplePageTestPage.SelectExpertise(item);
            }
            Util.Log.Info("User has selected the expertise");
        }

        [When(@"the user selects the education")]
        public void WhenTheUserSelectsEducation()
        {
            samplePageTestPage.SelectEducation(samplePageTest.Education);
            Util.Log.Info("User has selected the education");
        }

        [When(@"the user enters the comment")]
        public void WhenTheUserEntersComment()
        {
            samplePageTestPage.EnterComment(samplePageTest.Comment);
            Util.Log.Info("User has entered the comment");
        }

        [When(@"the user clicks on the submit button")]
        public void WhenTheUserClicksSubmit()
        {
            samplePageTestPage.ClickOnSubmit();
            Util.Log.Info("User has clicked on the submit button");
        }

        [Then(@"the sample page test details should be saved")]
        public void WhenTheUserVerifyResult()
        {
            samplePageTestPage.WaitforElementToBeDisplay(samplePageTestPage.Result);
            Assert.IsTrue(samplePageTestPage.IsTextExistsOnPage("Message Sent"));
            Assert.IsTrue(samplePageTestPage.IsTextExistsOnPage($"Name: {samplePageTest.Name}"), "Name does not match");
            Assert.IsTrue(samplePageTestPage.IsTextExistsOnPage($"Email: {samplePageTest.Email}") || samplePageTestPage.IsTextExistsOnPage($"Email: [Email protected]"), "Email does not match");
            Assert.IsTrue(samplePageTestPage.IsTextExistsOnPage($"Website: {samplePageTest.Website}"), "Website does not match");
            Assert.IsTrue(samplePageTestPage.IsTextExistsOnPage($"Experience (In Years): {samplePageTest.Experience}"), "Experience does not match");
            Assert.IsTrue(samplePageTestPage.IsTextExistsOnPage($"Expertise :: {String.Join(", ", samplePageTest.Expertise.Reverse())}"), "Expertise does not match");
            Assert.IsTrue(samplePageTestPage.IsTextExistsOnPage($"Education: {samplePageTest.Education}"), "Education does not match");
            Assert.IsTrue(samplePageTestPage.IsTextExistsOnPage($"Comment: {samplePageTest.Comment}"), "Comment does not match");
            Util.Log.Info("Sample page test details has saved");
        }
    }
}
