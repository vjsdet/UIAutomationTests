using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UIAutomationTests.Models;

namespace UIAutomationTests.Pages
{
    public class DropdownPage: BasePage
    {
        public DropdownPage(IWebDriver driver) : base(driver) { }
        By dropdownCountry = By.CssSelector("[rel-title='Select Country'] select");
        public IWebElement DropdownCountry => driver.FindElement(dropdownCountry);

        public void Navigate()
        {
            Navigate(EnvVar.URL + "/demo-site/select-dropdown-menu");
        }

        public void SelectCountry(string country)
        {
            SelectElement selectElement = new SelectElement(DropdownCountry);
            selectElement.SelectByText(country);
        }

        public string GetSelectedCountry()
        {
            SelectElement selectElement = new SelectElement(DropdownCountry);
            return selectElement.SelectedOption.Text;
        }
    }
}

