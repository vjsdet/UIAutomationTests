using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlow.Selenium.Models;
using TechTalk.SpecFlow;
using UIAutomationTests.Pages;
using UIAutomationTests.Utils;

namespace UIAutomationTests.StepDefinitions
{
    [Binding]
public sealed class DragDropSteps : BaseSteps
    {
        DragDropPage dragDropPage;

        public DragDropSteps(IWebDriver driver, TestData testData)
        {
            dragDropPage = new DragDropPage(driver);
        }

        [Given(@"the user navigates to the drag drop page")]
        public void GivenTheUserNavigatedToSamplePageTestPage()
        {
            dragDropPage.Navigate();
            Assert.AreEqual(dragDropPage.Title, "Drag And Drop - GlobalSQA");
            Util.Log.Info("Drag drop page page has opened");
        }
        
        [When(@"the user drags and drops all the images to the trash")]
        public void WhenTheUserDragDropImages()
        {
            dragDropPage.SwitchToPhotoManagerFrame();
            foreach(var item in dragDropPage.ButtonDraggableImages)
            {
                dragDropPage.DragDrop(item, dragDropPage.DivTrash);
                Thread.Sleep(1000);
            }
            Util.Log.Info("User dragged and dropped all the images to the trash");
        }

        [Then(@"the user should see all the images in the trash")]
        public void TheUserShouldSeeDroppedImages()
        {
            Assert.AreEqual(dragDropPage.ButtonDraggableImages.Count,0);
            Assert.AreEqual(dragDropPage.ButtonDroppedImages.Count,4);
        }

        [When(@"the user recycles all the images from the trash")]
        public void TheUserRecyclesDroppedImages()
        {
            foreach (var item in dragDropPage.ButtonRecycleImages)
            {
                item.Click();
                Thread.Sleep(1000);
            }
            Util.Log.Info("User has recycled all the images from the trash");
        }

        [Then(@"the user should see all the images back in the drag area")]
        public void TheUserShouldSeeImagesToDragArea()
        {
            Assert.AreEqual(dragDropPage.ButtonDraggableImages.Count, 4);
            Assert.AreEqual(dragDropPage.ButtonDroppedImages.Count, 0);
        }
    }
}
