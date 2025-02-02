using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UIAutomationTests.Models;

namespace UIAutomationTests.Pages
{
    public class SamplePageTestPage : BasePage
    {
        public SamplePageTestPage(IWebDriver driver) : base(driver) { }

        By fileUploadProfileImage = By.CssSelector("input[type='file']");
        By inputName = By.ClassName("name");
        By inputEmail = By.ClassName("email");
        By inputWebsite = By.ClassName("url");
        By dropdownExperience = By.CssSelector("select.select");
        By inputComment = By.TagName("textarea");
        By checkboxExpertise(string expertise) => By.CssSelector($"input.checkbox-multiple[value='{expertise}']");
        By radioEducation(string education) => By.CssSelector($"input.radio[value='{education}']");
        By buttonSubmit = By.ClassName("pushbutton-wide");
        By result = By.ClassName("contact-form-submission");

        public IWebElement FileUploadProfileImage => driver.FindElement(fileUploadProfileImage);
        
        public IWebElement InputName => driver.FindElement(inputName);
        
        public IWebElement InputEmail => driver.FindElement(inputEmail);
              
        public IWebElement InputWebsite => driver.FindElement(inputWebsite);
        
        public IWebElement DropdownExperience => driver.FindElement(dropdownExperience);
        
        public IWebElement CheckboxExpertise(string expertise) => driver.FindElement(checkboxExpertise(expertise));
        
        public IWebElement RadioEducation(string education) => driver.FindElement(radioEducation(education));
        
        public IWebElement InputComment => driver.FindElement(inputComment);
        
        public IWebElement ButtonSubmit => driver.FindElement(buttonSubmit);
        
        public By Result => result;

        public void SelectImage(string image)
        {
            FileUploadProfileImage.SendKeys(image);
        }

        public void EnterName(string name)
        {
            ActionType(InputName, name);
        }

        public void EnterEmail(string email)
        {
            ActionType(InputEmail, email);
        }
        
        public void EnterWebsite(string url)
        {
            ActionType(InputWebsite, url);
        }

        public void SelectExperience(string experience)
        {
            SelectElement selectElement = new SelectElement(DropdownExperience);
            selectElement.SelectByText(experience);
        }

        public void SelectExpertise(string expertise)
        {
            ScrollToElement(CheckboxExpertise(expertise));
            JSClick(CheckboxExpertise(expertise));
        }

        public void SelectEducation(string education)
        {
            JSClick(RadioEducation(education));
        }

        public void EnterComment(string comment)
        {
            ActionType(InputComment, comment);
        }

        public void ClickOnSubmit()
        {
            JSClick(ButtonSubmit);
        }

        public void Navigate()
        {
            Navigate(EnvVar.URL + "/samplepagetest");
        }
    }
}

