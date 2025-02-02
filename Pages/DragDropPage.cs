using OpenQA.Selenium;
using UIAutomationTests.Models;

namespace UIAutomationTests.Pages
{
    public class DragDropPage : BasePage
    {
        public DragDropPage(IWebDriver driver) : base(driver) { }
        By framePhotoManager = By.CssSelector("div[rel-title='Photo Manager'] .demo-frame");
        By buttonRecycleImage = By.CssSelector(".ui-icon.ui-icon-refresh");
        By buttonDraggableImage = By.CssSelector("#gallery .ui-draggable-handle");
        By divTrash = By.CssSelector("#trash.ui-droppable");
        By buttonDropedImage = By.CssSelector("#trash.ui-droppable .ui-draggable-handle");
        
        public IWebElement FramePhotoManager => driver.FindElement(framePhotoManager);
       
        public IWebElement DivTrash => driver.FindElement(divTrash);
        
        public IList<IWebElement> ButtonDraggableImages => driver.FindElements(buttonDraggableImage);
        
        public IList<IWebElement> ButtonDroppedImages => driver.FindElements(buttonDropedImage);
        
        public IList<IWebElement> ButtonRecycleImages => driver.FindElements(buttonRecycleImage);

        public void Navigate()
        {
            Navigate(EnvVar.URL + "/draganddrop");
        }

        public void SwitchToPhotoManagerFrame()
        {
            driver.SwitchTo().Frame(FramePhotoManager);
        }
    }
}

