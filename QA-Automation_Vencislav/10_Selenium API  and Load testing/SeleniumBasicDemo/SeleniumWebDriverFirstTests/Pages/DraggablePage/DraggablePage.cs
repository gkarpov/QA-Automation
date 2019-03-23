using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumWebDriverFirstTests.Pages.DraggablePage
{
    public partial class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver) 
            : base (driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "http://demoqa.com/draggable/";
        }

        public void DragObjectByPixels()
        {
            Actions action = new Actions(this.Driver);
            action.DragAndDropToOffset(this.DragableObject, 50, 250);
            action.Perform();
        }

        public void DragObjectToTarget()
        {
            Actions action = new Actions(this.Driver);
            action.DragAndDrop(this.DropableObject, this.DropableTarget);
            action.Perform();
        }
    }
}
